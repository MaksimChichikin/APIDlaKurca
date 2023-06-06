using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Task
    {
        public Task()
        {
            Alls = new HashSet<All>();
        }

        public int Id { get; set; }
        public int? IdOrder { get; set; }
        public int? IdDelivery { get; set; }

        public virtual Delivery? IdDeliveryNavigation { get; set; }
        public virtual Order? IdOrderNavigation { get; set; }
        public virtual ICollection<All> Alls { get; set; }
    }
}
