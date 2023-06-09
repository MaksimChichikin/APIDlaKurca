using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class All
    {
        public int Id { get; set; }
        public int? IdTask { get; set; }
        public int? IdHistoryLog { get; set; }

        public virtual HistoryLog? IdHistoryLogNavigation { get; set; }
        public virtual Task? IdTaskNavigation { get; set; }
    }
}
