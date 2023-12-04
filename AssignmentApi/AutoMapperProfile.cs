using AssignmentApi.Dtos;
using AssignmentApi.Models;
using AutoMapper;

namespace AssignmentApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Invoice, CreateInvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<InvoiceLine, CreateInvoiceLineDto>();
            CreateMap<CreateInvoiceLineDto, InvoiceLine>();
        }

    }
}
