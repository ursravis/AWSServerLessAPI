using System;
using System.Collections.Generic;

namespace ScrimsServerLess.Models
{
    public partial class ProjectAddress
    {
        public int ProjectAddressId { get; set; }
        public int? ProjectId { get; set; }
        public int? AddressId { get; set; }
        public bool? IsPrimary { get; set; }

        public virtual Address Address { get; set; }
        public virtual Project ProjectAddressNavigation { get; set; }
    }
}
