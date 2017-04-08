using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class ProjectUser
    {
        public int ProjectUserId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? ProjectUserRole { get; set; }

        public virtual Project Project { get; set; }
        public virtual UserRole ProjectUserRoleNavigation { get; set; }
        public virtual ScrimsUser User { get; set; }
    }
}
