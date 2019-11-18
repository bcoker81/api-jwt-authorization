using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class Le
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string OfficialDomicile { get; set; }
        public int? FkCoreUserId { get; set; }

        public virtual CoreUser FkCoreUser { get; set; }
    }
}
