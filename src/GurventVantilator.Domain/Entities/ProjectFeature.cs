namespace GurventVantilator.Domain.Entities
{
    public class ProjectFeature
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }    
        public Project Project { get; set; }
    }
}
