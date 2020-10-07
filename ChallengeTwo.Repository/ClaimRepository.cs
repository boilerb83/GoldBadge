using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepository
{
    public class ClaimsContent
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimsContent() { }
        public ClaimsContent(int claimID, string claimtype, string description, double claimamount, DateTime dateofincident, DateTime dateofclaim, bool isvalid)
        {
            ClaimID = claimID;
            ClaimType = claimtype;
            Description = description;
            ClaimAmount = Math.Round(claimamount, 2);  //round number
            DateOfIncident = (dateofincident);
            DateOfClaim = (dateofclaim);
            IsValid = isvalid;
        }
    }

    public class ClaimsRepository
    {
        protected readonly Queue<int> _contentQueue = new Queue<int>();   //????  when to use this
        protected readonly List<ClaimsContent> _contentDirectory = new List<ClaimsContent>();

        public bool AddContentToDirectory(ClaimsContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<ClaimsContent> GetContents()
        {
            return _contentDirectory;
        }
        public bool DeleteClaimItems(ClaimsContent existingContent)      //NOT USED FOR FUTURE DEV. IF NEEDED
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
