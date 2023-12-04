using AssignmentApi.Dtos;
using AssignmentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Services
{
    public interface IInvoiceService
    {
        Task<ActionResult<List<Invoice>>> GetInovices();
        Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice);
        Task<ActionResult<Invoice>> EditInvoice(int id, Invoice invoice);

    }
}
