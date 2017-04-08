using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class Ciimage
    {
        public int CiimageId { get; set; }
        public int Ciid { get; set; }
        public string CiimageAddress { get; set; }
        public string CiimageBlobId { get; set; }

        public virtual ClearanceItem Ci { get; set; }
    }
}
