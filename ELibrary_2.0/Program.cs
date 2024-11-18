using ELibrary_2._0.Manager.Contract;
using ELibrary_2._0.Manager.Model;
using ELibrary_2._0.Repository.Contract;
using ELibrary_2._0.Repository.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartManager, CartManager>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();

builder.Services.AddTransient<ICoverRepository, CoverRepository>();
builder.Services.AddTransient<ICoverManager, CoverManager>();

builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IImageManager, ImageManager>();

builder.Services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddTransient<IPaymentMethodManager, PaymentMethodManager>();

builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
builder.Services.AddTransient<IPermissionManager, PermissionManager>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductManager, ProductManager>();

builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IPublisherManager, PublisherManager>();

builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<ISaleManager, SaleManager>();

builder.Services.AddTransient<ISoldProductRepository, SoldProductRepository>();
builder.Services.AddTransient<ISoldProductManager, SoldProductManager>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserManager, UserManager>();

builder.Services.AddTransient<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddTransient<IUserPermissionManager, UserPermissionManager>();

builder.Services.AddTransient<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddTransient<IUserTypeManager, UserTypeManager>();

builder.Services.AddTransient<IWriterRepository, WriterRepository>();
builder.Services.AddTransient<IWriterManager, WriterManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
