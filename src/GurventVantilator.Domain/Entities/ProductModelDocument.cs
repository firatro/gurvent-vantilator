namespace GurventVantilator.Domain.Entities
{
    public class ProductModelDocument
    {
        public int Id { get; set; }

        public int ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; }

        public string Title { get; set; }       // Doküman adı (DOKÜMAN 1 gibi)
        public string FilePath { get; set; }    // wwwroot path
    }
}
