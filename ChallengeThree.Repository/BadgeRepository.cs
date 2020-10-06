using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepository
{
    public class BadgeContent
    {
        public int BadgeID { get; set; }
        public List<string> listOfDoors { get; set; }

        public BadgeContent() { }

        //public Dictionary<int, string> badgeDictionary= new Dictionary <int, string>();

        public BadgeContent(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;      //single badge ID used a key to dictionary
            listOfDoors = doors;          //list of doors sent in to open with key in dictionary
        }
    }

    public class BadgeRepository        //CRUD  (CREATE, UPDATE, ADD, LIST) //
    {
         public Dictionary<int, List<string>> _contentDirectory = new Dictionary<int, List<string>>();

        //ADD BADGE
        public bool AddContentToDirectory(int badgeid, List<string> door)     //changed this to type List to bring in a list of strings
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(badgeid, door);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ ALL BADGES AND DOORS
        public Dictionary<int, List<string>> GetContents()   
        {
            return _contentDirectory;
        }

        //DELETE BADGE
       public bool DeleteBadgeItems(int badgeID)      
       {
            bool deleteResult = _contentDirectory.Remove(badgeID);
            return deleteResult;
       }     
    }
}


