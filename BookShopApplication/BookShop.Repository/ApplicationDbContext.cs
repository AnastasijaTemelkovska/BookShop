using BookShop.Domain.DomainModels;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<BookShopAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //generiranje novo Id pri sekoe dodavanje na zapis
            builder.Entity<Book>()
                  .Property(z => z.Id)
                  .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                  .Property(z => z.Id)
                  .ValueGeneratedOnAdd();


            //manytomany relacijata kluc
           /* builder.Entity<BookInShoppingCart>()
                .HasKey(z => new { z.BookId, z.ShoppingCartId });*/
            //relacii
            builder.Entity<BookInShoppingCart>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);
            builder.Entity<BookInShoppingCart>()
                 .HasOne(z => z.ShoppingCart)
                 .WithMany(z => z.BookInShoppingCarts)
                 .HasForeignKey(z => z.BookId);
            //OnetoOne
            builder.Entity<ShoppingCart>()
                .HasOne<BookShopAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            //Order
  /*          builder.Entity<BookInOrder>()
                .HasKey(z => new { z.BookId, z.OrderId });*/

            builder.Entity<BookInOrder>()
                .HasOne(z => z.SelectedBook)
                .WithMany(z => z.Orders)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.Books)
                .HasForeignKey(z => z.OrderId);


        }
    }
}
