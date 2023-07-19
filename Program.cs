using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Database; 
using StarWarsPlanets.Querys;
using StarWarsPlanets.Commands;
using StarWarsPlanets.Interfaces;
using StarWarsPlanets.Integrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StarWarsPlanetsDB>(opt => opt.UseInMemoryDatabase("StarWarsPlanets"));

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(IPlanetsRepository).Assembly);
});
builder.Services.AddTransient<IPlanetsRepository, PlanetsRepository>();
builder.Services.AddHttpClient();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}


var app = builder.Build();

// Get all of the planets from API
app.MapGet("/planets", async (IMediator mediator) =>
{
  try
  {
    return Results.Ok(await mediator.Send(new GetPlanetsQuery()));
  }
  catch (System.Exception ex)
  {
    throw new Exception($"Problem getting planets {ex.StackTrace}");
  }
});


// Get a list of favourited planets
app.MapGet("/planets/favourites", async (IMediator mediator) =>
{
  try
  {
    return Results.Ok(await mediator.Send(new GetFavsQuery()));
  }
  catch (System.Exception ex)
  {
    throw new Exception($"Problem getting favourite planets {ex.StackTrace}");
  }
});


// Get a single planet from favourite 
app.MapGet("/planets/favourites/{planetId}", async (IMediator mediator, [FromRoute] long planetId) =>
{
  try
  {
    return Results.Ok(await mediator.Send(new GetFavQuery(planetId)));
  }
  catch (System.Exception ex)
  {
    throw new Exception($"Problem getting favourite planet {ex.StackTrace}");
  }
});


// Add a planet to the favourites
app.MapPost("/planets/favourites/{planetId}", async (IMediator mediator, [FromRoute] int planetId ) =>
{
 try
  {
    return Results.Ok(await mediator.Send(new PostFavouriteCommand(planetId)));
  }
  catch (System.Exception ex)
  {
    throw new Exception($"Problem posting planets {ex.StackTrace}");
  }
});


// Remove planet from favourite
app.MapDelete("/planets/favourites/{planetId}", async (IMediator mediator, [FromRoute] long planetId) =>
{
  try
  {
    return Results.Ok(await mediator.Send(new DeleteFavouriteCommand(planetId)));
  }
  catch (System.Exception ex)
  {
    throw new Exception($"Problem deleting planets {ex.StackTrace}");
  }
});

app.Run();