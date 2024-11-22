using MediatR;
using order.service.api.Ioc;
using order.service.business.UseCases.Orders;
using Microsoft.AspNetCore.OpenApi;
using order.service.http.HttpClients;
using order.service.domain.Interfaces.HttpClients;
using order.service.entityframework.Bootstrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AddOrderCommand).Assembly));

builder.Services.AddRepositories();

builder.Services.AddHttpClient<IWarehouseHttpClient, WarehouseHttpClient>();

builder.Services.AddEntityFramework(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
