using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

// Add services for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();  // <-- Serve files from wwwroot
// Enable middleware
app.UseSwagger();
app.UseSwaggerUI();

// Redirect root to Swagger (nice default page)
app.MapGet("/", () => Results.Redirect("/index.html"));

// In-memory storage
var todos = new ConcurrentDictionary<int, TodoItem>();

// GET all todos
app.MapGet("/todos", () => todos.Values.ToList())
   .WithName("GetAllTodos");

// GET todo by ID
app.MapGet("/todos/{id}", (int id) =>
{
    return todos.TryGetValue(id, out var todo)
        ? Results.Ok(todo)
        : Results.NotFound();
})
   .WithName("GetTodoById");

// POST new todo
app.MapPost("/todos", (TodoItem newTodo) =>
{
    var id = todos.IsEmpty ? 1 : todos.Keys.Max() + 1;
    newTodo.Id = id;
    todos[id] = newTodo;
    return Results.Created($"/todos/{id}", newTodo);
})
   .WithName("CreateTodo");

// PUT update todo
app.MapPut("/todos/{id}", (int id, TodoItem updatedTodo) =>
{
    if (!todos.ContainsKey(id))
        return Results.NotFound();

    updatedTodo.Id = id;
    todos[id] = updatedTodo;
    return Results.NoContent();
})
   .WithName("UpdateTodo");

// DELETE todo
app.MapDelete("/todos/{id}", (int id) =>
{
    return todos.TryRemove(id, out _)
        ? Results.NoContent()
        : Results.NotFound();
})
   .WithName("DeleteTodo");

app.Run();

// Todo model
public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}