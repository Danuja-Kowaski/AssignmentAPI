using System.ComponentModel.DataAnnotations;

namespace AssignmentApi.Models
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public decimal LineAmount => UnitPrice * Quantity;
    }
}
