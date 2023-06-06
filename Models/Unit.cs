using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
