var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Tipicamente qui viene configurata la dependency injection
//AddService


var app = builder.Build();

// Configure the HTTP request pipeline.
//UseMethod

app.Run();
