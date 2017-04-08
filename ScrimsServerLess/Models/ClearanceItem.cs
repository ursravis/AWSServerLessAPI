using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class ClearanceItem
    {
        public ClearanceItem()
        {
            Ciflags = new HashSet<Ciflags>();
            Ciimage = new HashSet<Ciimage>();
            CirefImage = new HashSet<CirefImage>();
            CireleaseDoc = new HashSet<CireleaseDoc>();
        }

        public int Ciid { get; set; }
        public int ProjectId { get; set; }
        public string CiuniqueId { get; set; }
        public string Ciname { get; set; }
        public bool? IsCreatedByProd { get; set; }
        public string QuickDesc { get; set; }
        public string DescOfUse { get; set; }
        public int? Cistatus { get; set; }
        public bool? ReviewQueue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? ShootDate { get; set; }
        public string SceneNumber { get; set; }
        public string SubmittingDept { get; set; }
        public string ArtistName { get; set; }
        public string CopyrightInfo { get; set; }
        public string Urlrefference { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<Ciflags> Ciflags { get; set; }
        public virtual ICollection<Ciimage> Ciimage { get; set; }
        public virtual ICollection<CirefImage> CirefImage { get; set; }
        public virtual ICollection<CireleaseDoc> CireleaseDoc { get; set; }
        public virtual Cistatus CistatusNavigation { get; set; }
        public virtual ScrimsUser CreatedByNavigation { get; set; }
        public virtual Project Project { get; set; }
    }
}
