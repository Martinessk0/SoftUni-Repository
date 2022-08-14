using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.DTO;
using AutoMapper;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<PartDto, Part>();
            CreateMap<CustomerDto,Customer>();  
            CreateMap<SaleDto,Sale>();
        }
    }
}
