using Amazon.SecurityToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrimsServerLess.DTO
{
    public class ClearanceItem
    {
      public string  ClearanceItemName;
        public int ClearanceItemID;
   public string Status;
     public string Description;
     public string UseDescription;
    public string Tags;
    public bool  ReleaseAdded;
   public string CreatedBy;
    public string[] Images;
   public string ClearanceItemUniqueId;
   public bool CreatedByProduction;
   public string CreatedDate;
   public string ImageUrl;
        public Credentials Credentials;
    }
}
