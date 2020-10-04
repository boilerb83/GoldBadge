using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class MenuContent
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ListOfIngredients { get; set; }

        public MenuContent() { }   
        public MenuContent(int mealNumber, string title, string description, double price, string ingredients)  //added list
        {
            MealNumber = mealNumber;
            MealName = title;
            Description = description;
            Price = price;
            ListOfIngredients = ingredients;     //added list
        }
    }

    public class MenuRepository
    {
        protected readonly List<MenuContent> _contentDirectory = new List<MenuContent>();
        //////   CRUD   (update is not needed for this program or we would have Update)/////
        //DECLARE LIST OF ITEMS

        //CREATE 
        //ADD MENU ITEM
        public bool AddContentToDirectory(MenuContent content) 
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //RECEIVE LIST OF MENU ITEMS
        //READ ALL
        public List<MenuContent> GetContents()
        {
            return _contentDirectory;
        }

        //DELETE
        public bool DeleteMenuItems(MenuContent existingContent)  /////// START HERE tomorrow using remove content from list ////////
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }

    }
}
