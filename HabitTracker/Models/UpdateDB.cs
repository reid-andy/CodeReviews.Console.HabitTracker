

using Microsoft.Data.Sqlite;

namespace HabitTracker.Models
{
    internal class UpdateDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public void UpdateOccurrence(Occurrence occurrence)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                string updateCommand = "UPDATE occurrences SET habit_id=@habitId, habit_quantity=@quantity, date=@date WHERE occurrence_id = @id";
                connection.Open();
                var command = new SqliteCommand(updateCommand, connection);
                command.Parameters.AddWithValue("@id", occurrence.occurrenceId);
                command.Parameters.AddWithValue("@habitId", occurrence.habitId);
                command.Parameters.AddWithValue("@quantity", occurrence.habitQuantity);
                command.Parameters.AddWithValue("@date", occurrence.date);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
