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
                    "2:  EDIT AN EMPLOYEE BADGE \n" +
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

        /*private void DisplaySimpleMenu(BadgeContent badgeDictionary)   //MIGHT USE A DICTIONARY INSTEAD
        {
            Console.WriteLine($"{content.} \n" +
               $"EMPLOYEE ID::  {_badgeDictionary.ListOfDoors} \n" +
               $"LIST OF DOORS EMPLOYEE HAS ACCESS TO:: {badgeDictionary.ListOfDoors} \n" +
               $"------------------------------------------------------------------");

            /*foreach (string doors in )
            {
                Console.WriteLine("Value = {0}", doors);
            }
        }*/

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

            do  //loop for each door needed added  *****
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

            foreach (KeyValuePair<int, List<string>> content in listOfContent)
            {
                
                foreach (string typeofcontent in content.Value)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", content.Key, typeofcontent);
                }

            }
           
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            //Show All Items in the fake database
        }

        private void EditContent()
        {


        }

        private void InitialContent()
        {
            List<string> _seedList = new List<string>();
            _seedList.Add("a5");
            _seedList.Add("a6");
            _seedList.Add("a7");

            _badgeRepository.AddContentToDirectory(2, _seedList);

        }
    }
}
