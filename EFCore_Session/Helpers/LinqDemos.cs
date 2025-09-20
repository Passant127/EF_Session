using EFCore_Session.ContextFile;
using EFCore_Session.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Helpers
{
    public static class LinqDemos
    {

        public static async Task TaskAsync(Context db)
        {

            // products , price > 100 , order by descending , name ,  price


            //Anonymous new {} => class not implemented 

            //var query1 = await db.Products.Where(p=>p.Price > 100)
            //                                .OrderByDescending(p=>p.Price)
            //                                .Select(p=> new {p.Name , p.Price}).ToListAsync();

            //query1.ForEach(x=> Console.WriteLine($"{x.Name} :s {x.Price}"));



            //Console.WriteLine("--------------------------------------------------------------------------------------");




            //// inner join 

            //var query2 =  await db.Orders.Join(db.Customers,o => o.CustomerId , c=>c.Id , (o,c) => new {o.OrderNumber , c.Name}).ToListAsync();
            ////Console.WriteLine(query1.Single());





            //var join2 = await db.Orders.Where(c => c.CustomerId == c.Customer.Id)
            //                                                    .Select(c=> new {c.OrderNumber , c.Customer.Name})
            //                                                    .ToListAsync();


            //query2.ForEach(x => Console.WriteLine($"{x.Name} : {x.OrderNumber}"));





            //Console.WriteLine("--------------------------------------------------------------------------------------");
            //join2.ForEach(x => Console.WriteLine($"{x.Name} : {x.OrderNumber}"));


            //// left join 


            //var totals = await db.Orders.SelectMany(o=>o.orderItems , (o,i) => new { o.CustomerId  , Q = i.Quantity * i.UnitPrice})
            //    .GroupBy(x=>x.CustomerId)
            //    .Select(g=> new { CustomerId = g.Key , Total = g.Sum(z=>z.Q)})
            //    .ToListAsync();



            //totals.ForEach(x => Console.WriteLine($"{x.CustomerId} : {x.Total}"));


            //// skip, take 

            //var q = db.Products.Where(p => p.Price > 100).OrderBy(p => p.Name);
            //Console.WriteLine(q.ToQueryString());




            //Tracking vs no tracking 

            //var p = await db.Products.FirstAsync(); 

            //p.Price += 10; //effect

            //await db.SaveChangesAsync();



            //var p2 = await db.Products.AsNoTracking().FirstAsync(); // w2at tracking => get

            //p2.Price += 10; //no effect

            //await db.SaveChangesAsync();



            // raw sql => complex queries ?????


            //var products = await db.Products.FromSqlInterpolated($" SELECT * FROM Products Where Price >= {100}")
            //    .AsNoTracking()
            //    .FirstAsync();
            //Console.WriteLine(products.Sku);
            //Console.WriteLine(products.Name);




            //var top = await db.Set<Product>().FromSqlInterpolated($"Exec dbo.getTopTenProducts").ToListAsync();         
            //var top = await db.Set<TopProducts>().FromSqlInterpolated($"Exec dbo.getTopTenProducts").ToListAsync();

            //top.ForEach(x => Console.WriteLine($"{x.Id} : {x.Price}"));

            //logs => time 

            //performance 








        }
    }
}
