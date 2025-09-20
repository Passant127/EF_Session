using EFCore_Session.ContextFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Helpers
{
    public static class LoadingDemos
    {
        public static async Task RunAsync(Context context) ///Interview question
        {
            Console.WriteLine(" -------------------- Loading Demos ---------------------------- ");

            //Eager Loading  => include keyword + fewer roundtrips 

            //var eager = await context.Products.Include(c=>c.Tags).ToListAsync();
            //Console.WriteLine(eager.Count);



            //// Explicit  => manual load 


            //var product = await context.Products.FirstOrDefaultAsync();
            //if (product != null)
            //{
            //    //await context.Entry(product).Reference(p=>p.Tags).LoadAsync(); //one relation
            //    await context.Entry(product).Collection(p => p.Tags).LoadAsync();


            //}



            //Lazy loading 
            var products = await context.Products.FirstOrDefaultAsync();

            Console.WriteLine($"{products.Tags.Select(s=>s.Name).FirstOrDefault()}"); // n+1







        }
    }
}
