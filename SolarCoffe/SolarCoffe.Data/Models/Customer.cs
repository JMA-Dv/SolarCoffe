using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Data.Models
{
    public class Customer:BaseClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
    }
}
