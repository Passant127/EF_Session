using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public int CustomerId { get; set; } //FK

        //One 
        public virtual Customer Customer { get; set; }


        //Many OrderItems
        public virtual ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
