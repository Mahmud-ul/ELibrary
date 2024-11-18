using AutoMapper;
using ELibrary_2._0.Model.ProductModels;
using ELibrary_2._0.Model.SaleModels;
using ELibrary_2._0.Model.UserModels;
using ELibrary_2._0.Models.ProducViewModels;
using ELibrary_2._0.Models.SaleViewModels;
using ELibrary_2._0.Models.UserViewModels;

namespace ELibrary_2._0.Utility
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Cart, CartViewModel>();
            CreateMap<CartViewModel, Cart>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Cover, CoverViewModel>();
            CreateMap<CoverViewModel, Cover>();

            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>();

            CreateMap<PaymentMethod, PaymentMethodViewModel>();
            CreateMap<PaymentMethodViewModel, PaymentMethod>();

            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<PublisherViewModel, Publisher>();

            CreateMap<Sale, SaleViewModel>();
            CreateMap<SaleViewModel, Sale>();

            CreateMap<SoldProduct, SoldProductViewModel>();
            CreateMap<SoldProductViewModel, SoldProduct>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<UserPermission, UserPermissionViewModel>();
            CreateMap<UserPermissionViewModel, UserPermission>();

            CreateMap<UserType, UserTypeViewModel>();
            CreateMap<UserTypeViewModel, UserType>();

            CreateMap<Writer, WriterViewModel>();
            CreateMap<WriterViewModel, Writer>();
        }
    }
}
