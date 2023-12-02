using AssignmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace AssignmentApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private static List<Invoice> _invoices = new List<Invoice>();
        

        public async Task<Invoice> CreateInvoice(Invoice inv)
        {
            _invoices.Add(inv);
            return inv;
        }

        public async Task<Invoice> EditInvoice(int id, Invoice invoice)
        {
            Console.WriteLine(_invoices);
            var existingInvoice = _invoices.FirstOrDefault(i => i.Id == id);
            if (existingInvoice == null)
            {
                throw new Exception("Invoice not found");
            }
            else  
            {
                existingInvoice.Id = id;
                existingInvoice.Description = invoice.Description;
                existingInvoice.InvoiceLines = invoice.InvoiceLines;
                return existingInvoice;
            }
        }
    }
}
