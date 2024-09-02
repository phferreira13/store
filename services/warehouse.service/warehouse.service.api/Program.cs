using warehouse.service.api.Ioc;
using warehouse.service.api.Mock;
using warehouse.service.business.UseCases.Items;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetItemsQuery).Assembly));


builder.Services.AddRepositories();
builder.Services.AddScoped<MockService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
//}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var mockService = scope.ServiceProvider.GetRequiredService<MockService>();
    mockService.SeedItems();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
