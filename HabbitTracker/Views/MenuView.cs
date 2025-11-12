using HabbitTracker.Models;
using HabitTracker.Controllers;
using HabitTracker.Models;
using System.Runtime.CompilerServices;

namespace HabbitTracker.Views
{
    internal class MenuView
    {
        private string standardLine = "------------------------------";
        public void WriteWelcome()
        {
            Console.WriteLine("Welcome to Habit Tracker!");
        }
        public string? MainMenu()
        {


            string? userInput = null;
            Console.WriteLine("\n          Main Menu           ");
            Console.WriteLine(standardLine);
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Log a Habit");
            Console.WriteLine("Type 3 to Delete a Record");
            Console.WriteLine("Type 4 to Update a Record");
            Console.WriteLine("Type 5 to Add a New Habit");
            Console.WriteLine("Type 0 to Exit");
            Console.WriteLine($"{standardLine}\n");

            userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public string? LogOccurrence(List<Habit> habits)
        {
            string? userInput;
            Console.WriteLine("Which habit would you like to log?");
            for (int i = 0; i < habits.Count; i++)
            {
                Console.WriteLine($"{i}. {habits[i].habitName}");
            }
            userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public void viewAllRecords(List<HabitOccurrence> allRecords)
        {
            Console.WriteLine("All Records:");
            Console.WriteLine(standardLine);
            foreach (HabitOccurrence occurrence in allRecords)
            {
                Console.WriteLine($"{occurrence.date.ToString("yyyy-MM-dd")}: {occurrence.habitName} {occurrence.habitQuantity} {occurrence.quantityName}");
            }

            Console.WriteLine(standardLine);
        }

    }
}
