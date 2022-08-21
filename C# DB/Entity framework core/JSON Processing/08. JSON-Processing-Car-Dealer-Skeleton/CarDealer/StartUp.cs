using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.CarParts;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customers;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Suppliers;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));
            CarDealerContext dbContext = new CarDealerContext();

            //Generating DB
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("DB copy created");

            //Task 9
            //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string output = ImportSuppliers(dbContext, inputJson);
            //Console.WriteLine(output);

            //Task 10
            //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
            //string output = ImportParts(dbContext, inputJson);
            //Console.WriteLine(output);

            //Task 11
            //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
            //string output = ImportCars(dbContext, inputJson);
            //Console.WriteLine(output);

            ////Task 12
            //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
            //string output = ImportCustomers(dbContext, inputJson);
            //Console.WriteLine(output);

            //Task 13
            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //string output = ImportSales(dbContext, inputJson);
            //Console.WriteLine(output);

            //Task 14
            //string output = GetOrderedCustomers(dbContext);
            //File.WriteAllText("../../../ExportResults/ordered-customers.json", output);

            //Task 15
            //string output = GetCarsFromMakeToyota(dbContext);
            //File.WriteAllText("../../../ExportResults/toyota-cars.json", output);

            //Task 16
            //string output = GetLocalSuppliers(dbContext);
            //File.WriteAllText("../../../ExportResults/local-suppliers.json", output);

            //Task 17
            //string output = GetCarsWithTheirListOfParts(dbContext);
            //File.WriteAllText("../../../ExportResults/cars-and-parts.json", output);

            //Task 18
            //string output = GetTotalSalesByCustomer(dbContext);
            //File.WriteAllText("../../../ExportResults/customers-total-sales.json", output);

            //Task 19
            string output = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText("../../../ExportResults/sales-discounts.json", output);
        }

        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSuppliersDto[] isDtos = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);
            ICollection<Supplier> suppliers = new List<Supplier>();

            foreach (var isDto in isDtos)
            {
                Supplier supplier = Mapper.Map<Supplier>(isDto);
                suppliers.Add(supplier);
            }

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliesIds = context.Suppliers.Select(x => x.Id).ToList();
            ImportPartsDto[] ipDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson)
                .Where(p => suppliesIds.Contains(p.SupplierId.Value))
                .ToArray();
            ICollection<Part> parts = new List<Part>();
            foreach (var ipDto in ipDtos)
            {
                Part part = Mapper.Map<Part>(ipDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarsDto[] carDtos = JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson);
            List<Car> cars = new List<Car>();
            foreach (var cDto in carDtos)
            {
                if (cDto == null)
                {
                    continue;
                }
                Car car = Mapper.Map<Car>(cDto);
                foreach (var partId in cDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar
                    {
                        Car = car,
                        PartId = partId
                    };
                    car.PartCars.Add(partCar);
                }
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomersDto[] importCustomersDto = JsonConvert.DeserializeObject<ImportCustomersDto[]>(inputJson);
            ICollection<Customer> customers = new List<Customer>();
            foreach (var icDto in importCustomersDto)
            {
                if(icDto == null)
                {
                    continue;
                }
                Customer customer = Mapper.Map<Customer>(icDto);
                customers.Add(customer);
            }

            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}.";
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSalesDto[] importSalesDtos = JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson);
            ICollection<Sale> sales = new List<Sale>();

            foreach (var isDtos in importSalesDtos)
            {
                if(isDtos == null)
                {
                    continue;
                }
                Sale sale = Mapper.Map<Sale>(isDtos);
                sales.Add(sale);
            }

            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}.";
        }

        //Task 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            ExportGetOrderedCustomers[] customers = context
                .Customers
                .OrderBy(o => o.BirthDate)
                .ThenBy(o => o.IsYoungDriver)
                .Select(c => new ExportGetOrderedCustomers
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        //Task 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            GetCarsFromMakeToyotaDto[] toyotaDtos = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new GetCarsFromMakeToyotaDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(toyotaDtos, Formatting.Indented);
            return json;
        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportGetLocalSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return json;
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            GetCarsWithTheirListOfPartsDto[] carsWithTheirListOfPartsDtos = context
                .Cars
                //.Select(c => new GetCarsWithTheirListOfPartsDto
                //{
                //    Car = (ExportCarsDto)c.PartCars.Select(pc => new ExportCarsDto
                //    {
                //        Make = pc.Car.Make,
                //        Model = pc.Car.Model,
                //        TravelledDistance = pc.Car.TravelledDistance
                //    }),
                //    Parts = (ExportPartsDto[])c.PartCars.Select(pp => new ExportPartsDto
                //    {
                //        Name = pp.Part.Name,
                //        Price = pp.Part.Price.ToString("f2")
                //    })
                    
                //})
                .ProjectTo<GetCarsWithTheirListOfPartsDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(carsWithTheirListOfPartsDtos, Formatting.Indented);
            return json;
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                //.OrderByDescending(c => c.Sales.SelectMany(sc => sc.Car.PartCars).Sum(pc => pc.Part.Price))
                //.ThenByDescending(c => c.Sales.Count)
                .Select(c => new GetTotalSalesByCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(sc => sc.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(o => o.SpentMoney)
                .ThenByDescending(o => o.BoughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);
            return json;
        }

        //Task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context
                .Sales
                .Take(10)
                .ToArray()
                .Select(s => new GetSalesWithAppliedDiscountDto()
                {
                    Car = new ExportCarsDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    Price = s.Car.PartCars
                    .Select(pc => pc.Part.Price)
                    .DefaultIfEmpty(0)
                    .Sum()
                    .ToString("F2"),
                    PriceWithDiscount = (s.Car.PartCars
                    .Select(pc => pc.Part.Price)
                    .Sum() - (s.Car.PartCars.Select(pc => pc.Part.Price).Sum() *(s.Discount/100))).ToString("f2")
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
            return json;
        }
    }
}