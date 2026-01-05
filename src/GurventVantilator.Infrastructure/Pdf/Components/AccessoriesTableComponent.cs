using GurventVantilator.Application.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Collections.Generic;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class AccessoriesTableComponent : IComponent
    {
        private readonly IEnumerable<ProductAccessoryDto> _accessories;

        public AccessoriesTableComponent(IEnumerable<ProductAccessoryDto> accessories)
        {
            _accessories = accessories;
        }

        public void Compose(IContainer container)
        {
            container.Column(col =>
            {

                // 🔹 TABLO
                col.Item()
                    .Background(Colors.Transparent)
                    .Padding(6)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(cols =>
                        {
                            cols.RelativeColumn();    // Model
                            cols.RelativeColumn();    // Type
                            cols.ConstantColumn(80);  // Article No
                        });

                        // HEADER
                        void HeaderCell(string text)
                        {
                            table.Cell()
                                .Background(Colors.LightBlue.Lighten4)
                                .PaddingVertical(4)
                                .PaddingLeft(4)
                                .AlignCenter()
                                .Text(text)
                                .FontSize(8.5f)
                                .Bold();
                        }

                        HeaderCell("Model");
                        HeaderCell("Type");
                        HeaderCell("Article No");

                        int i = 0;

                        foreach (var acc in _accessories)
                        {
                            var bg = i % 2 == 0
                                ? Colors.Transparent
                                : Colors.LightBlue.Lighten3;

                            // MODEL
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingLeft(4)
                                .AlignCenter()
                                .Text(acc.AccessoryName)
                                .FontSize(8.5f);

                            // TYPE
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingLeft(4)
                                .AlignCenter()
                                .Text(acc.Type)
                                .FontSize(8.5f);

                            // ARTICLE
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(3)
                                .PaddingRight(4)
                                .AlignCenter()
                                .Text(acc.ArticleNumber ?? "-")
                                .FontSize(8.5f)
                                .Bold();

                            i++;
                        }
                    });
            });
        }
    }
}
