using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Models;

namespace OrdersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PostalAddress> PostalAdresses { get; set; }
        public DbSet<PostalCodeRange> PostalCodeRanges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Category>(category =>
            // {
            //     // category.HasKey(p => p.ID);
            //     // category.Property(p => p.ID).ValueGeneratedOnAdd();
            //     category.Property(c => c.Name).IsRequired().HasMaxLength(30);
            //     category.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(c => c.CategoryID);
            // });

            // modelBuilder.Entity<Customer>(customer =>
            // {
            //     // customer.HasKey(c => c.ID);
            //     // customer.Property(c => c.ID).ValueGeneratedOnAdd();
            //     customer.Property(c => c.FullName).IsRequired();
            //     customer.Property(c => c.Document).IsRequired();
            //     customer.HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerID);
            //     customer.HasMany(c => c.Adresses).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerID);
            //     customer.HasMany(c => c.Phones).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerID);
            // });

            // modelBuilder.Entity<Order>(order =>
            // {
            //     // order.HasKey(o => o.ID);
            //     // order.Property(o => o.ID).ValueGeneratedOnAdd();
            //     order.Property(o => o.Date).IsRequired();
            //     order.Property(o => o.Number).IsRequired();
            //     order.Property(o => o.TotalPrice).IsRequired();
            //     order.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderID);
            // });

            // modelBuilder.Entity<OrderItem>(item =>
            // {
            //     // item.HasKey(i => i.ID);
            //     // item.Property(i => i.ID).ValueGeneratedOnAdd();
            //     item.Property(i => i.Quantity).IsRequired();
            //     item.Property(i => i.TotalPrice).IsRequired();
            //     item.HasOne(i => i.Product).WithMany().HasForeignKey(i => i.ProductID);
            // });

            // modelBuilder.Entity<Phone>(phone =>
            // {
            //     // phone.HasKey(p => p.ID);
            //     // phone.Property(p => p.ID).ValueGeneratedOnAdd();
            //     phone.Property(p => p.Number).IsRequired();
            // });

            // modelBuilder.Entity<PostalAddress>(address =>
            // {
            //     // address.HasKey(a => a.ID);
            //     // address.Property(a => a.ID).ValueGeneratedOnAdd();
            //     address.Property(a => a.Address).IsRequired();
            //     address.Property(a => a.PostalCode).IsRequired();
            //     address.Property(a => a.Neighborhood).IsRequired();
            //     address.Property(a => a.City).IsRequired();
            // });

            // modelBuilder.Entity<PostalCodeRange>(postalRange =>
            // {
            //     postalRange.Property(p => p.Price).IsRequired();
            //     postalRange.Property(p => p.Start).IsRequired();
            //     postalRange.Property(p => p.End).IsRequired();
            // });

            // modelBuilder.Entity<Product>(product =>
            // {
            //     product.Property(p => p.Description).IsRequired();
            //     product.Property(p => p.UnitPrice).IsRequired();
            // });

            // modelBuilder.Entity<State>(state =>
            // {
            //     state.HasMany(s => s.PostalCodeRanges).WithOne(r => r.State).HasForeignKey(r => r.StateID);
            // });

            SeeData(modelBuilder);
        }

        private void SeeData(ModelBuilder modelBuilder)
        {
            var states = new List<State>() {
                new State() { ID = 1,  FU = "AC", Name = "Acre"},
                new State() { ID = 2,  FU = "AL", Name = "Alagoas"},
                new State() { ID = 3,  FU = "AM", Name = "Amazonas"},
                new State() { ID = 4,  FU = "AP", Name = "Amapá"},
                new State() { ID = 5,  FU = "BA", Name = "Bahia"},
                new State() { ID = 6,  FU = "CE", Name = "Ceará"},
                new State() { ID = 7,  FU = "DF", Name = "Brasília"},
                new State() { ID = 8,  FU = "ES", Name = "Espírito Santo"},
                new State() { ID = 9,  FU = "GO", Name = "Goiás"},
                new State() { ID = 10, FU = "MA", Name = "Maranhão"},
                new State() { ID = 11, FU = "MG", Name = "Minas Gerais"},
                new State() { ID = 12, FU = "MS", Name = "Mato Grosso do Sul"},
                new State() { ID = 13, FU = "MT", Name = "Mato Grosso"},
                new State() { ID = 14, FU = "PA", Name = "Pará"},
                new State() { ID = 15, FU = "PB", Name = "Paraíba"},
                new State() { ID = 16, FU = "PE", Name = "Pernambuco"},
                new State() { ID = 17, FU = "PI", Name = "Piauí"},
                new State() { ID = 18, FU = "PR", Name = "Paraná"},
                new State() { ID = 19, FU = "RJ", Name = "Rio de Janeiro"},
                new State() { ID = 20, FU = "RN", Name = "Rio Grande do Norte"},
                new State() { ID = 21, FU = "RO", Name = "Rondônia"},
                new State() { ID = 22, FU = "RR", Name = "Roraima"},
                new State() { ID = 23, FU = "RS", Name = "Rio Grande do Sul"},
                new State() { ID = 24, FU = "SC", Name = "Santa Catarina"},
                new State() { ID = 25, FU = "SE", Name = "Sergipe"},
                new State() { ID = 26, FU = "SP", Name = "São Paulo"},
                new State() { ID = 27, FU = "TO", Name = "Tocantins"}
            };

            var postalCodeRanges = new List<PostalCodeRange>()
            {
                new PostalCodeRange() { StateID = 1,  ID = 1,  Start = "69900-000", End = "69999-999", Price = 62.75M },
                new PostalCodeRange() { StateID = 2,  ID = 2,  Start = "57000-000", End = "57999-999", Price =  5.21M },
                new PostalCodeRange() { StateID = 3,  ID = 3,  Start = "69000-000", End = "69299-999", Price = 53.74M },
                new PostalCodeRange() { StateID = 3,  ID = 4,  Start = "69400-000", End = "69899-999", Price = 53.74M },
                new PostalCodeRange() { StateID = 4,  ID = 5,  Start = "68900-000", End = "68999-999", Price = 44.12M },
                new PostalCodeRange() { StateID = 5,  ID = 6,  Start = "40000-000", End = "48999-999", Price = 24.36M },
                new PostalCodeRange() { StateID = 6,  ID = 7,  Start = "60000-000", End = "63999-999", Price = 33.52M },
                new PostalCodeRange() { StateID = 7,  ID = 8,  Start = "70000-000", End = "72799-999", Price = 19.54M },
                new PostalCodeRange() { StateID = 7,  ID = 9,  Start = "73000-000", End = "73699-999", Price = 19.54M },
                new PostalCodeRange() { StateID = 8,  ID = 10, Start = "29000-000", End = "29999-999", Price = 47.96M },
                new PostalCodeRange() { StateID = 9,  ID = 11, Start = "69300-000", End = "69399-999", Price = 19.89M },
                new PostalCodeRange() { StateID = 9,  ID = 12, Start = "73700-000", End = "76799-999", Price = 19.89M },
                new PostalCodeRange() { StateID = 10, ID = 13, Start = "65000-000", End = "65999-999", Price = 16.57M },
                new PostalCodeRange() { StateID = 11, ID = 14, Start = "30000-000", End = "39999-999", Price =  0.00M },
                new PostalCodeRange() { StateID = 12, ID = 15, Start = "79000-000", End = "79999-999", Price =  8.95M },
                new PostalCodeRange() { StateID = 13, ID = 16, Start = "78000-000", End = "78899-999", Price = 14.59M },
                new PostalCodeRange() { StateID = 14, ID = 17, Start = "66000-000", End = "68899-999", Price = 52.41M },
                new PostalCodeRange() { StateID = 15, ID = 18, Start = "58000-000", End = "58999-999", Price = 19.84M },
                new PostalCodeRange() { StateID = 16, ID = 19, Start = "50000-000", End = "56999-999", Price = 42.76M },
                new PostalCodeRange() { StateID = 17, ID = 20, Start = "64000-000", End = "64999-999", Price = 29.65M },
                new PostalCodeRange() { StateID = 18, ID = 21, Start = "80000-000", End = "87999-999", Price = 24.24M },
                new PostalCodeRange() { StateID = 19, ID = 22, Start = "20000-000", End = "28999-999", Price = 24.65M },
                new PostalCodeRange() { StateID = 20, ID = 23, Start = "59000-000", End = "59999-999", Price = 56.77M },
                new PostalCodeRange() { StateID = 21, ID = 24, Start = "76800-000", End = "76999-999", Price = 68.48M },
                new PostalCodeRange() { StateID = 21, ID = 25, Start = "78900-000", End = "78999-999", Price = 68.48M },
                new PostalCodeRange() { StateID = 22, ID = 26, Start = "69300-000", End = "69399-999", Price = 57.78M },
                new PostalCodeRange() { StateID = 23, ID = 27, Start = "90000-000", End = "99999-999", Price = 22.57M },
                new PostalCodeRange() { StateID = 24, ID = 28, Start = "88000-000", End = "89999-999", Price = 16.45M },
                new PostalCodeRange() { StateID = 25, ID = 29, Start = "49000-000", End = "49999-999", Price = 18.98M },
                new PostalCodeRange() { StateID = 26, ID = 30, Start = "01000-000", End = "19999-999", Price =  2.00M },
                new PostalCodeRange() { StateID = 27, ID = 31, Start = "77000-000", End = "77999-999", Price =  8.59M }
            };

            // var categories = new List<Category>()
            // {
            //     new Category() { ID = 1, Name = "Bebidas"},
            //     new Category() { ID = 2, Name = "Higiene"},
            //     new Category() { ID = 3, Name = "Cozinha"}
            // };

            // var products = new List<Product>()
            // {
            //     new Product() { ID = 1, CategoryID = 1, Description = "Coca Colca", UnitPrice = 6m },
            //     new Product() { ID = 2, CategoryID = 1, Description = "Kuat", UnitPrice = 5.45m },
            //     new Product() { ID = 3, CategoryID = 2, Description = "Sabonete", UnitPrice = 4.5m },
            //     new Product() { ID = 4, CategoryID = 2, Description = "Creme Dental", UnitPrice = 8.95m },
            //     new Product() { ID = 5, CategoryID = 2, Description = "Shampoo", UnitPrice = 10.3m },
            //     new Product() { ID = 6, CategoryID = 3, Description = "Detergente", UnitPrice = 1.4m },
            //     new Product() { ID = 7, CategoryID = 3, Description = "Bucha", UnitPrice = 4.6M },
            //     new Product() { ID = 8, CategoryID = 3, Description = "Sabão", UnitPrice = 2.3m },
            // };

            modelBuilder.Entity<State>().HasData(states);
            modelBuilder.Entity<PostalCodeRange>().HasData(postalCodeRanges);
            // modelBuilder.Entity<Category>().HasData(categories);
            // modelBuilder.Entity<Product>().HasData(products);
        }
    }
}