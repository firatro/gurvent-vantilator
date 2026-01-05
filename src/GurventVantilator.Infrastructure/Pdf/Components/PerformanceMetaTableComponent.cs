using GurventVantilator.Application.DTOs.Pdf;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class PerformanceMetaTableComponent : IComponent
    {
        private readonly PerformanceMetaDto _meta;

        public PerformanceMetaTableComponent(PerformanceMetaDto meta)
        {
            _meta = meta;
        }

        public void Compose(IContainer container)
        {
            container.Column(col =>
            {
                // ==================================================
                // 🔹 İSTENEN ÇALIŞMA NOKTASI (KULLANICI GİRİŞİ)
                // ==================================================
                col.Item()
                    .PaddingBottom(3)
                    .Text("İstenen Çalışma Noktası")
                    .FontSize(9.5f)
                    .Bold()
                    .FontColor(Colors.Grey.Darken3);

                col.Item()
                    .Background(Colors.Transparent)
                    .Padding(6)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(cols =>
                        {
                            cols.RelativeColumn();    // Label
                            cols.ConstantColumn(45);  // Unit
                            cols.ConstantColumn(55);  // Value
                        });

                        void Row(string label, string unit, double value, bool alternate)
                        {
                            var bg = alternate
                                ? Colors.LightBlue.Lighten4
                                : Colors.Transparent;

                            // LABEL
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingLeft(4)
                                .Text(label)
                                .FontSize(8.5f);

                            // UNIT
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .AlignCenter()
                                .Text(unit)
                                .FontSize(8);

                            // VALUE
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingRight(4)
                                .AlignRight()
                                .Text(value.ToString("0.##"))
                                .FontSize(8.5f)
                                .Bold();
                        }

                        Row("Debi (Q)", "m³/h", _meta.Q, false);
                        Row("Basınç (Pt)", "Pa", _meta.Pt, true);
                    });

                // ==================================================
                // 🔹 BAŞLIK – HESAPLANAN SONUÇLAR
                // ==================================================
                col.Item()
                    .PaddingTop(8)
                    .PaddingBottom(4)
                    .Text("Çalışma Noktası Sonuçları")
                    .FontSize(9.5f)
                    .Bold()
                    .FontColor(Colors.Grey.Darken3);

                // ==================================================
                // 🔹 META TABLO
                // ==================================================
                col.Item()
                    .Background(Colors.Transparent)
                    .Padding(6)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(cols =>
                        {
                            cols.RelativeColumn();    // Label
                            cols.ConstantColumn(45);  // Unit
                            cols.ConstantColumn(55);  // Value
                        });

                        void Row(string label, string unit, double value, bool alternate)
                        {
                            var bg = alternate
                                ? Colors.LightBlue.Lighten4
                                : Colors.Transparent;

                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingLeft(4)
                                .Text(label)
                                .FontSize(8.5f);

                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .AlignCenter()
                                .Text(unit)
                                .FontSize(8);

                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingRight(4)
                                .AlignRight()
                                .Text(value.ToString("0.##"))
                                .FontSize(8.5f)
                                .Bold();
                        }

                        Row("Debi", "m³/h", _meta.Q, false);
                        Row("Statik Basınç", "Pa", _meta.Ps, true);
                        Row("Toplam Basınç", "Pa", _meta.Pt, false);
                        Row("Dinamik Basınç", "Pa", _meta.Pd, true);
                        Row("Hız", "m/s", _meta.Speed, false);
                        Row("Akım", "A", _meta.Current, true);
                        Row("Hava Gücü", "W", _meta.AirPower, false);
                        Row("Toplam Verim", "%", _meta.TotalEfficiency, true);
                        Row("Mekanik Verim", "%", _meta.MechanicalEfficiency, false);
                        Row("Ses Seviyesi", "dB(A)", _meta.Db, true);
                    });
            });
        }

    }
}
