using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{
    public class Tag :BaseEntity
    {
        public string Name { get; set; }
        public  virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
