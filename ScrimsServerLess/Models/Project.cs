using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class Project
    {
        public Project()
        {
            ClearanceItem = new HashSet<ClearanceItem>();
            ProjectUser = new HashSet<ProjectUser>();
        }

        public int ProjectId { get; set; }
        public string ProjectUniqueId { get; set; }
        public string WorkingTitle { get; set; }
        public string ReleaseTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? WrapDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ProjectStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ClearanceItem> ClearanceItem { get; set; }
        public virtual ProjectAddress ProjectAddress { get; set; }
        public virtual ICollection<ProjectUser> ProjectUser { get; set; }
    }
}
