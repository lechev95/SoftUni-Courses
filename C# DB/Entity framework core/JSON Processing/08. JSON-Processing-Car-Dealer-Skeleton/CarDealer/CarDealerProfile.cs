using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.CarParts;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customers;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Suppliers;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Task 9
            this.CreateMap<ImportSuppliersDto, Supplier>();
            //Task 10
            this.CreateMap<ImportPartsDto, Part>();
            //Task 11
            this.CreateMap<ImportCarsDto, Car>();
            //Task 12
            this.CreateMap<ImportCustomersDto, Customer>();
            //Task 13
            this.CreateMap<ImportSalesDto, Sale>();
            //Task 14 - Manual Map
            //Task 15 - Manual Map
            //Task 16 - Manual Map
            //Task 17
            this.CreateMap<Car, GetCarsWithTheirListOfPartsDto>()
                .ForMember(d => d.Car, 
                mo => 
                mo.MapFrom(s => new ExportCarsDto
                {
                    Make = s.Make,
                    Model = s.Model,
                    TravelledDistance = s.TravelledDistance
                }))
                .ForMember(d => d.Parts, 
                mo 
                => mo.MapFrom(s => s.PartCars
                .Select(pc => new ExportPartsDto
                {
                    Name = pc.Part.Name,
                    Price = pc.Part.Price.ToString("f2")
                })
                .ToArray()));

            //Task 18 - Manual Map
        }
    }
}
