
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;          
    public record CreateProductResult(Guid Id);

    public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //1.create Product entity from command object
            //2.save to database
            //3.return CreateProductResult result               

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //save to database
            //session.Store(product);
            //await session.SaveChangesAsync(cancellationToken);

            //return result
            return new CreateProductResult(product.Id);
        }
    }
}
