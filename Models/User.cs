using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class User
    {
        public User()
        {
            HistoryLogs = new HashSet<HistoryLog>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? IdUserActivity { get; set; }
        public int? IdRole { get; set; }
        public int? NumberOfLoginAttempts { get; set; }
        public DateTime? DateAdd { get; set; }
        public int? IdUserStatus { get; set; }
        public string? FullName { get; set; }
        public bool? IsFirstLogin { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual UserActivity? IdUserActivityNavigation { get; set; }
        public virtual UserStatus? IdUserStatusNavigation { get; set; }
        public virtual ICollection<HistoryLog> HistoryLogs { get; set; }
    }
}
