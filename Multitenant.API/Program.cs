using Multitenant.Core.Interfaces;
using Multitenant.Core.Settings;
using Multitenant.Infrastructure.Services;
using Multitenant.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
var tenantSettings = config.GetSection(nameof(TenantSettings)).Get<TenantSettings>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.Configure<TenantSettings>(config.GetSection(nameof(TenantSettings)));
builder.Services.AddAndMigrateTenantDatabases(tenantSettings!);

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
