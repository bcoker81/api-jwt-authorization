using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class Supplemental
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int? FkCoreUserId { get; set; }

        public virtual CoreUser FkCoreUser { get; set; }
    }
}
