
using Microsoft.Data.Sqlite;

namespace HabitTracker.Models
{
    internal class DeleteFromDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public void DeleteOneOccurrence(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                string deleteCommand = "DELETE FROM occurrences WHERE occurrence_id = @id";
                connection.Open();
                var command = new SqliteCommand(deleteCommand, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}