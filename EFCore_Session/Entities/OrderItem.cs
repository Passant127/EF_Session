using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{

    //class diagram 
    public class OrderItem : BaseEntity
    {
        public int ProductId  { get; set; } //Foreign Key 
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }


        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
