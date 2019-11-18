using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class Contacts
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int? FkCoreUserId { get; set; }

        public virtual CoreUser FkCoreUser { get; set; }
    }
}
