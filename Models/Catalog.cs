using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int IdUnit { get; set; }
        public decimal? Price { get; set; }
        public string? NameOfProduct { get; set; }
        public int? IdBrand { get; set; }

        public virtual Brand? IdBrandNavigation { get; set; }
        public virtual Unit IdUnitNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
