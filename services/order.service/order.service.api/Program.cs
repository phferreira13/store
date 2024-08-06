using MediatR;
using order.service.api.Ioc;
using order.service.business.UseCases.Orders;
using Microsoft.AspNetCore.OpenApi;
using order.service.api.Mock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AddOrderCommand).Assembly));

builder.Services.AddRepositories();
builder.Services.AddScoped<MockService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var mockService = scope.ServiceProvider.GetRequiredService<MockService>();
    mockService.SeedItems();
}

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
