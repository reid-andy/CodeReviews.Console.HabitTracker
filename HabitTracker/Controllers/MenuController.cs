using HabitTracker.Models;
using HabitTracker.Views;

namespace HabitTracker.Controllers
{
    public class MenuController
    {
        public void run()
        {
            MenuView menuView = new MenuView();
            menuView.WriteWelcome();
            bool exit = false;

            while (!exit)
            {

                string? userInput = menuView.MainMenu();

                switch (userInput)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        SelectFromDB selectFromDb = new SelectFromDB();
                        List<HabitOccurrence> allRecords = selectFromDb.GetAllRecords();
                        menuView.OnlyViewAllRecords(allRecords);
                        break;
                    case "2":
                        selectFromDb = new SelectFromDB();
                        List<Habit> habits = selectFromDb.GetAllHabits();
                        Occurrence occurrenceToLog = menuView.LogOccurrence(habits);
                        InsertIntoDB insertIntoDb = new InsertIntoDB();
                        insertIntoDb.LogAnOccurrence(occurrenceToLog);
                        break;
                    case "3":
                        selectFromDb = new SelectFromDB();
                        allRecords = selectFromDb.GetAllRecords();
                        int idToDelete = menuView.DeleteOneRecord(allRecords);
                        DeleteFromDB deleteFromDb = new DeleteFromDB();
                        deleteFromDb.DeleteOneOccurrence(idToDelete);
                        break;
                    case "4":
                        selectFromDb = new SelectFromDB();
                        allRecords = selectFromDb.GetAllRecords();
                        habits = selectFromDb.GetAllHabits();
                        Occurrence occurrenceToUpdate = menuView.UpdateRecord(allRecords, habits);
                        UpdateDB updateDb = new UpdateDB();
                        updateDb.UpdateOccurrence(occurrenceToUpdate);
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
}
