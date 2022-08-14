using AutoMapper;
using CarDealer.Dto.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<PartImportDto, Part>();
            CreateMap<CarImportDto, Car>();
            CreateMap<CustomerImportDto, Customer>();
            CreateMap<SaleImportDto, Sale>();
        }
    }
}
