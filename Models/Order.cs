using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class Order
    {
        public Order()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int? IdCompany { get; set; }
        public int? IdCatalog { get; set; }
        public int? NumberOfGoods { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Catalog? IdCatalogNavigation { get; set; }
        public virtual Company? IdCompanyNavigation { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
