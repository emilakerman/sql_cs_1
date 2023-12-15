using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using StudentPlatform.API.Data;
using StudentPlatform.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<Context>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/teacher", (Context context) => context.Teachers.ToList());

app.MapPost("/teacher", (Context context, string name) =>
{
    Teacher teacher = new Teacher(name);
    context.Teachers.Add(teacher);
    context.SaveChanges();
});

// app.MapPatch("/teacher", (string updatedString) => new Student(updatedString));

// app.MapDelete("/teacher", (string name) => new Student(name));

app.Run();

