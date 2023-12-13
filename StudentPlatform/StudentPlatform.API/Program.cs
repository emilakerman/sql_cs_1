using Microsoft.EntityFrameworkCore;
using StudentPlatform.API.Data;
using StudentPlatform.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(
    options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPlatformConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// List<Student> presentStudents = [
//     new Student( "Emil", id: 0), 
//     new Student( "Arvid", id: 1),
//     new Student(name: "Joel", id: 2),
//     new Student(name: "Elin", id: 3),
//     ];
List<Teacher> teachers = [
    new Teacher(name: "Jens", id: 0),
];

// app.MapGet("/students", () => presentStudents);

app.MapGet("/teachers", () => teachers);

app.MapPost("/teachers", (string name) => new Teacher(name, id: 0));

// app.MapPost("/student", (string name) => {
//     using (Context context = new())
//     {
//         context.Courses.Add(new Course(name));
//         context.SaveChanges();
//     }
// });

// app.MapPatch("/teacher", (string updatedString) => new Student(updatedString));

// app.MapDelete("/teacher", (string name) => new Student(name));

app.Run();