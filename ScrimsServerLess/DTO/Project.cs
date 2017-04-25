using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrimsServerLess.DTO
{
    public class Project
    {
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        public string CreatedBy { get; set; }
        public int NoOfImages { get; set; }
        public List<SmartAlbum> Images { get; set; }

        public int TotalCICount { get; set; }
        public int ReviewQueueCount { get; set; }
        public List<String> StatusNames { get; set; }
        public List<int> StatusValues { get; set; }
        public string ProjectUniqueID { get; set; }
        public string WorkingTitle { get; set; }
        public string ReleaseTitle { get; set; }
        public string WprBillingCode { get; set; }
        public string StrartDate { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime? ReleaseDate { get; internal set; }
    }
    public class SmartAlbum
    {
        public string ImageName { get; set; }
        public string ImageSrc { get; set; }
        public string ThumbnailSrc { get; set; }
        public int ImageId { get; set; }
        public string ImageType { get; set; }
    }
}
