using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            ProjectUser = new HashSet<ProjectUser>();
        }

        public int UserRoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<ProjectUser> ProjectUser { get; set; }
    }
}
