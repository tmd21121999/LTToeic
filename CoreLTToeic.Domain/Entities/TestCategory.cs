namespace CoreLTToeic.Domain.Entities
{
    public class TestCategory
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}
