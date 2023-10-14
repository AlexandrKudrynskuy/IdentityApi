using DLL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DLL
{
    public class Store_Identity_APIContext : IdentityDbContext<User>
    {
        public Store_Identity_APIContext(DbContextOptions<Store_Identity_APIContext> options) : base(options) {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(x => x.PasswordHash).IsRequired();
            builder.Entity<Card>().HasOne<Product>(x => x.Product).WithMany(x => x.Cards).HasForeignKey(x => x.ProductId);
            builder.Entity<Card>().HasOne<User>(x => x.User).WithMany(x => x.Cards).HasForeignKey(x => x.UserId);
            builder.Entity<Product>().HasOne<Brand>(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            builder.Entity<Product>().HasOne<Category>(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

            builder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "HP", Photo = "https://fixcenter.com.ua/content/uploads/images/serveryhp.png" });
            builder.Entity<Brand>().HasData(new Brand { Id = 2, Name = "Dell", Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Dell_logo_2016.svg/200px-Dell_logo_2016.svg.png" });
            builder.Entity<Brand>().HasData(new Brand { Id = 3, Name = "Samsung", Photo = "https://upload.wikimedia.org/wikipedia/uk/thumb/2/24/Samsung_Logo.svg/1280px-Samsung_Logo.svg.png" });

            builder.Entity<Category>().HasData(new Category { Id = 2, Name = "Laptops", Photo = "https://www.notebookcheck-ru.com/uploads/tx_nbc2/MicrosoftSurfaceLaptop3-15__1__02.JPG" });
            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "MFU", Photo = "https://images.prom.ua/3060125370_w640_h640_mfu-lazernoe-xerox.jpg" });
            builder.Entity<Category>().HasData(new Category { Id = 3, Name = "Displays", Photo = "https://www.lg.com/in/images/monitors/md07543925/gallery/27MP400-B-D-01.jpg" });
            builder.Entity<Category>().HasData(new Category { Id = 4, Name = "Speakers", Photo = "https://shop.sven.ua/image/cache/catalog/products-sven/acoustic_plast/sven_445_01-1200x800.png" });

            builder.Entity<Product>().HasData(new Product { Id = 1, BrandId = 1, CategoryId = 2, Price = 22200, Name = "L1", Photo = "https://klike.net/uploads/posts/2020-04/1586244741_1.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 2, BrandId = 2, CategoryId = 2, Price = 34400, Name = "L2", Count = 8, Photo = "https://klike.net/uploads/posts/2020-04/1586244779_2.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 3, BrandId = 3, CategoryId = 2, Price = 12200, Name = "L3", Count = 3, Photo = "https://klike.net/uploads/posts/2020-04/1586244761_4.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 4, BrandId = 2, CategoryId = 2, Price = 15600, Name = "L4", Count = 1, Photo = "https://klike.net/uploads/posts/2020-04/1586244770_7.jpg" });


            builder.Entity<Product>().HasData(new Product { Id = 5, BrandId = 1, CategoryId = 1, Price = 15600, Name = "P4", Count = 3, Photo = "https://content2.rozetka.com.ua/goods/images/big/327438507.png" });
            builder.Entity<Product>().HasData(new Product { Id = 6, BrandId = 3, CategoryId = 1, Price = 15600, Name = "P4", Count = 8, Photo = "https://cdn.27.ua/799/1f/3c/7996_2.jpeg" });
            builder.Entity<Product>().HasData(new Product { Id = 7, BrandId = 2, CategoryId = 1, Price = 15600, Name = "P4", Count = 3, Photo = "https://images.prom.ua/2937801366_mfu-a4-epson.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 8, BrandId = 1, CategoryId = 1, Price = 15600, Name = "P4", Count = 5, Photo = "https://images.prom.ua/2800565290_w640_h640_polnoe-reshenie-mfu.jpg" });

            builder.Entity<Product>().HasData(new Product { Id = 9, BrandId = 1, CategoryId = 3, Price = 4560, Name = "D1", Count = 3, Photo = "https://img.freepik.com/free-photo/computer_1205-717.jpg?1" });
            builder.Entity<Product>().HasData(new Product { Id = 10, BrandId = 2, CategoryId = 3, Price = 4860, Name = "D2", Count = 1, Photo = "https://st.depositphotos.com/1035837/1386/i/600/depositphotos_13861529-stock-photo-monitor.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 11, BrandId = 3, CategoryId = 3, Price = 4960, Name = "D3", Count = 2, Photo = "https://st.depositphotos.com/1035837/1386/i/600/depositphotos_13861529-stock-photo-monitor.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 12, BrandId = 1, CategoryId = 3, Price = 4560, Name = "D4", Count = 3, Photo = "https://images.unian.net/photos/2022_07/thumb_files/400_0_1656777669-2895.jpg?r=799803" });
            builder.Entity<Product>().HasData(new Product { Id = 13, BrandId = 1, CategoryId = 4, Price = 560, Name = "S4", Count = 3, Photo = "https://st2.depositphotos.com/1001877/5970/i/950/depositphotos_59701653-stock-photo-group-of-audio-speakers-loudspeakers.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 14, BrandId = 2, CategoryId = 4, Price = 230, Name = "S4", Count = 5, Photo = "https://assets.simant.com.ua/images/products/bigest/2559.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 15, BrandId = 3, CategoryId = 4, Price = 660, Name = "S4", Count = 2, Photo = "https://assets.simant.com.ua/images/products/bigest/2668.jpg" });
            builder.Entity<Product>().HasData(new Product { Id = 16, BrandId = 3, CategoryId = 4, Price = 860, Name = "S4", Count = 1, Photo = "https://assets.simant.com.ua/images/products/bigest/2614.jpg" });



            base.OnModelCreating(builder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }    
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
