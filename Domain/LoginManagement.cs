using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class LoginManagement
    {
        public int Id { get; set; }
        public int? NumberOfAllowedFailedAttempts { get; set; }
        public int? LockoutTimePeriodHours { get; set; }
        public int? PasswordRetentionCount { get; set; }
        public int? PasswordChangeFrequencyDays { get; set; }
    }
}
