
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
builder.Services.AddMarten(opts =>
{
    //richiede la configurazione della connessione al db. Configuro la stringa di connessione in appsettings.json
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
   // opts.AutoCreateSchemaObjects// -> si dice a Marten di creare automaticamente sul db le modifiche alo schema. Va bene per lo sviluppo, va disabilitato in prod
}).UseLightweightSessions(); //scelgo di usare questa Session, per questioni di performance


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

//UseMethod



app.Run();
