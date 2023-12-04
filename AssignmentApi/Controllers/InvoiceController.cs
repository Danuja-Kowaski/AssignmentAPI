using AssignmentApi.Dtos;
using AssignmentApi.Models;
using AssignmentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("/invoices")]
        public async Task<ActionResult> GetInvoices()
        {
            try
            {
                return Ok(await _invoiceService.GetInovices());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddInvoice([FromBody] Invoice inv) {
            try
            {
                return Ok(await _invoiceService.CreateInvoice(inv));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditInvoice(int id, [FromBody] Invoice invoice)
        {
            try
            {
                return Ok(await _invoiceService.EditInvoice(id, invoice));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
