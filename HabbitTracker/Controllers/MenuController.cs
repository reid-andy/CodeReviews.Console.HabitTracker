using HabbitTracker.Models;
using HabbitTracker.Views;

public class MenuController
{
    public void run()
    {
        bool exit = false;
        Console.WriteLine("Welcome to Habit Tracker!");
        while (!exit)
        {
            string? userInput = null;
            Console.WriteLine("\n          Main Menu           ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Log a Habit");
            Console.WriteLine("Type 3 to Delete a Record");
            Console.WriteLine("Type 4 to Update a Record");
            Console.WriteLine("Type 5 to Add a New Habit");
            Console.WriteLine("Type 0 to Exit");
            Console.WriteLine("------------------------------\n");

            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    exit = true;
                    break;
                case "1":
                    SelectFromDB selectFromDb = new SelectFromDB();
                    selectFromDb.GetAllRecords();
                    break;
                case "2":
                    LogOccurence logOccurence = new LogOccurence();
                    logOccurence.RenderLogOccurance();
                    break;
                case "3":
                    // Delete an occurence
                    break;
                case "4":
                    // Update an occurence
                    break;
                case "5":
                    // Add new habit
                    break;
                default:
                    Console.WriteLine("\nInvalid command. Please enter a number from 0 to 4\n");
                    break;
            }




        }
    }
}