using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("DB Reset successfully");

            //Task 9
            //string xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(dbContext, xml);
            //Console.WriteLine(result);

            //Task 10
            //string xml = File.ReadAllText("../../../Datasets/parts.xml");
            //string result = ImportParts(dbContext, xml);
            //Console.WriteLine(result);

            //Task 11
            //string xml = File.ReadAllText("../../../Datasets/cars.xml");
            //string result = ImportCars(dbContext, xml);
            //Console.WriteLine(result);

            //Task 12
            //string xml = File.ReadAllText("../../../Datasets/customers.xml");
            //string result = ImportCustomers(dbContext, xml);
            //Console.WriteLine(result);

            //Task 13
            //string xml = File.ReadAllText("../../../Datasets/sales.xml");
            //string result = ImportSales(dbContext, xml);
            //Console.WriteLine(result);

            //Task 14
            //string result = GetCarsWithDistance(dbContext);

            //Task 15
            //string result = GetCarsFromMakeBmw(dbContext);

            //Task 16
            //string result = GetLocalSuppliers(dbContext);

            //Task 17
            //string result = GetCarsWithTheirListOfParts(dbContext);

            //Task 18
            //string result = GetTotalSalesByCustomer(dbContext);

            //Task 19
            string result = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(result);
        }

        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string rootName = "Suppliers";
            ImportSuppliersDto[] suppliersDtos = Deserialize<ImportSuppliersDto[]>(inputXml, rootName);
            ICollection<Supplier> suppliers = new List<Supplier>();
            foreach (var dto in suppliersDtos)
            {
                Supplier supplier = new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                };
                suppliers.Add(supplier);
            }
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string rootName = "Parts";
            var suppliesIds = context.Suppliers.Select(x => x.Id).ToList();
            ImportPartsDto[] partsDtos = Deserialize<ImportPartsDto[]>(inputXml, rootName)
                .Where(p => suppliesIds.Contains(p.SupplierId))
                .ToArray();
                                ;
            ICollection<Part> parts = new List<Part>();
            foreach (var dto in partsDtos)
            {
                Part part = new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                };
                parts.Add(part);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string rootName = "Cars";
            ImportCarsDto[] carsDtos = Deserialize<ImportCarsDto[]>(inputXml, rootName);
            var cars = new List<Car>();
            foreach (var dto in carsDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                ICollection<PartCar> currCarPart = new List<PartCar>();
                foreach (int partId in dto.Parts.Select(p => p.Id).Distinct())
                {
                    if(!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }
                    currCarPart.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                car.PartCars = currCarPart;
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string rootName = "Customers";
            ImportCustomersDto[] customersDtos = Deserialize<ImportCustomersDto[]>(inputXml, rootName);
            ICollection<Customer> customers = new List<Customer>();
            foreach (var dto in customersDtos)
            {
                Customer customer = new Customer()
                {
                    Name = dto.Name,
                    BirthDate = DateTime.Parse(dto.BirthDate, CultureInfo.InvariantCulture),
                    IsYoungDriver = dto.IsYoungDriver
                };
                customers.Add(customer);
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string rootName = "Sales";
            ImportSalesDto[] salesDtos = Deserialize<ImportSalesDto[]>(inputXml, rootName);
            ICollection<Sale> sales = new List<Sale>();
            foreach (var dto in salesDtos)
            {
                if(!context.Cars.Any(c => c.Id == dto.CarId))
                {
                    continue;
                }
                Sale sale = new Sale()
                {
                    CarId = (int)dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }

        //Task 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportGetCarsWithDistance[] carsDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportGetCarsWithDistance
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            return Serialize(carsDtos, "cars");
        }

        //Task 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportGetCarsFromMakeBmw[] carsDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportGetCarsFromMakeBmw
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            return Serialize(carsDtos, "cars");
        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportGetLocalSuppliers[] suppliersDto = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportGetLocalSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return Serialize(suppliersDto, "suppliers");
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportGetCarsWithListOfTheirParts[] carsDtos = context
                .Cars
                .Select(c => new ExportGetCarsWithListOfTheirParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportListOfParts
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            return Serialize(carsDtos, "cars");
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportGetTotalSalesByCustomer[] customerDtos = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new ExportGetTotalSalesByCustomer
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(o => o.SpentMoney)
                .ToArray();

            return Serialize(customerDtos, "customers");
        }

        //Task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportCar[] saleDto = context
                .Sales
                .Select(s => new ExportCar
                {
                    Car = new ExportSaleCar
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWtihDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount/100))
                })
                .ToArray();

            return Serialize(saleDto, "sales");
        }

        //Helper to Deserialize Xml for imports only
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);
            return dtos;
        }

        //Helper to Serialize Xml - only for exports
        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}