
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Application.Features.Query;
using Product.Application.IoC;
using Product.Infrastructure.IoC;
using Product.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceRegistration();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/product", async (IMediator mediator) =>
{
    var query = new GetAllProductQuery();
    return await mediator.Send(query);
});
app.MapGet("/product/{id}", async (int id, IMediator mediator) =>
{
    var query = new GetProductQuery(id);
    return await mediator.Send(query);
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductDBContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
