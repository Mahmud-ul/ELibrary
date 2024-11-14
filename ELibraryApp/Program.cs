using ELibraryApp.Manager.Contract;
using ELibraryApp.Manager;
using ELibraryApp.Repository.Contract;
using ELibraryApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//AddTransient
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartManager, CartManager>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();

builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IImageManager, ImageManager>();

builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentManager, PaymentManager>();

builder.Services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddTransient<IPaymentMethodManager, PaymentMethodManager>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductManager, ProductManager>();

builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IRoleManager, RoleManager>();

builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<ISaleManager, SaleManager>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductManager, ProductManager>();

builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IPublisherManager, PublisherManager>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserManager, UserManager>();

builder.Services.AddTransient<IWriterRepository, WriterRepository>();
builder.Services.AddTransient<IWriterManager, WriterManager>();

//1. Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

//2. Session
app.UseSession();

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
