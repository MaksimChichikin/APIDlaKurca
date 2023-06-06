using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Status
    {
        public Status()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
