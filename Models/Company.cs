using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Company
    {
        public Company()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
