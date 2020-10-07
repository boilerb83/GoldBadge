using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoRepository;

namespace ChallengeTwoConsole
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _contentRepository = new ClaimsRepository();
        public void Run()
        {
            InitialContent();   //insert data into fake database for initial info.
            RunMenu();
        }

        public void InitialContent()        //Test Data and Initial database content
        {
            DateTime dateOneIncident = new DateTime(2020, 5, 05);
            DateTime dateOneClaim = new DateTime(2020, 10, 07);

            DateTime dateTwoIncident = new DateTime(2020, 10, 07);
            DateTime dateTwoClaim = new DateTime(2020, 10, 07);

            var claimOne = new ClaimsContent(1, "home", "crazy accident", 1000.60f, dateOneIncident, dateOneClaim, false);
            var claimTwo = new ClaimsContent(2, "car", "accident with pole", 20000.50f, dateTwoIncident, dateTwoClaim, true);

            _contentRepository.AddContentToDirectory(claimOne);
            _contentRepository.AddContentToDirectory(claimTwo);
        }

        private void DisplaySimpleMenu(ClaimsContent content)
        {
            Console.WriteLine
                ($"{content.ClaimID}" + "         " +
                $"{content.ClaimType}" + "        " +
                $"{content.Description}" + "       " +
                $"${content.ClaimAmount}" + "       " +
                $"{content.DateOfIncident:MM/dd/yy}" + "      " +   //format date time to show correclty
                $"{content.DateOfClaim:MM/dd/yy}" + "         " +   //format date time to show correctly
                $"{content.IsValid} \n");
        }

        private void DisplaySingleMenu(ClaimsContent content)
        {
            Console.WriteLine
               ($"Claim ID: {content.ClaimID} \n" + 
               $"Type: {content.ClaimType} \n" + 
               $"Description: {content.Description} \n" + 
               $"Amount:  ${content.ClaimAmount} \n" + 
               $"DateOfAccident: {content.DateOfIncident:MM/dd/yy} \n" +   //format date time to show correclty
               $"DateOfClaim: {content.DateOfClaim:MM/dd/yy} \n" +   //format date time to show correctly
               $"IsValid: {content.IsValid} \n");
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine
                ("\n\n ((WELCOME TO THE KOMODO CLAIMS DEPARTMENT PAGE)) \n\n" +
                    "ENTER THE NUMBER AND PRESS ENTER FOR THE OPTION YOU WOULD LIKE: \n" +
                    "1:  SEE ALL CLAIMS \n" +
                    "2:  TAKE CARE OF NEXT CLAIM \n" +
                    "3:  ENTER A NEW CLAIM \n" +
                    "4:  EXIT THE APPLICATION PAGE \n"
                );

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show a list of all items on cafe menu
                        ShowAllContent();       // Complete //
                        break;
                    case "2":
                        ///TAKE CARE OF CLAIM
                        CompleteClaim();
                        break;
                    case "3":
                        //CreateClaim()
                        CreateClaim();          //
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

        private void CompleteClaim()
        { 
            List<ClaimsContent> contentList = _contentRepository.GetContents();
         

            bool stay = true;

            while (stay == true)
            {
                int count = 0;
                foreach (var content in contentList)
                {
                    count++;
                    DisplaySingleMenu(content);         //show single 
                    Console.WriteLine("Do you want to deal with this claim now? (y/n)");

                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                     
                    }
                    else if (answer == "n")
                    {
                        stay = false;       //return to main menu
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private void ShowAllContent()
        {
            Console.Clear();
            Console.WriteLine("ClaimID   Type    Description              Amount      DateofAccident    DateofClaim   IsValid");
            List<ClaimsContent> listOfContent = _contentRepository.GetContents();

            foreach (ClaimsContent content in listOfContent)
            {
                DisplaySimpleMenu(content);
            }

            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            //Show All Items in the fake database
        }

        private void CreateClaim()
        {
            ClaimsContent content = new ClaimsContent();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("ENTER THE CLAIM ID. \n");
            content.ClaimID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("ENTER THE CLAIM TYPE AS (HOME, CAR, THEFT) \n");
            content.ClaimType = Console.ReadLine();

            Console.WriteLine($"ENTER THE DESCRIPTION FOR THIS {content.ClaimType} CLAIM. \n");
            content.Description = Console.ReadLine();

            Console.WriteLine($"ENTER THE CLAIM AMOUNT WITHOUT A $ SIGN. \n");
            content.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"ENTER THE DATE OF THE ACCIDENT (MM, DD, YY) FORMAT AND PRESS ENTER. \n");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"ENTER THE DATE OF THE CLAIM AND PRESS ENTER. \n");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"IS THIS CLAIM VALID? ENTER TRUE OR FALSE AND PRESS ENTER. \n");
            if (Console.ReadLine().ToLower() == "true")
            {
                content.IsValid = true;
            }
            else
            {
                content.IsValid = false;
            }
            _contentRepository.AddContentToDirectory(content);
        }
    }
}

