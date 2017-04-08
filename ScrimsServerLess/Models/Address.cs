using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class Address
    {
        public Address()
        {
            ProjectAddress = new HashSet<ProjectAddress>();
        }

        public int AddressId { get; set; }
        public string CareOf { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string ZipPin { get; set; }

        public virtual ICollection<ProjectAddress> ProjectAddress { get; set; }
    }
}
