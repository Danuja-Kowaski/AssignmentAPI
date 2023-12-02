

namespace AssignmentApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal? TotalAmount
        {
            get
            {
                return InvoiceLines?.Sum(line => line.LineAmount);
            }
        }

        public List<InvoiceLine>? InvoiceLines { get; set; }
    }
}
