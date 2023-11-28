using AssignmentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Services
{
    public class InvoiceService : IInvoiceService
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

        public async Task<Invoice> CreateInvoice(Invoice inv)
        {
            if (inv.InvoiceLines != null && inv.InvoiceLines.Any())
            {
                decimal total = 0;
                foreach (var line in inv.InvoiceLines)
                {
                    line.LineAmount = line.Quantity * line.UnitPrice;
                    total += line.LineAmount;
                }
                inv.TotalAmount = total;
            }
            _invoices.Add(inv);
            return inv;
        }

        public async Task<Invoice> EditInvoice(int id, Invoice invoice)
        {
            Console.WriteLine(_invoices);
            Console.WriteLine(invoice);
            Console.WriteLine(id);

            if (id != invoice.Id)
            {
                throw new ArgumentException("Id does not match");
            }

            var existingInvoice = _invoices.FirstOrDefault(i => i.Id == id);
            if (existingInvoice == null)
            {
                throw new ArgumentException("Invoice not found");
            }

            existingInvoice.Description = invoice.Description;
            foreach (var line in invoice.InvoiceLines)
            {
                if (line.Id == 0)
                {
                    existingInvoice.InvoiceLines.Add(line);
                }
                else
                {
                    var existingLine = existingInvoice.InvoiceLines.FirstOrDefault(l => l.Id == line.Id);
                    if (existingLine != null)
                    {
                        existingLine.Description = line.Description;
                        existingLine.Quantity = line.Quantity;
                        existingLine.UnitPrice = line.UnitPrice;
                    }
                }
            }

            decimal total = 0;
            foreach (var line in existingInvoice.InvoiceLines ?? new List<InvoiceLine>())
            {
                line.LineAmount = line.Quantity * line.UnitPrice;
                total += line.LineAmount;
            }
            existingInvoice.TotalAmount = total;

            return existingInvoice;
        }
    }
}
