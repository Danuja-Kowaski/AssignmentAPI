using AssignmentApi.Models;
using System.ComponentModel.DataAnnotations;

namespace AssignmentApi.Dtos
{
    public class CreateInvoiceLineDto
    {
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public decimal LineAmount { get; set; }
        public int InvoiceId { get; set; }
    }
}
