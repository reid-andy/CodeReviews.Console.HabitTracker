using HabitTracker.Models;
using System;
using System.Globalization;

namespace HabitTracker.Helpers;
internal class Verify
{
    public Habit HabitSelection(List<Habit> habits)
    {
        bool invalidInput = true;
        Habit selectedHabit = null;
        while (invalidInput)
        {
            for (int i = 0; i < habits.Count; i++)
            {
                Console.WriteLine($"{habits[i].habitId}. {habits[i].habitName}");
            }

            string? userHabitId = Console.ReadLine();
            if (int.TryParse(userHabitId, out int habitId))
            {
                if (habitId != null)
                {
                    selectedHabit = habits.Where(i => i.habitId == habitId).FirstOrDefault();
                    invalidInput = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Type the ID number of the habit, then press Enter.\n");
            }

        }
        return selectedHabit;
    }

    public string DateSelection()
    {
        bool invalidInput = true;
        DateTime dateTime = DateTime.Now;
        string userDateSelection = "";
        Console.WriteLine("Enter the occurrence date in yyyy-MM-dd format (enter 0 for today's date).");
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
        return userDateSelection;
    }

    public int HabitQuantity()
    {
        string userHabitQuantity = "";
        Console.WriteLine("Enter the quantity: ");
        userHabitQuantity = Console.ReadLine();
        int habitQuantity = 0;
        bool invalidInput = true;
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
        return habitQuantity;
    }

    public string Name()
    {
        bool invalidInput = true;
        string? name = "";
        while (invalidInput)
        {
            name = Console.ReadLine();
            if (name.Length == 0 || name.Length > 50)
            {
                Console.WriteLine("\nName missing or too long.\n");
            }
            else
            {
                invalidInput = false;
                Console.Clear();
            }
        }
        return name;
    }
}