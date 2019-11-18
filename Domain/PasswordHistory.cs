using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class PasswordHistory
    {
        public int Id { get; set; }
        public int FkCoreUserId { get; set; }
        public string Password { get; set; }
        public DateTime PasswordDate { get; set; }
    }
}
