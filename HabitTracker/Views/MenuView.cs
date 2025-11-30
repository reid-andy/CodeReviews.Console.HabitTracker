using HabitTracker.Helpers;
using HabitTracker.Models;

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
            Console.WriteLine("Type 6 to Select a Report");
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
            int selectedHabit = verify.HabitSelection(habits).habitId;

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
                Console.WriteLine($"ID:{occurrence.occurrenceId} {occurrence.date}: {occurrence.habitName} {occurrence.habitQuantity} {occurrence.quantityName}");
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

        public Occurrence UpdateRecord(List<HabitOccurrence> allRecords, List<Habit> habits)
        {
            List<int> availableIds = new();
            foreach (HabitOccurrence habitOccurrence in allRecords)
            {
                availableIds.Add(habitOccurrence.occurrenceId);
            }
            this.ViewAllRecords(allRecords);
            int idToUpdate = -1;
            bool invalidInput = true;
            HabitOccurrence? occurrenceToUpdate = null;
            Occurrence? updatedOccurrence = null;
            while (invalidInput)
            {
                Console.WriteLine("\nEnter an ID to update: ");
                string? selectedId = Console.ReadLine();
                int.TryParse(selectedId, out idToUpdate);
                if (availableIds.Contains(idToUpdate))
                {
                    occurrenceToUpdate = allRecords.Where(i => i.occurrenceId == idToUpdate).FirstOrDefault();
                    updatedOccurrence = new Occurrence(occurrenceToUpdate.habitId, occurrenceToUpdate.habitQuantity, occurrenceToUpdate.date);
                    updatedOccurrence.occurrenceId = idToUpdate;
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("Selected ID not found.\n");
                }
            }
            Console.Clear();

            Verify verify = new Verify();

            invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine($"Current Habit is {occurrenceToUpdate.habitName}. Would you like to update it? (y/n) ");
                ConsoleKeyInfo userSelection = Console.ReadKey();
                if (userSelection.Key == ConsoleKey.N)
                {
                    invalidInput = false;
                    Console.Clear();
                }
                else if (userSelection.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    updatedOccurrence.habitId = verify.HabitSelection(habits).habitId;
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid selection.\n");
                }
            }
            invalidInput = true;
            while (invalidInput)
            {
                Console.Clear();
                Console.WriteLine($"The current date is {occurrenceToUpdate.date}. Would you like to update it? (y/n) ");
                ConsoleKeyInfo userSelection = Console.ReadKey();
                if (userSelection.Key == ConsoleKey.N)
                {
                    invalidInput = false;
                    Console.Clear();
                }
                else if (userSelection.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    updatedOccurrence.date = verify.DateSelection();
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid selection.\n");
                }
            }
            invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine($"The current quantity is {occurrenceToUpdate.habitQuantity}. Would you like to update it? (y/n) ");
                ConsoleKeyInfo userSelection = Console.ReadKey();
                if (userSelection.Key == ConsoleKey.N)
                {
                    invalidInput = false;
                    Console.Clear();
                }
                else if (userSelection.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    updatedOccurrence.habitQuantity = verify.HabitQuantity();
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid selection.\n");
                }
            }
            Console.Clear();
            return updatedOccurrence;

        }

        public Habit AddHabit()
        {
            Console.Clear();
            Verify verify = new Verify();
            Console.WriteLine("Enter the habit name (limit 50 characters): ");
            string habitName = verify.Name();
            Console.WriteLine("Enter a quantity name for this habit (example: 'miles ran' or 'pages read' (limit 50 characters): ");
            string quantityName = verify.Name();
            Habit newHabit = new Habit(habitName, quantityName);
            return newHabit;
        }

        public string? ReportSelection()
        {
            Console.Clear();
            Console.WriteLine("\n           Reports           ");
            Console.WriteLine(standardLine);
            Console.WriteLine("Type 1 to View Lifetime Totals");
            Console.WriteLine("Type 2 to View Totals this Year");
            Console.WriteLine("Type 3 to View Most Frequent Habits");
            Console.WriteLine("Type 4 to View Least Frequent Habits");
            Console.WriteLine("Type 0 to Exit");
            Console.WriteLine($"{standardLine}\n");

            string? userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public void ReportView(List<String[]> result)
        {
            Console.WriteLine(standardLine);
            foreach (var item in result)
            {
                foreach (var element in item)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(standardLine);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
