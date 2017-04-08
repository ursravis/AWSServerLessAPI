using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class ProjectStatus
    {
        public int ProjectStatusId { get; set; }
        public string ProjectStatus1 { get; set; }
        public int? StatusOrder { get; set; }
    }
}
