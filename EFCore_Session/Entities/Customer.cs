using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{
    public class Customer : BaseEntity
    {
  
        public string Name { get; set; }
        public string Email  { get; set; }

        //Navigation property (one Address per customer)
        public Address Address { get; set; }


        public bool IsDeleted { get; set; }


        // collection orders (customer has many orders)
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
