using AssignmentApi.Models;
using AssignmentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoiceService;
        public InvoiceController(IInvoice invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async IActionResult AddInvoice(Invoice inv) {
            return Ok(await _invoiceService.CreateInvoice(inv));
        }

        [HttpPut("{id:guid}")]
        public IActionResult EditInvoice() {
            return Ok();
        }

    }
}
