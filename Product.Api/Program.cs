
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Product.Api.Validator;
using Product.Application.Features.Command;
using Product.Application.Features.Query;
using Product.Application.Features.ViewModel;
using Product.Application.IoC;
using Product.Infrastructure.IoC;
using Product.Infrastructure.Persistence;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceRegistration();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product Management API",
        Description = "An Dotnet 6 Minimal API for managing Product items",
        Contact = new OpenApiContact
        {
            Name = "Serkan Ince",
        },
    });
});

builder.Services.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
builder.Services.AddScoped<IValidator<AddCategoryCommand>, AddCategoryValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Product Endpoint
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
app.MapGet("/product/query/category/{name}", async (string name, IMediator mediator) =>
{
    var query = new GetProductByCategoryQuery(name);

    return await mediator.Send(query);
}).Produces<IReadOnlyList<ProductVM>>(StatusCodes.Status200OK);
app.MapGet("/product/query/stock/{min}/{max}", async (int min,int max, IMediator mediator) =>
{
    var query = new GetProductByStockQuery(min, max);

    return await mediator.Send(query);
}).Produces<IReadOnlyList<ProductVM>>(StatusCodes.Status200OK);
app.MapGet("/product/query/{json}", async (string json, IMediator mediator) =>
{
    try
    {
        GetAllProductQuery query = JsonSerializer.Deserialize<GetAllProductQuery>(json);
        return Results.Ok(await mediator.Send(query));
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }

}).Produces<IReadOnlyList<ProductVM>>(StatusCodes.Status200OK);
app.MapPost("/product", async (AddProductCommand input, IMediator mediator, IValidator<AddProductCommand> validator) =>
{
    var validationResult = await validator.ValidateAsync(input);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }
    await mediator.Send(input);
    return Results.Ok();
});
#endregion

#region Category Endpoint
app.MapGet("/category", async (IMediator mediator) =>
{
    var query = new GetAllCategoryQuery();
    return await mediator.Send(query);
});
app.MapGet("/category/{id}", async (int id, IMediator mediator) =>
{
    var query = new GetCategoryQuery(id);

    return await mediator.Send(query);
});
app.MapPost("/category", async (AddCategoryCommand input, IMediator mediator, IValidator<AddCategoryCommand> validator) =>
{
    var validationResult = await validator.ValidateAsync(input);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }
    await mediator.Send(input);
    return Results.Ok();
});
#endregion

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

public partial class Program { }
