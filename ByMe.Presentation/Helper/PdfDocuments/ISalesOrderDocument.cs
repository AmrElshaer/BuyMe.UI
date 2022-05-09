using QuestPDF.Infrastructure;

namespace ByMe.Presentation.Helper.PdfDocuments
{
    public interface ISalesOrderDocument : IDocument
    {
        Task<byte[]> GetSalesOrderPDfAsync(long salesOrderId);
    }
}
