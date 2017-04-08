using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class CireleaseDoc
    {
        public int CireleaseDocId { get; set; }
        public int Ciid { get; set; }
        public string CireleaseDocAddress { get; set; }
        public string CireleaseDocBlob { get; set; }

        public virtual ClearanceItem Ci { get; set; }
    }
}
