using HabbitTracker.Models;
using Microsoft.Data.Sqlite;

namespace HabbitTracker.Models
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
                    $"VALUES({occurrence.habitId}, {occurrence.habitQuantity}, {occurrence.date.ToString("yyyy-MM-dd")});";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}