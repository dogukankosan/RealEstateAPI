using RealEstate_API.Models.DapperContext;
using RealEstate_API.Repositories.AboutRepositories;
using RealEstate_API.Repositories.BottomGridRepositories;
using RealEstate_API.Repositories.CategoryRepositories;
using RealEstate_API.Repositories.EmployeeRepositories;
using RealEstate_API.Repositories.PopulerLocationRepositories;
using RealEstate_API.Repositories.ProductRepositories;
using RealEstate_API.Repositories.ProductRepository;
using RealEstate_API.Repositories.SubFeatureRepositories;
using RealEstate_API.Repositories.TestimonialRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IPopulerLocationRepository, PopulerLocationRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IAboutRepository, AboutRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();