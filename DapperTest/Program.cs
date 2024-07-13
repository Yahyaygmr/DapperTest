using DapperTest.Context;
using DapperTest.Services.Abstracts.Agent;
using DapperTest.Services.Abstracts.Category;
using DapperTest.Services.Abstracts.Estate;
using DapperTest.Services.Abstracts.Image;
using DapperTest.Services.Abstracts.Location;
using DapperTest.Services.Abstracts.Product;
using DapperTest.Services.Abstracts.Slider;
using DapperTest.Services.Abstracts.Statistics;
using DapperTest.Services.Abstracts.TagCloud;
using DapperTest.Services.Abstracts.Testimonial;
using DapperTest.Services.Concretes.Agent;
using DapperTest.Services.Concretes.Category;
using DapperTest.Services.Concretes.Estate;
using DapperTest.Services.Concretes.Image;
using DapperTest.Services.Concretes.Location;
using DapperTest.Services.Concretes.Product;
using DapperTest.Services.Concretes.Slider;
using DapperTest.Services.Concretes.Statistics;
using DapperTest.Services.Concretes.TagCloud;
using DapperTest.Services.Concretes.Testimonial;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IEstateService, EstateService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ITagCloudService, TagCloudService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseDeveloperExceptionPage(); //dikkat!!!!
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
