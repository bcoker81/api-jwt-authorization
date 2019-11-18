using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class Account
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public bool? EmailVerified { get; set; }
        public bool? AccountActive { get; set; }
        public DateTime? InactiveDate { get; set; }
        public bool? AccountLocked { get; set; }
        public DateTime? AccountLockoutDate { get; set; }
        public int? AccountFailedCount { get; set; }
        public int? FkCoreUserId { get; set; }

        public virtual CoreUser FkCoreUser { get; set; }
    }
}
