using Warehouse;
using Warehouse.Repositories;
using Warehouse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IVoivodeshipRepository, VoivodeshipRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IReturnReasonRepository, ReturnReasonRepository>();

builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IVoivodeshipService, VoivodeshipService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IReturnReasonService, ReturnReasonService>();


builder.Services.AddDbContext<WarehouseDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();



app.UseAuthorization();

app.MapControllers();

app.Run();
