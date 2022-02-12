global using WebAPI.Data;
using WebAPI.Services.PortfolioService;
using Microsoft.EntityFrameworkCore;

const string policyName = "AllowAll";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();



// Add new policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName,
    builder =>
    {
        // builder.WithOrigins("https://localhost:7217/");
        // builder.WithMethods("GET, POST");
        // builder.WithHeaders("Content-Type, Accept, Host");

        builder
        .AllowAnyOrigin()
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(policyName);

app.Run();
