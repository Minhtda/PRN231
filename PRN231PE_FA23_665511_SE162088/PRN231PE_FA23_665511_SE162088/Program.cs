using BussinessLogic.IService;
using BussinessLogic.Service;
using Enities.IRepository;
using Enities.Models;
using Enities.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SilverJewelry2023DbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DBSQL")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PE_SE162088", Version = "v1" });
    
});
builder.Services.AddScoped<IBranchAccountRepository, BranchAccountRepository>();
builder.Services.AddScoped<IBranchAccountService, BranchAccountService>();
builder.Services.AddScoped<IJewelryService, JewelryService>();
builder.Services.AddScoped<IJewelryReposioty, JewelryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
