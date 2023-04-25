using Microsoft.Extensions.Options;
using TourAgencyAPIMongodb.Config;
using TourAgencyAPIMongodb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration Singleton and AppSettings paramaters.
builder.Services.Configure<TourAgencySettings>(builder.Configuration.GetSection("TourAgencySettings"));
builder.Services.AddSingleton<ITourAgencySettings>(s => s.GetRequiredService<IOptions<TourAgencySettings>>().Value);
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<CityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
