using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class Employer
    {
        public int Id { get; set; }
        public string TitleCode { get; set; }
        public string TitleDescription { get; set; }
        public string Troop { get; set; }
        public string Department { get; set; }
        public string SupervisorCoreId { get; set; }
        public int? FkCoreUserId { get; set; }

        public virtual CoreUser FkCoreUser { get; set; }
    }
}
