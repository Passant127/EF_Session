using EFCore_Session.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.ContextFile
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tag> Tags  { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles  { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address , a =>
            {
                a.Property(p => p.City).HasMaxLength(100);
                a.Property(p => p.Country).HasMaxLength(100);
            });


            modelBuilder.Entity<TopProducts>().HasNoKey();


            modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(10);
            modelBuilder.Entity<OrderItem>().Property(c => c.UnitPrice).HasPrecision(18,3);
            modelBuilder.Entity<OrderItem>().Property(c => c.Quantity).IsRequired();


            modelBuilder.Entity<Order>()
                            .HasOne(o => o.Customer)
                            .WithMany(c => c.Orders)
                            .HasForeignKey(o => o.CustomerId)
                            .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<Product>().HasIndex(c => c.Sku).IsUnique();



            //TPH => Table Per hierarchy , TPT => per Type => Customer => FullTime w partTime , TPC => Concrete
            modelBuilder.Entity<Employee>()
                        .HasDiscriminator<string>("EmployeeType")
                        .HasValue<Employee>("Employee")
                        .HasValue<Manager>("Mn")
                        .HasValue<Contractor>("Contrac");


            //Seeding data
            //modelBuilder.Entity<Product>().HasData(

            //    new Product { Id = 1, Sku = "P-100", Name = "Keyboard", Price = 300 },
            //    new Product { Id = 2, Sku = "P-200", Name = "Mouse", Price = 250 },
            //    new Product { Id = 3, Sku = "P-300", Name = "Monitor", Price = 400 }
            //    );



            //Alternate Key 
            modelBuilder.Entity<Product>().HasAlternateKey(p => p.Sku);

            //Shadow Property + index

            modelBuilder.Entity<Product>().Property<DateTime>("UpdatedAt");
            modelBuilder.Entity<Product>().HasIndex("UpdatedAt");



            // Convertor sku to upper case

            modelBuilder.Entity<Product>().Property(p=>p.Sku).HasConversion(to=>to.ToUpperInvariant(),from =>from);


            //M to M

            modelBuilder.Entity<Product>().HasMany(p => p.Tags).WithMany(t => t.Products);


            // one to one

            modelBuilder.Entity<Customer>()
                .HasOne<CustomerProfile>()
                .WithOne(c=>c.Customer)
                .HasForeignKey<CustomerProfile>(c=>c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


        }




    }
}
