using AssignmentApi.Models;

namespace AssignmentApi.Dtos
{
    public class CreateInvoiceDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal? TotalAmount { get; set; }
        public List<CreateInvoiceLineDto> InvoiceLines { get; set; }
    }
}
