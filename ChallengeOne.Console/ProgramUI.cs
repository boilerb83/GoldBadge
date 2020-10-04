using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChallengeOneConsole;
using ChallengeOneRepository;

namespace ChallengeOneConsole
{
    public class ProgramUI
    {

        private readonly MenuRepository _menuRepository = new MenuRepository();
        public void Run()
        {
            InitialContent();   //insert data into fake database for initial info.
            RunMenu();
        }

        public void RunMenu()   //MAIN CODE TO RUN    ////////need to do something with the list of ingredients also/////
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine
                ("\n\n ((WELCOME TO THE KOMODO CAFE APPLICATION PAGE)) \n\n" +
                    "ENTER THE NUMBER AND PRESS ENTER FOR THE OPTION YOU WOULD LIKE: \n" +
                    "1:  CREATE NEW MENU ITEMS \n" +
                    "2:  RECEIVE A LIST OF ALL ITEMS ON THE CAFES MENU \n" +
                    "3:  DELETE NEW MENU ITEMS \n" +
                    "4:  EXIT THE APPLICATION PAGE \n"
                );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Create a menu for user
                        CreateMenu();
                        break;
                    case "2":
                        //Show a list of all items on cafe menu
                        ShowAllContent();
                        break;
                    case "3":
                        //Remove Menu Items
                        DeleteMenuItems();
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

            }       //end of while loop if continue to Run is false keeps the screen up until user exits
        }

        private void CreateMenu()       //Change color to green and create content
        {
            MenuContent content = new MenuContent();
            Console.ForegroundColor = ConsoleColor.Green;
        // public Menu(int mealNumber, string title, string description, double price)   //just listing the data needed to sent in
            Console.WriteLine("ENTER THE MENU NUMBER. \n");                //ASK FOR (Meal Number)
            content.MealNumber = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("ENTER THE MEAL NAME \n");                  //ASK FOR (Meal Name)
            content.MealName = Console.ReadLine();
            
            Console.WriteLine($"ENTER THE DESCRIPTION FOR {content.MealName}. \n");  //ASK FOR (Description)
            content.Description = Console.ReadLine();
            
            Console.WriteLine($"ENTER THE PRICE {content.MealName} WITHOUT A $ SIGN. \n"); //ASK FOR (Price)                                                               
            content.Price = double.Parse(Console.ReadLine());

            Console.WriteLine($"ENTER THE LIST OF INGREDIENTS {content.MealName} AND PRESS ENTER. \n"); //ASK FOR (Price)                                                             
            content.ListOfIngredients = Console.ReadLine();

            _menuRepository.AddContentToDirectory(content);
        }

        private void DisplaySimpleMenu(MenuContent content)
        {
            Console.WriteLine($"{ content.MealNumber} \n" +
                $"MEAL NAME::  {content.MealName} \n" +
                $"DESCRIPTION:: {content.Description} \n" +
                $"PRICE:: ${content.Price} \n" +
                $"LIST OF INGREDIENTS:: {content.ListOfIngredients} \n" +
                $"------------------------------------------------------------------");
        }

        private void ShowAllContent()
        {
            Console.Clear();
            List<MenuContent> listOfContent = _menuRepository.GetContents();

            foreach (MenuContent content in listOfContent)
            {
                DisplaySimpleMenu(content);
            }

            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            //Show All Items in the fake database
        }

        private void DeleteMenuItems()
        {
            Console.WriteLine("Which menu item would you like to remove?");
            //DISPLAY LIST OF THE ITEMS AVAILABLE
            List<MenuContent> contentList = _menuRepository.GetContents();

            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                Console.WriteLine($"{count}:: {content.MealName}");
            }

            int targetMenuID = int.Parse(Console.ReadLine());
            int correctIndex = targetMenuID - 1;   //subtract 1 here because it starts at 0 in memory

            if (correctIndex >= 0 && correctIndex < contentList.Count)  //Remove Item
            {
                MenuContent desiredContent = contentList[correctIndex];
                if (_menuRepository.DeleteMenuItems(desiredContent))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{desiredContent.MealName} has been removed from the database.");
                }
                else
                {
                    Console.WriteLine("Current task request can not be completed");
                }
            }
            else 
            {
                Console.WriteLine("INVALID OPTION");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void InitialContent()
        {
            var menuOne = new MenuContent  (1, "Tacos", "3 tacos, all hard shells", 10.5f, "1lb Ground Beef, pepper, salt, tortillas");
            var menuTwo = new MenuContent  (2, "Spaghetti", "Noodles and Awesome Sauce straight from the garden", 12.5f, "1lb ground beef, noodles, awesome sauce");
            var menuThree = new MenuContent(3, "Corn Dogs", "3 corn dogs and fries", 5.5f, "corn dogs, 1 lb of frozen fries, ketchup");
            var menuFour = new MenuContent (4, "Fried Chicken", "2 fried chicken drumsticks with mashed potatoes", 7.5f, "oil, chicken, pepper, potatoes, butter");
            var menuFive = new MenuContent (5, "Filet Minon","12 oz filet with a baked potatoe and green beans", 25f, " Filet Steak, pepper, salt, baked potatoe, fresh green beans");

            _menuRepository.AddContentToDirectory(menuOne);
            _menuRepository.AddContentToDirectory(menuTwo);
            _menuRepository.AddContentToDirectory(menuThree);
            _menuRepository.AddContentToDirectory(menuFour);
            _menuRepository.AddContentToDirectory(menuFive);
        } 
    }
}
