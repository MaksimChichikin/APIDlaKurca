using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string? BrandName { get; set; }
        public string? AddressBrand { get; set; }
        public string? PhoneBrand { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
