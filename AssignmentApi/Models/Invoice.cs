

namespace AssignmentApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
