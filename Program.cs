using System.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RinhaBackend2024Q1;
using RinhaBackend2024Q1.Repositories;
using RinhaBackend2024Q1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new UnprocessableEntityObjectResult(context.ModelState);

            return result;
        };
    });;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
