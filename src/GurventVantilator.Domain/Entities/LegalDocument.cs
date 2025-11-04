namespace GurventVantilator.Domain.Entities
{
    public class LegalDocument
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ContentHtml { get; set; } = null!;
    }
}
