using HabitTracker.Helpers;
using HabitTracker.Models;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace HabitTracker.Views
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

        public Occurrence LogOccurrence(List<Habit> habits)
        {
            Helpers.Verify verify = new Verify();


            Console.WriteLine("Which habit would you like to log?");
            int selectedHabit = verify.HabitSelection(habits);

            Console.Clear();

            string userDateSelection = verify.DateSelection();

            Console.Clear();

            int habitQuantity = verify.HabitQuantity();

            Console.Clear();

            Occurrence occurrence = new Occurrence(selectedHabit, habitQuantity, userDateSelection);

            return occurrence;
        }

        public void ViewAllRecords(List<HabitOccurrence> allRecords)
        {
            Console.WriteLine("All Records:");
            Console.WriteLine(standardLine);
            foreach (HabitOccurrence occurrence in allRecords)
            {
                Console.WriteLine($"ID:{occurrence.occurrenceId} {occurrence.date.ToString("yyyy-MM-dd")}: {occurrence.habitName} {occurrence.habitQuantity} {occurrence.quantityName}");
            }

            Console.WriteLine(standardLine);
        }

        public void OnlyViewAllRecords(List<HabitOccurrence> allRecords)
        {
            this.ViewAllRecords(allRecords);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public int DeleteOneRecord(List<HabitOccurrence> allRecords)
        {
            string? userInput = "";
            bool invalidInput = true;
            int idToDelete = -1;
            this.ViewAllRecords(allRecords);
            Console.Write("Enter the Record ID Number to Delete: ");
            while (invalidInput)
            {
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out idToDelete))
                {
                    invalidInput = false;
                }
            }
            Console.Clear();
            return idToDelete;
        }

        public HabitOccurrence UpdateRecord(List<HabitOccurrence> allRecords, List<Habit> habits)
        {
            List<int> availableIds = new();
            foreach (HabitOccurrence habitOccurrence in allRecords)
            {
                availableIds.Add(habitOccurrence.occurrenceId);
            }
            this.ViewAllRecords(allRecords);
            Console.WriteLine("\nEnter an ID to update: ");
            string? userId = Console.ReadLine();
            int.TryParse(userId, out int idToUpdate);
            bool invalidInput = true;
            while (invalidInput)
            {
                if (availableIds.Contains(idToUpdate))
                {
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("Selected ID not found.");
                }
            }
            HabitOccurrence occurrenceToUpdate = allRecords.Where(i => i.occurrenceId == idToUpdate).FirstOrDefault();

            Console.Clear();

            invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine($"Current Habit is {occurrenceToUpdate.habitName}. Would you like to update it? (y/n)");
                ConsoleKeyInfo userSelection = Console.ReadKey();
                if (userSelection.Key == ConsoleKey.N)
                {
                    invalidInput = false;
                }
                else if (userSelection.Key == ConsoleKey.Y)
                {
                    //update logic
                }
                else
                {
                    Console.WriteLine("Invalid selection.\n");
                }
            }

            return occurrenceToUpdate;

        }

    }
}
