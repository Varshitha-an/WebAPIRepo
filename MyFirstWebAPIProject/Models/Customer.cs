using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public bool IsOldCustomer { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Bill> Bills { get; set; }
    }
}
