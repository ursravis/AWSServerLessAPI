using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class ScrimsUser
    {
        public ScrimsUser()
        {
            ClearanceItem = new HashSet<ClearanceItem>();
            ProjectUser = new HashSet<ProjectUser>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<ClearanceItem> ClearanceItem { get; set; }
        public virtual ICollection<ProjectUser> ProjectUser { get; set; }
    }
}
