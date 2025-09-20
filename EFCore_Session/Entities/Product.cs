using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{
    public class Product : BaseEntity
    {

        //Data Annotation
        [MaxLength(10)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Sku { get; set; } = string.Empty;

        [Precision(18,3)]
        public decimal Price { get; set; }


        public bool IsActive { get; set; }


        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }


    public class TopProducts
    {
        public decimal Price { get; set; }
        public int Id { get; set; }

    }
}

//SOLID => S => Single Responsibility

//O => Open Close 
