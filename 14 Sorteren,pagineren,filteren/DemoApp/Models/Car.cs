namespace DemoApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Tenant>? Tenant { get; set; }
    }
}