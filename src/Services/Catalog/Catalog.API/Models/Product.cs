namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        //Con default! dico che la proprietà non è nullable, ma se non la inizializzo subito non deve darmi avvisi/errori
        //se scrivessi string? invece gli starei dicendo che la prop è nullable
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
