using AutoMapper;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;

namespace ELibraryApp.Utility
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Cart, CartViewModel>();
            CreateMap<CartViewModel, Cart>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>();

            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PaymentViewModel, Payment>();

            CreateMap<PaymentMethod, PaymentMethodViewModel>();
            CreateMap<PaymentMethodViewModel, PaymentMethod>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<PublisherViewModel, Publisher>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();

            CreateMap<Sale, SaleViewModel>();
            CreateMap<SaleViewModel, Sale>();

            CreateMap<SaleProduct, SaleProductViewModel>();
            CreateMap<SaleProductViewModel, SaleProduct>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Writer, WriterViewModel>();
            CreateMap<WriterViewModel, Writer>();
        }
    }
}
