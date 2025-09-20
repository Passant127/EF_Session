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
    public static class RelationshipsDemo
    {
        

        public static async Task RunAsync(Context db)
        {
            //Console.WriteLine("------------ RelationShip ------------------");


            //var display = new Tag { Name = "Display" };

            //db.Add(display);


            //var monitor = await db.Products.SingleAsync();

            //monitor.Tags.Add(display);

            //await db.SaveChangesAsync();


            var ProductTags = await db.Products/*.Include(c=>c.Tags)*/.ToListAsync();


            foreach (var p in ProductTags)
            {
                Console.WriteLine($"{p.Name} : Tag Name {p.Tags.Select(t => t.Name).FirstOrDefault()}");
            }





        }
    }
}
