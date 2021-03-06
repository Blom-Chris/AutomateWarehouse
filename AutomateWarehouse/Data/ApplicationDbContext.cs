using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<OrderLine>().HasOne(o => o.Product);
      modelBuilder.Entity<OrderLine>().HasOne(o => o.Order);
      //modelBuilder.Entity<Order>().HasMany(o => o.Items);
      modelBuilder.Entity<Order>().HasOne(o => o.Customer);
      modelBuilder.Entity<Customer>().HasMany(o => o.Orders);

      modelBuilder.Entity<Customer>().HasData(GetCustomers());
      modelBuilder.Entity<Product>().HasData(GetProducts());
      modelBuilder.Entity<Order>().HasData(GetOrders());
      modelBuilder.Entity<OrderLine>().HasData(GetOrderLines());

      base.OnModelCreating(modelBuilder);
    }

    private static List<Customer> GetCustomers()
    {
      return new List<Customer>
      {
      new Customer { Id =901204 , Name ="Ano Nym", Phone ="0705555555", Email ="ano@gmail.com"},
      new Customer { Id =880417 , Name ="Test Testsson", Phone ="0704444444", Email ="t.test@outlook.com"}
      };
    }
    private static List<Product> GetProducts()
    {
      return new List<Product>
      { 
        new Product { Id = 1, Name = "Cake", Price = 12.46, Stock = 10, Description = "The cake is a lie" },
        new Product { Id = 2, Name = "A blue pen", Price = 5.99, Stock = 50, Description ="It ’s a bluepen" },
    };
    }
    private static List<Order> GetOrders()
    {
      return new List<Order>
      { 
        new Order { Id = 991, CustomerId = GetCustomers()[0].Id , DeliveryAddress= "Hamngatan 3", Dispatched = false, OrderDate = DateTime.Now.Date, PaymentCompleted = false }
    };
    }
    private static List<OrderLine> GetOrderLines()
    {
      return new List<OrderLine>
      { 
        new OrderLine { Id = 1234, Quantity = 3, ProductId = GetProducts()[0].Id , OrderId = GetOrders()[0].Id }
      };
    }
  }
}
