

namespace Catalog.API.Products.CreateProduct
{
    //Sono uguali ai record che si trovano in CommandProductHandler (quasi)
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid Id);

    //CARTER -> x migliorare la gestione degli endpoints delle api's
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //ISender è un oggetto di MediatR
            //Passo l'oggetto da creare come Request
            app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
            {
                //Adapt è un oggetto di Mapster
                //All'handler poi serve un oggetto di tipo CreateProductCommand
                var command = request.Adapt<CreateProductCommand>();

                //Faccio la chiamata
                var result = await sender.Send(command);

                //Recupero la response
                var response = result.Adapt<CreateProductResponse>();

                //Chiamerò poi un altro handler per restituire l'oggetto creato
                //(la chiamata di creazione restituisce solo il Guid
                return Results.Created($"/products/{response.Id}", response);

            })
        .WithName("CreateProduct") //nome del POST method
        .Produces<CreateProductResponse>(StatusCodes.Status201Created) //Cosa restituisce
        .ProducesProblem(StatusCodes.Status400BadRequest) //Cosa succede se la chiamata va in errore
        .WithSummary("Create Product") //Descrizione e summary del metodo
        .WithDescription("Create Product");
        }
    }
}
