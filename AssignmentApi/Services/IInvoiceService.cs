using AssignmentApi.Models;

namespace AssignmentApi.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<Invoice> EditInvoice(int id, Invoice invoice);

       /* void AddInvoiceLine(int invoiceId);*/
    }
}
