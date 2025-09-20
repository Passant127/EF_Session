using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session.Entities
{
    public class Employee: BaseEntity
    {

        public string Name { get; set; } = "";
        public DateTime HireDate { get; set; } = DateTime.UtcNow; //default data
    }


    //SOLID 


    public class Manager: Employee
    {
        public decimal AnnualBonus { get; set; }
    }

    public class Contractor : Employee
    {
        public decimal HourlyRate { get; set; }
    }
}
