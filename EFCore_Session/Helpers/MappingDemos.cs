using EFCore_Session.ContextFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Helpers
{
    public static class MappingDemos
    {
        public static async Task RunAsync(Context context)
        {
            Console.WriteLine(" -------------------- Mapping Demos ---------------------------- ");

            var product  = await context.Products.FirstAsync();
            context.Entry(product).Property("UpdatedAt").CurrentValue = DateTime.Now;
            await context.SaveChangesAsync();


            var updatedAt = context.Entry(product).Property("UpdatedAt").CurrentValue;
            Console.WriteLine($"Product Updated At : {updatedAt}");



        }
    }
}
