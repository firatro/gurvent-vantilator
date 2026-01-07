showLoader("Performans verileri yükleniyor...");

let lastSelected = {
    datasetIndex: null,
    x: null,
    y: null
};

let pinnedTooltip = null;
let fanChartInstance = null;
const miniCharts = {};

// =========================
// STATE UYGULAYICI (TEK MERKEZ)
// =========================
function applyWorkingPoint(p) {
    if (!p) return;
    updateMetaFromPoint(p);
    updateMiniChartsWorkingPoint(p);
}

// =========================
// ANA GRAFİK YÜKLE
// =========================
fetch(
  `/FanChart/GetChart`
  + `?productId=${window.performanceData.productId}`
  + `&speedControl=${window.performanceData.speedControl || ""}`
  + `&voltage=${encodeURIComponent(window.performanceData.selectedVoltage || "")}`
).then(res => res.json())
    .then(chart => {

        const canvas = document.getElementById('fanChart');
        if (!canvas) return;

        Chart.register({
            id: 'pinnedTooltipPlugin',
            afterDraw(chart) {
                if (pinnedTooltip) {
                    chart.tooltip.setActiveElements(
                        [pinnedTooltip],
                        { x: chart.chartArea.left, y: chart.chartArea.top }
                    );
                }
            }
        });

        fanChartInstance = new Chart(canvas, {
            type: 'line',
            data: {
                datasets: chart.datasets.map(d => ({
                    label: d.label,
                    hidden: d.hideLegend === true,
                    data: d.data.map(p => ({
                        x: p.x,
                        y: p.y,
                        ps: p.ps,
                        pd: p.pd,
                        speed: p.speed,
                        current: p.current,
                        airPower: p.airPower,
                        totalEfficiency: p.totalEfficiency,
                        mechanicalEfficiency: p.mechanicalEfficiency,
                        db: p.db
                    })),
                    borderWidth: 2,
                    tension: 0.3,
                    pointRadius: 0
                }))
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                parsing: false,
                onClick: (evt, elements) => {
                    if (!elements.length) {
                        pinnedTooltip = null;
                        fanChartInstance.tooltip.setActiveElements([]);
                        updateWorkingPointLabel(null);
                        fanChartInstance.update('none');
                        return;
                    }

                    const { datasetIndex, index } = elements[0];
                    const dataset = fanChartInstance.data.datasets[datasetIndex];
                    const point = dataset.data[index];

                    // 🔥 AYNI NOKTAYA TIKLANDI MI?
                    const sameSelection =
                        lastSelected.datasetIndex === datasetIndex &&
                        lastSelected.x === point.x &&
                        lastSelected.y === point.y;

                    if (sameSelection) return;

                    // 🔥 STATE GÜNCELLE
                    lastSelected = {
                        datasetIndex,
                        x: point.x,
                        y: point.y
                    };

                    // 🔥 PINNED TOOLTIP
                    pinnedTooltip = { datasetIndex, index };

                    // 🔥 EĞRİYİ VURGULA
                    selectDatasetByIndex(datasetIndex);

                    // 🔥 H2 ETİKETİ
                    if (dataset?.label) {
                        updateWorkingPointLabel(dataset.label);
                    }

                    // 🔥 META + MINI CHART
                    applyWorkingPoint(point);

                    // 🔥 ANİMASYONSUZ UPDATE
                    fanChartInstance.update('none');
                },
                plugins: {
                    legend: {
                        position: 'bottom',
                        onClick: (_, item) => {
                            selectDatasetByIndex(item.datasetIndex);
                            const ds = fanChartInstance.data.datasets[item.datasetIndex];
                            if (ds?.label) {
                                updateWorkingPointLabel(ds.label);
                            }
                            fanChartInstance.update('none');
                        }
                    },
                    tooltip: {
                        enabled: true,
                        callbacks: {
                            title: () => null,
                            label: ctx => {
                                const p = ctx.raw;
                                return [`Q: ${p.x.toFixed(2)}`, `Pt: ${p.y.toFixed(2)}`];
                            }
                        }
                    }
                },
                scales: {
                    x: { type: 'linear', title: { display: true, text: chart.xAxisLabel } },
                    y: { type: 'linear', title: { display: true, text: chart.yAxisLabel } }
                }
            }
        });

        // =========================
        // MINI GRAFİKLER
        // =========================
        createMiniChart('chart-ps', map(chart, 'ps'), 'Ps [Pa]');
        createMiniChart('chart-pd', map(chart, 'pd'), 'Pd [Pa]');
        createMiniChart('chart-pt', map(chart, 'y'), 'Pt [Pa]');
        createMiniChart('chart-speed', map(chart, 'speed'), 'rpm');
        createMiniChart('chart-current', map(chart, 'current'), 'A');
        createMiniChart('chart-power', map(chart, 'airPower'), 'W');
        createMiniChart('chart-eff-static', map(chart, 'mechanicalEfficiency'), '%');
        createMiniChart('chart-eff-total', map(chart, 'totalEfficiency'), '%');
        createMiniChart('chart-db', map(chart, 'db'), 'dB(A)');

        // =========================
        // URL'DEN GELEN ÇALIŞMA NOKTASI
        // =========================
        if (window.performanceData.initialWorkingPoint.q !== null &&
            window.performanceData.initialWorkingPoint.pt !== null) {

            const q = parseFloat(window.performanceData.initialWorkingPoint.q);
            const pt = parseFloat(window.performanceData.initialWorkingPoint.pt);

            document.getElementById("inputQ").value = q;
            document.getElementById("inputPt").value = pt;

            highlightWorkingPoint(q, pt);
        }

        hideLoader();
    });

// =========================
// FORM SUBMIT
// =========================
const form = document.getElementById('workingPointForm');
if (form) {
    form.addEventListener('submit', e => {
        e.preventDefault();
        const q = parseFloat(inputQ.value);
        const pt = parseFloat(inputPt.value);
        if (!isNaN(q) && !isNaN(pt)) highlightWorkingPoint(q, pt);
    });
}


function updateWorkingPointLabel(text) {
    const el = document.getElementById("workingPointLabel");
    if (!el || !text) return;

    el.textContent = text.startsWith("/") ? text : `/${text}`;
    el.style.display = "inline";
    el.style.marginLeft = "6px";
}

// =========================
// WORKING POINT HESAPLA
// =========================
function highlightWorkingPoint(inputQ, inputPt) {
    let minDist = Infinity,
        closestPoint = null,
        closestIndex = -1;

    fanChartInstance.data.datasets.forEach((ds, i) => {
        ds.data.forEach(p => {
            const d = Math.hypot(p.x - inputQ, p.y - inputPt);
            if (d < minDist) {
                minDist = d;
                closestPoint = p;
                closestIndex = i;
            }
        });
    });

    fanChartInstance.data.datasets =
        fanChartInstance.data.datasets.filter(d => d.label !== 'Çalışma Noktası');

    fanChartInstance.data.datasets.push({
        label: 'Çalışma Noktası',
        data: [{ x: inputQ, y: inputPt }],
        borderColor: 'red',
        backgroundColor: 'red',
        pointRadius: 7,
        showLine: false
    });

    selectDatasetByIndex(closestIndex);
    applyWorkingPoint(closestPoint);

    const selectedDataset = fanChartInstance.data.datasets[closestIndex];
    if (selectedDataset?.label) {
        updateWorkingPointLabel(selectedDataset.label);
    }

    // 🔥 BURASI ÇOK ÖNEMLİ
    lastSelected = {
        datasetIndex: closestIndex,
        x: inputQ,
        y: inputPt
    };

    fanChartInstance.update('none');
}



// =========================
// YARDIMCILAR
// =========================
function selectDatasetByIndex(i) {
    fanChartInstance.data.datasets.forEach((ds, idx) => {
        ds.borderWidth = idx === i ? 5 : 1;
        ds.borderColor = idx === i ? '#0d6efd' : '#ccc';
        ds.borderDash = idx === i ? [] : [5, 5];
    });
}

function map(chart, field) {
    return chart.datasets.map(d => ({
        label: d.label,
        data: d.data
            .filter(p => p[field] !== null && p[field] !== undefined)
            .map(p => ({ x: p.x, y: field === 'y' ? p.y : p[field] }))
    }));
}

function createMiniChart(id, datasets, yLabel) {
    datasets.push({
        label: 'Çalışma Noktası',
        data: [],
        backgroundColor: 'red',
        borderColor: 'red',
        pointRadius: 5,
        showLine: false
    });

    const c = new Chart(document.getElementById(id), {
        type: 'line',
        data: { datasets },
        options: {
            parsing: false,
            animation: false, // 🔥 çok önemli
            plugins: { legend: { display: false } },
            scales: { x: { type: 'linear' }, y: { title: { display: true, text: yLabel } } },
            elements: { point: { radius: 0 } }
        }
    });

    miniCharts[id] = c;
}


function updateMiniChartsWorkingPoint(p) {
    const map = {
        "chart-ps": p.ps,
        "chart-pd": p.pd,
        "chart-pt": p.y,
        "chart-speed": p.speed,
        "chart-current": p.current,
        "chart-power": p.airPower,
        "chart-eff-static": p.mechanicalEfficiency,
        "chart-eff-total": p.totalEfficiency,
        "chart-db": p.db
    };

    Object.entries(map).forEach(([id, y]) => {
        const c = miniCharts[id];
        if (!c) return;

        const wpDataset = c.data.datasets.find(d => d.label === 'Çalışma Noktası');
        if (!wpDataset) return;

        wpDataset.data.length = 0;
        wpDataset.data.push({ x: p.x, y });

        c.update('none'); // 🔥 animasyonsuz
    });
}


function updateMetaFromPoint(p) {
    setText('meta-q', p.x);
    setText('meta-ps', p.ps);
    setText('meta-pd', p.pd);
    setText('meta-pt', p.y);
    setText('meta-speed', p.speed);
    setText('meta-current', p.current);
    setText('meta-airpower', p.airPower);
    setText('meta-total-eff', p.totalEfficiency);
    setText('meta-mech-eff', p.mechanicalEfficiency);
    setText('meta-db', p.db);
}

function setText(id, val) {
    document.getElementById(id).innerText =
        val != null ? val.toFixed(2) : '-';
}

function getWorkingPointLabel() {
    const el = document.getElementById("workingPointLabel");
    if (!el) return null;

    return el.innerText?.trim() || null;
}


// GENERATE PDF HELPERS
// Canvas → Base64 yardımcı fonksiyonu
function getCanvasImage(id) {
    const canvas = document.getElementById(id);
    if (!canvas) return null;
    return canvas.toDataURL("image/png");
}

// Meta değerleri DOM’dan topla
function getPerformanceMeta() {
    return {
        q: parseFloat(document.getElementById("meta-q")?.innerText) || 0,
        ps: parseFloat(document.getElementById("meta-ps")?.innerText) || 0,
        pd: parseFloat(document.getElementById("meta-pd")?.innerText) || 0,
        pt: parseFloat(document.getElementById("meta-pt")?.innerText) || 0,
        speed: parseFloat(document.getElementById("meta-speed")?.innerText) || 0,
        current: parseFloat(document.getElementById("meta-current")?.innerText) || 0,
        airPower: parseFloat(document.getElementById("meta-airpower")?.innerText) || 0,
        totalEfficiency: parseFloat(document.getElementById("meta-total-eff")?.innerText) || 0,
        mechanicalEfficiency: parseFloat(document.getElementById("meta-mech-eff")?.innerText) || 0,
        db: parseFloat(document.getElementById("meta-db")?.innerText) || 0
    };
}

// Chart image’larını topla
function getChartImages() {
    return {
        main: getCanvasImage("fanChart"),

        ps: getCanvasImage("chart-ps"),
        pd: getCanvasImage("chart-pd"),
        pt: getCanvasImage("chart-pt"),

        speed: getCanvasImage("chart-speed"),
        current: getCanvasImage("chart-current"),
        power: getCanvasImage("chart-power"),

        effStatic: getCanvasImage("chart-eff-static"),
        effTotal: getCanvasImage("chart-eff-total"),

        db: getCanvasImage("chart-db")
    };
}

// PDF Payload oluşturucu
function buildPdfPayload() {

    // fallback: inputlardan oku
    if (!lastSelected || lastSelected.x == null || lastSelected.y == null) {
        const q = parseFloat(document.getElementById("inputQ").value);
        const pt = parseFloat(document.getElementById("inputPt").value);

        if (!isNaN(q) && !isNaN(pt)) {
            lastSelected = { x: q, y: pt };
        } else {
            alert("Lütfen önce bir çalışma noktası seçiniz.");
            return null;
        }
    }

    return {
        productId: window.performanceData.productId,

        // 🔥 INPUT’TAN GELENLER
        requestedQ: parseFloat(document.getElementById("inputQ").value),
        requestedPt: parseFloat(document.getElementById("inputPt").value),

        // 🔥 GRAFİKTE SEÇİLEN GERÇEK NOKTA
        meta: getPerformanceMeta(),
        workingPointLabel: getWorkingPointLabel(),
        charts: getChartImages(),
        voltage: window.performanceData.selectedVoltage || null
    };

}

const pdfBtn = document.getElementById("btnGeneratePdf");

if (pdfBtn) {
    pdfBtn.addEventListener("click", () => {

        // 🔥 SAFARI FIX → SEKMEYİ SENKRON AÇ
        const pdfWindow = window.open("", "_blank");

        showLoader("PDF oluşturuluyor...");
        pdfBtn.disabled = true;
        pdfBtn.innerText = "PDF Oluşturuluyor...";

        const payload = buildPdfPayload();
        if (!payload) {
            hideLoader();
            pdfBtn.disabled = false;
            pdfBtn.innerText = "📄 PDF Oluştur";
            pdfWindow.close();
            return;
        }

        fetch("/Product/GeneratePerformancePdf", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(payload)
        })
            .then(res => {
                if (!res.ok) throw new Error("PDF üretilemedi");
                return res.blob();
            })
            .then(blob => {

                const url = URL.createObjectURL(blob);

                // 🔥 SAFARI İZİN VERİR
                pdfWindow.location.href = url;

            })
            .catch(err => {
                console.error("PDF ERROR:", err);
                pdfWindow.close();
                alert("PDF oluşturulamadı");
            })
            .finally(() => {
                hideLoader();
                pdfBtn.disabled = false;
                pdfBtn.innerText = "📄 PDF Oluştur";
            });
    });
}


// =========================
// GLOBAL LOADER
// =========================
function showLoader(text = "Lütfen bekleyiniz...") {
    const loader = document.getElementById("globalLoader");
    if (!loader) return;

    const label = loader.querySelector(".loader-text");
    if (label) label.innerText = text;

    loader.classList.add("active");
}

function hideLoader() {
    const loader = document.getElementById("globalLoader");
    if (!loader) return;

    loader.classList.remove("active");
}
