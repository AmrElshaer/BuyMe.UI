using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.SalesOrderLine.Queries;
using MediatR;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ByMe.Presentation.Helper.PdfDocuments
{

    public class SalesOrderDocument : ISalesOrderDocument
    {
        private readonly SalesOrderDto orderDto;
        private readonly IList<SalesOrderLineDto> salesOrderLines;
        private readonly IMediator mediator;

        public SalesOrderDocument(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private SalesOrderDocument(SalesOrderDto orderDto, IList<SalesOrderLineDto> salesOrderLines)
        {
            this.orderDto = orderDto;
            this.salesOrderLines = salesOrderLines;
        }
        public void Compose(IDocumentContainer container)
        {
            container
            .Page(page =>
            {
                page.Margin(50);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);


                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        }
        void ComposeHeader(IContainer container)
        {



            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {

                    column.Item().Text(text =>
                    {
                        text.Span("SalesOrder: ").SemiBold();
                        text.Span($"{orderDto.SalesOrderName}");
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Order date: ").SemiBold();
                        text.Span($"{orderDto.OrderDate:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Delivery date: ").SemiBold();
                        text.Span($"{orderDto.DeliveryDate:d}");
                    });
                });
                row.RelativeItem().Column(column =>
                {

                    column.Item().Text(text =>
                    {
                        text.Span("Customer: ").SemiBold();
                        text.Span($"{orderDto.CustomerName}");
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Branch: ").SemiBold();
                        text.Span($"{orderDto.BranchName}");
                    });

                });
                row.ConstantItem(100).Height(50).Placeholder("ByMe");
            });
        }


        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);
                column.Item().Element(ComposeTable);
                column.Item().AlignRight().Text($"total: {orderDto.Total} {orderDto.CurrencyCode}").FontSize(14);

                if (!string.IsNullOrWhiteSpace(orderDto.Remarks))
                    column.Item().PaddingTop(25).Element(ComposeComments);
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                foreach (var item in salesOrderLines.Select((value, i) => (value, i)))
                {
                    table.Cell().Element(CellStyle).Text(item.i + 1);
                    table.Cell().Element(CellStyle).Text(item.value.ProductName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.value.Price} {orderDto.CurrencyCode}");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.value.Quantity);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.value.Total} {orderDto.CurrencyCode}");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        void ComposeComments(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Remarks").FontSize(14);
                column.Item().Text(orderDto.Remarks);
            });
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public async Task<byte[]> GetSalesOrderPDfAsync(long salesOrderId)
        {
            var so = await mediator.Send(new GetSalesOrderQuery(salesOrderId));
            var salesOrdersLines = (await mediator.Send(new GetSOLinesQuery(salesOrderId)))?.result;
            var document = new SalesOrderDocument(so, salesOrdersLines);
            return document.GeneratePdf();
        }
    }
}
