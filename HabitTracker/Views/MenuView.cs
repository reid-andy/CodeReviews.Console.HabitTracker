using HabitTracker.Models;
using System.Collections.Generic;
using System.Globalization;

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
            string userHabitSelection = "";
            string userDateSelection = "";
            string userHabitQuantity = "";
            bool invalidInput = true;
            int selectedHabit = 0;
            DateTime dateTime = DateTime.Now;
            int[] availableHabits = new int[habits.Count];

            while (invalidInput)
            {
                Console.WriteLine("Which habit would you like to log?");
                for (int i = 0; i < habits.Count; i++)
                {
                    Console.WriteLine($"{habits[i].habitId}. {habits[i].habitName}");
                    availableHabits[i] = habits[i].habitId;
                }

                userHabitSelection = Console.ReadLine();
                if (int.TryParse(userHabitSelection, out selectedHabit))
                {
                    if (availableHabits.Contains(selectedHabit))
                    {
                        invalidInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Type the ID number of the habit, then press Enter.\n");
                }

            }

            Console.Clear();
            Console.WriteLine("Enter the occurrence date in yyyy-MM-dd format (enter 0 for today's date).");
            invalidInput = true;
            while (invalidInput)
            {
                userDateSelection = Console.ReadLine();
                if (userDateSelection == "0")
                {
                    userDateSelection = dateTime.ToString("yyyy-MM-dd");
                    invalidInput = false;
                }
                else
                {
                    if (DateTime.TryParseExact(userDateSelection, "yyyy-MM-dd", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime newDateTime))
                    {
                        userDateSelection = newDateTime.ToString("yyyy-MM-dd");
                        invalidInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Enter the occurrence date in yyyy-MM-dd format " +
                            "(enter 0 for today's date).");
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Enter the quantity: ");
            userHabitQuantity = Console.ReadLine();
            int habitQuantity = 0;
            invalidInput = true;
            while (invalidInput)
            {
                if (int.TryParse(userHabitQuantity, out int quantity))
                {
                    habitQuantity = quantity;
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("Not a whole number. Enter the quantity: ");
                    userHabitQuantity = Console.ReadLine();
                }

            }

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

        public int deleteOneRecord(List<HabitOccurrence> allRecords)
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

    }
}
