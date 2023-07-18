using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Models;
using StarWarsPlanets.Database; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StarWarsPlanetsDB>(opt => opt.UseInMemoryDatabase("StarWarsPlanets"));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Enable detailed error page during development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}


var app = builder.Build();

// // Get all of the planets
// app.MapGet("/todoitems", async (TodoDb db) =>
//     await db.Todos.ToListAsync());


// // Get a list of favourited planets
// app.MapGet("/todoitems/complete", async (TodoDb db) =>
//     await db.Todos.Where(t => t.IsComplete).ToListAsync());



// // Add a planet to the favourites
// app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
// {
//     db.Todos.Add(todo);
//     await db.SaveChangesAsync();

//     return Results.Created($"/todoitems/{todo.Id}", todo);
// });


// // Remove planet from favourite
// app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
// {
//     if (await db.Todos.FindAsync(id) is Todo todo)
//     {
//         db.Todos.Remove(todo);
//         await db.SaveChangesAsync();
//         return Results.Ok(todo);
//     }

//     return Results.NotFound();
// });

app.Run();