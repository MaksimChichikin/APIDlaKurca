using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class HistoryLog
    {
        public HistoryLog()
        {
            Alls = new HashSet<All>();
        }

        public int Id { get; set; }
        public int? IdUser { get; set; }
        public DateTime? UserLoginDate { get; set; }
        public int? LoginAttempt { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<All> Alls { get; set; }
    }
}
