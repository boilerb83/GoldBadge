using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThreeConsole;
using ChallengeThreeRepository;

namespace ChallengeThreeConsole
{
    public class ProgramUI
    {
        private readonly BadgeRepository _badgeRepository = new BadgeRepository();

        public Dictionary<int, string> _badgeDictionary = new Dictionary<int, string>();
        public List<string> _listofRooms = new List<string>();

        public void Run()
        {
            InitialContent();   //insert data into fake database for initial info.
            RunMenu();
        }

        public void RunMenu()  //MAIN CODE TO RUN
        {
            bool continueToRun = true;
            while (continueToRun)       //while continue to run is true main screen will keep showing
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine
                ("\n\n ((WELCOME TO THE EMPLOYEE BADGE SECURITY ADMIN PAGE)) \n\n" +
                    "ENTER THE NUMBER AND PRESS ENTER FOR THE OPTION YOU WOULD LIKE: \n" +
                    "1:  CREATE NEW EMPLOYEE BADGE \n" +
                    "2:  EDIT AN EMPLOYEE BADGE (ADD, UPDATE, OR DELETE DOORS) \n" +
                    "3:  RECEIVE A LIST OF ALL BADGES \n" +
                    "4:  EXIT THE APPLICATION PAGE \n"
                );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Create new user and badge access level
                        CreateContent();
                        break;
                    case "2":
                        //Call Edit function
                        EditContent();
                        break;
                    case "3":
                        //Show all users and badges
                        ShowAllContent();
                        break;
                    case "4":
                        //EXIT THE APPLICATION
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.WriteLine("Please enter a valid number response to move forward in the application. \n" +
                                          "Press any key to continue.........");
                        Console.ReadKey();
                        break;
                }
            }       //END OF WHILE LOOP IF CONTINUE TO RUN IS FALSE

        }

        private void CreateContent()
        {
            int endofdoors = 0;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("ENTER THE EMPLOYEE BADGE NUMBER. \n");    //ASK FOR (badge number)
            int badgenumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("ENTER THE DOOR THE EMPLOYEE HAS ACCESS TO \n"); //ASK FOR (badge doors)
            string door = Console.ReadLine();
            _listofRooms.Add(door);
            _badgeRepository.AddContentToDirectory(badgenumber, _listofRooms);

            do
            {
                Console.WriteLine("Do you want to add another door enter 1 for yes and 2 for no.");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("ENTER THE DOOR THE EMPLOYEE HAS ACCESS TO \n"); //ASK FOR (badge doors)
                    door = Console.ReadLine();
                    _listofRooms.Add(door);
                    endofdoors = 0;
                }
                else if (answer == "2")
                {
                    endofdoors = 1;
                }
                else
                {
                    Console.WriteLine("There was an error in your answer");
                    Console.WriteLine("Press a key to continue.............");
                }
            }
            while (endofdoors == 0);
        }

        private void ShowAllContent()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfContent = _badgeRepository.GetContents();

            Console.WriteLine("KEY BADGE ID#      DOOR ACCESS \n" +
                    "------------------------------------------------------------------");
            foreach (KeyValuePair<int, List<string>> content in listOfContent)
            {
                foreach (string typeofcontent in content.Value)
                {
                    Console.WriteLine("   {0},               {1}", content.Key, typeofcontent);
                }
            }

            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            //Show All Items in the fake database
        }

        private void EditContent()
        {
            Console.WriteLine("What is the badge number to update?");
            int badge_to_update = Int32.Parse(Console.ReadLine());
            List<string> listofdoors = _badgeRepository.GetDoorsByKey(badge_to_update);

            foreach (string door in listofdoors)
            {
                Console.WriteLine("Badge number {0} has access to {1}", badge_to_update, door);
            }

            Console.WriteLine
                ("Which option would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door \n" +
                "3. Delete all doors associated with the BadgeID#");

            int selection = Int32.Parse(Console.ReadLine());
            if (selection == 1)   //remove
            {
                Console.WriteLine("Which door would you like to remove?");
                string door = Console.ReadLine();
                listofdoors.Remove(door);
                Console.WriteLine("Door {0} has been removed and is not associated with Badge ID#{1} anymore.", door, badge_to_update);
                Console.ReadLine();
            }
            else if (selection == 2) //add
            {
                Console.WriteLine("Which door would you like to add?");
                string newdoor = Console.ReadLine();
                listofdoors.Add(newdoor);
                Console.WriteLine("Door {0} has been added and is now associated with Badge ID#{1}.",  newdoor, badge_to_update);
                Console.ReadLine();
            }
            else if (selection == 3)  //DELETE ALL DOORS ASSOCIATED WITH USER by using removerange
            {
                int remove_all = Math.Max(0, listofdoors.Count);
                listofdoors.RemoveRange(0, remove_all);
                Console.WriteLine("All doors have been removed that are associated with Badge ID#{1}.", badge_to_update);
                Console.WriteLine("Press any key to continue.......");
                Console.ReadLine();
            }
        }
    
        private void InitialContent()
        {
            List<string> _firstList = new List<string>();
            _firstList.Add("a5");
            _firstList.Add("a6");
            _firstList.Add("a7");

            List<string> _secondList = new List<string>();
            _secondList.Add("a5");
            _secondList.Add("a6");
            _secondList.Add("a7");

            List<string> _thirdList = new List<string>();
            _thirdList.Add("a5");
            _thirdList.Add("a6");
            _thirdList.Add("a7");

            _badgeRepository.AddContentToDirectory(1, _firstList);
            _badgeRepository.AddContentToDirectory(2, _secondList);
            _badgeRepository.AddContentToDirectory(3, _thirdList);
        }
    }
}
