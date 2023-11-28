using AssignmentApi.Models;

namespace AssignmentApi.Services
{
    public interface IInvoice
    {
        void CreateInvoice(Invoice inv);
        void UpdateInvoice(int id);

        void AddInvoiceLine(int invoiceId);
    }
}
