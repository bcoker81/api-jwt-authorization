using System;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Domain
{
    public partial class CoreUser
    {
        public CoreUser()
        {
            Account = new HashSet<Account>();
            Contacts = new HashSet<Contacts>();
            Employer = new HashSet<Employer>();
            Le = new HashSet<Le>();
            Supplemental = new HashSet<Supplemental>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Last4Ssn { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Employer> Employer { get; set; }
        public virtual ICollection<Le> Le { get; set; }
        public virtual ICollection<Supplemental> Supplemental { get; set; }
    }
}
