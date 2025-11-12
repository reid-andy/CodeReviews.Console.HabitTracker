using HabbitTracker.Models;
using Microsoft.Data.Sqlite;

namespace HabbitTracker.Models
{
    internal class InsertIntoDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public void LogAnOccurrence()
        {
            using (var connection = new SqliteConnection(connectionString))
            {

            }
        }
    }
}