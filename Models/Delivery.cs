using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int? Valume { get; set; }
        public int? IdStatus { get; set; }

        public virtual Status? IdStatusNavigation { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
