﻿using System;
using System.Collections.Generic;

namespace Lerkorin.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
