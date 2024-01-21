namespace LiatrioPoC.Core.Entities
{
    public class Kata
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
