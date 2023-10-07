using Microsoft.AspNetCore.Identity;

namespace Store_Identity_API.Models
{
    public class User:IdentityUser
    {
        public List<Card> Cards { get; set; }
    }
}
