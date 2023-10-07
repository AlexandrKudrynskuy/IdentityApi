using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store_Identity_API.Models;

namespace Store_Identity_API.Context
{
    public class Store_Identity_APIContext:IdentityDbContext
    {
        public Store_Identity_APIContext(DbContextOptions<Store_Identity_APIContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>().HasOne<Product>(x => x.Product).WithMany(x => x.Cards).HasForeignKey(x => x.ProductId);
            builder.Entity<Card>().HasOne<User>(x => x.User).WithMany(x => x.Cards).HasForeignKey(x =>x.UserId);

            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards {  get; set; }    
    }
}
