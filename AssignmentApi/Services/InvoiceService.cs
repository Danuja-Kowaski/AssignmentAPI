using AssignmentApi.Dtos;
using AssignmentApi.Migrations;
using AssignmentApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly InvoiceDbContext _invoiceDbContext;
        public InvoiceService(InvoiceDbContext context, IMapper mapper)
        {
            _invoiceDbContext = context;
            _mapper = mapper;
        }


        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice inv)
        {

            try {
                CalculateLineAmount(inv);
                CalculateTotalAmount(inv);
                _invoiceDbContext.Invoices.Add(inv);
                await _invoiceDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             return inv;
        }

        public async Task<ActionResult<Invoice>> EditInvoice(int id, Invoice invoice)
        {

            var existingInvoice = await _invoiceDbContext.Invoices
            .Include(i => i.InvoiceLines)
            .FirstOrDefaultAsync(i => i.Id == id);

            if (existingInvoice == null)
            {
                throw new Exception("Invoice not found");
            }
            else  
            {
                existingInvoice.Description = invoice.Description;
                var invoiceLinesList = existingInvoice.InvoiceLines.ToList();
                var invoiceLinesToUpdateList = invoice.InvoiceLines.ToList();
                for (int i = 0; i < invoiceLinesList.Count; i++)
                {
                    invoiceLinesList[i].Description = invoiceLinesToUpdateList[i].Description;
                    invoiceLinesList[i].Quantity = invoiceLinesToUpdateList[i].Quantity;
                    invoiceLinesList[i].UnitPrice = invoiceLinesToUpdateList[i].UnitPrice;
                }

                existingInvoice = CalculateLineAmount(existingInvoice);
                existingInvoice = CalculateTotalAmount(existingInvoice);

                _invoiceDbContext.Entry(existingInvoice).State = EntityState.Modified;
                await _invoiceDbContext.SaveChangesAsync();
                return existingInvoice;
            }
        }

        private static Invoice CalculateLineAmount(Invoice invoice) 
        {
            if (invoice != null && invoice.InvoiceLines.Count > 0)
            {
                foreach (var invoiceLine in invoice.InvoiceLines)
                {
                    invoiceLine.LineAmount = invoiceLine.Quantity * invoiceLine.UnitPrice;
                }
            }
            return invoice;
        }

        private static Invoice CalculateTotalAmount(Invoice invoice)
        {
            if (invoice != null && invoice.InvoiceLines.Count > 0) {
                foreach (var invoiceLine in invoice.InvoiceLines) {
                    invoice.TotalAmount += invoiceLine.LineAmount;
                }
            }
            return invoice;
        }

        public async Task<ActionResult<List<Invoice>>> GetInovices()
        {
            if (_invoiceDbContext.Invoices == null) {
                throw new Exception("Invoices not found");
            }
            return await _invoiceDbContext.Invoices.ToListAsync();
        }
    }

}
