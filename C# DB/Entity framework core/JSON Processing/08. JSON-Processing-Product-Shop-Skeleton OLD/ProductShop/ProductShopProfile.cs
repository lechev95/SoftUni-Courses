using AutoMapper;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Import
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //Export
            this.CreateMap<Product, ExportProductsInRangeDTO>()
                .ForMember(d => d.SellerFullName,
                mo =>
                mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //Task 6
            //Inner DTO
            this.CreateMap<Product, ExportSoldProductsDTO>()
                .ForMember(d => d.BuyerFirstName,
                mo =>
                mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName,
                mo =>
                mo.MapFrom(s => s.Buyer.LastName));
            //OuterDTO
            this.CreateMap<User, ExportUsersWithSoldProductsDTO>()
                .ForMember(d => d.SoldProducts,
                mo =>
                mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            //Task 7
            this.CreateMap<Category, ExportCategoryByProductCountDTO>()
                .ForMember(d => d.ProductsCount
                , mo =>
                mo.MapFrom(s => s.CategoryProducts.Count()))
                .ForMember(d => d.Category,
                mo =>
                mo.MapFrom(s => s.Name))
                .ForMember(d => d.AveragePrice,
                mo =>
                mo.MapFrom(s => $"{s.CategoryProducts.Select(av => av.Product.Price).Average():f2}"))
                .ForMember(d => d.TotalRevenue,
                mo =>
                mo.MapFrom(s => $"{s.CategoryProducts.Select(sum => sum.Product.Price).Sum():f2}"));

            //Task 8
            this.CreateMap<Product, ExportSingleProductDTO>();

            this.CreateMap<User, ExportSoldProductsForUserDTO>()
                .ForMember(d => d.Products,
                mo =>
                mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<User, ExportUsersDTO>()
                .ForMember(d => d.SoldProducts,
                mo =>
                mo.MapFrom(s => s));
        }
    }
}
