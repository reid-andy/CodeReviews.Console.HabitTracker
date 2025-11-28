using Microsoft.Data.Sqlite;

namespace HabitTracker.Models
{
    internal class InsertIntoDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public void LogAnOccurrence(Occurrence occurrence)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"INSERT INTO occurrences (habit_id, habit_quantity, date) " +
                    $"VALUES({occurrence.habitId}, {occurrence.habitQuantity}, '{occurrence.date}');";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void InsertHabit(Habit habit)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"INSERT INTO habits (habit_name, quantity_name) " +
                    $"VALUES('{habit.habitName}', '{habit.quantityName}');";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}