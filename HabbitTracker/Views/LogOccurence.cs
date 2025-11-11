using HabbitTracker.Models;

namespace HabbitTracker.Views
{
    internal class LogOccurence
    {
        public void RenderLogOccurance()
        {
            bool exitMenu = false;
            while (!exitMenu)
            {
                SelectFromDB selectFromDb = new SelectFromDB();
                Console.WriteLine("Which habit would you like to log?");
                List<Habit> habits = selectFromDb.GetAllHabits();
                for (int i = 0; i < habits.Count; i++)
                {
                    Console.WriteLine($"{i}. {habits[i].habitName}");
                }
                Console.ReadLine();
            }
        }
    }
}
