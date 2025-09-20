using EFCore_Session.ContextFile;
using EFCore_Session.Entities;
using EFCore_Session.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace EFCore_Session
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: false)
             .Build();

            var use = config.GetSection("EF")["Use"] ?? "sqlserver";
            var lazy = bool.TryParse(config.GetSection("EF")["LazyLoading"], out bool lz) && lz;

            var connectionString = config.GetConnectionString("Default");



            var options = new DbContextOptionsBuilder<Context>();
            if (use.Equals("sqlserver"))
                options.UseSqlServer(config.GetConnectionString("Default"));
            else
                options.UseSqlite(config.GetConnectionString("SqlLite"));



            if (lazy) options.UseLazyLoadingProxies();

            options.EnableSensitiveDataLogging();
            using var db = new Context(options.Options);
            //await db.Database.EnsureDeletedAsync(); //Delete => de mosebaaaaaaaaaaa
            await db.Database.EnsureCreatedAsync(); //Create
            //db.Database.Migrate();
            Console.WriteLine("Database Created");


            //EF vs ADO vs Dapper => Interview 


            //CRUD Operations 

            //var products = db.Products.AddAsync(new Product { Name = "Monitor", Price = 7000, Sku = "P-700", IsActive = true });
            //var tag = db.Tags.AddAsync(new Tag { Name = "BestSeller" });

            //await db.SaveChangesAsync();



            //await MappingDemos.RunAsync(db);
            //await RelationshipsDemo.RunAsync(db);


            //db.Employees.Add(new Manager { Name = "Ahmed", AnnualBonus = 50000 });
            //db.Employees.Add(new Contractor { Name = "Rodina", HourlyRate = 500 , HireDate = DateTime.Now });
            //db.Employees.Add(new Employee { Name = "Hassan" , HireDate = DateTime.UtcNow });
            //db.SaveChanges();


            //var emps =  db.Employees; // differed
            //var emps2 =  await db.Employees.ToListAsync(); //immediate 

            //foreach (var emp in emps)
            //{

            //    Console.WriteLine($"{emp.GetType().Name} : {emp.Name} ");

            //}


            //await LoadingDemos.RunAsync(db);


            //linq , SOLID , DesignPatterns , github 


            // LINQ ( LANGUAGE INTEGRATED QUERY) => Queries collection

            //Types => Linq ro object 
            // linq to entities => transalted to sql 
            // query vs method syntax
            //Operators 


            //db.Customers.Add(new Customer { Name = "Passant", Email = "p@gmail.com", Address = new Address { City = "Cairo", Country = "Egypt" }, IsDeleted = false });

            //db.Orders.Add(new Order { CustomerId = 3, OrderDate = DateTime.Now, OrderNumber = "ORD-2" });
            //db.OrderItems.Add(new OrderItem { OrderId = 4, ProductId = 1, Quantity = 5, UnitPrice = 90000 });
            //db.SaveChanges();



            //await LinqDemos.TaskAsync(db);



            //SOLID  not same as Design pattern

            // S => Single Responsibility
            // O => Open Close Principle
            // L => liskov  Substitution
            // I => Interface Segregation
            // D => Dependency Inversion


            //Sum => x * y



            // Liskov 

            // interface => IFlying 
            // Bird 
            // Penguin : Bird 

            // sparrow : bird , Iflying 





            //Interface Segregation  => a force to depend on interface i will not use

            // IInteface =>  Work , eat

            // Developer : IInteface


            // Dependency Inversion => Depend on Abstraction (interfaces) not Concrete  => To be Continued













            //MVC , APIS


        }
    }
}
