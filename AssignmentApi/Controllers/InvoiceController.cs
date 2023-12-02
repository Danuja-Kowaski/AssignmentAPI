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

        [HttpPost]
        public async Task<ActionResult> AddInvoice([FromBody] Invoice inv) {
            return Ok(await _invoiceService.CreateInvoice(inv));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditInvoice(int id, [FromBody] Invoice invoice)
        {
            try
            {
                return Ok(await _invoiceService.EditInvoice(id, invoice));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
