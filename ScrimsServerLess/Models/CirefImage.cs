using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class CirefImage
    {
        public int CirefImageId { get; set; }
        public int Ciid { get; set; }
        public string CirefImageAddress { get; set; }
        public string CirefImageBlobId { get; set; }

        public virtual ClearanceItem Ci { get; set; }
    }
}
