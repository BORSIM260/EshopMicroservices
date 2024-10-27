
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Tipicamente qui viene configurata la dependency injection
//AddService
builder.Services.AddCarter();
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    //così gli dico di scansionare tutta l'applicazione alla ricerca di tutti i Request Handlers (command e request)
    //(tutte le implementazioni di IRequestHandler)
    config.RegisterServicesFromAssembly(assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

//UseMethod



app.Run();
