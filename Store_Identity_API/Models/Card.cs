namespace Store_Identity_API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId {  get; set; }

        public int ProductId {  get; set; }  
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
