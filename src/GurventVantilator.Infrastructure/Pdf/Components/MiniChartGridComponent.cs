using GurventVantilator.Application.DTOs.Pdf;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class MiniChartGridComponent : IComponent
    {
        private readonly ChartImagesDto _charts;

        public MiniChartGridComponent(ChartImagesDto charts)
        {
            _charts = charts;
        }

        public void Compose(IContainer container)
        {
            container.Column(col =>
            {
                col.Spacing(10);

                BuildRow(col,
                    _charts.Ps,
                    _charts.Pd,
                    _charts.Pt);

                BuildRow(col,
                    _charts.Speed,
                    _charts.Current,
                    _charts.Power);

                BuildRow(col,
                    _charts.Db,
                    _charts.EffStatic,
                    _charts.EffTotal);
            });
        }

        private void BuildRow(ColumnDescriptor col, string? c1, string? c2, string? c3)
        {
            col.Item().Row(row =>
            {
                row.RelativeItem().Component(new ChartImageComponent(c1));
                row.RelativeItem().Component(new ChartImageComponent(c2));
                row.RelativeItem().Component(new ChartImageComponent(c3));
            });
        }
    }
}
