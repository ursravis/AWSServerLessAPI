using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class Cistatus
    {
        public Cistatus()
        {
            ClearanceItem = new HashSet<ClearanceItem>();
        }

        public int CistatusId { get; set; }
        public string Cistatus1 { get; set; }
        public int? CistatusOrder { get; set; }

        public virtual ICollection<ClearanceItem> ClearanceItem { get; set; }
    }
}
