using AssignmentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Services
{
    public class InvoiceService : IInvoice
    {
        private List<Invoice> _invoices = new List<Invoice>
        {
            new Invoice()
            {
                Id = 1,
                Description = "Danuja",
                TotalAmount = 10,
                InvoiceLines = { }
            }   
        };

        public void AddInvoiceLine(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public void CreateInvoice(Invoice inv)
        {
            _invoices.Add(inv);
        }

        public void UpdateInvoice(int id)
        {
            var invoice = _invoices.Find(id);

        }
    }
}
