namespace Store_Identity_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();


    }
}
