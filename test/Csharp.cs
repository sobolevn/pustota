using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Register services (if needed)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// In-memory student list to simulate a database
var students = new List<Student>
{
    new Student { Id = 1, Name = "John Doe", Age = 20 },
    new Student { Id = 2, Name = "Jane Smith", Age = 22 }
};

// Define endpoints
app.MapGet("/students", () =>
{
    return students;
});

app.MapGet("/students/{id}", (int id) =>
{
    var student = students.Find(s => s.Id == id);
    return student is not null ? Results.Ok(student) : Results.NotFound();
});

app.MapPost("/students", (Student student) =>
{
    student.Id = students.Count + 1; // Simple ID generation
    students.Add(student);
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPut("/students/{id}", (int id, Student updatedStudent) =>
{
    var student = students.Find(s => s.Id == id);
    if (student is null)
        return Results.NotFound();

    student.Name = updatedStudent.Name;
    student.Age = updatedStudent.Age;
    return Results.Ok(student);
});

app.MapDelete("/students/{id}", (int id) =>
{
    var student = students.Find(s => s.Id == id);
    if (student is null)
        return Results.NotFound();

    students.Remove(student);
    return Results.NoContent();
});

// Enable Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI();

app.Run();

// Student class to define student structure
public record Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
