using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class Ciflags
    {
        public int CiflagId { get; set; }
        public int Ciid { get; set; }
        public bool? AdvartiseFlag { get; set; }
        public string AdvrtiseNotes { get; set; }
        public bool? EndCreditFlag { get; set; }
        public string EndCreditNotes { get; set; }
        public bool? FeesFlag { get; set; }
        public string FeesNotes { get; set; }
        public bool? CastListFlag { get; set; }
        public string CastListNotes { get; set; }
        public bool? HomeEntertainmentFlag { get; set; }
        public string HomeEntertainmentNotes { get; set; }
        public bool? PostProductionFlag { get; set; }
        public string PostProductionNotes { get; set; }
        public bool? ClipFlag { get; set; }
        public string ClipNotes { get; set; }

        public virtual ClearanceItem Ci { get; set; }
    }
}
