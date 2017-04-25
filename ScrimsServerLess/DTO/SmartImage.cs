using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrimsServerLess.DTO
{
    public class SmartImage
    {
        public int CIID { get; set; }
        public string ImageName { get; set; }
        public string ImageSrc { get; set; }
        public string ThumbnailSrc { get; set; }
        public int ImageId { get; set; }
        public string ImageType { get; set; }
    }
}
