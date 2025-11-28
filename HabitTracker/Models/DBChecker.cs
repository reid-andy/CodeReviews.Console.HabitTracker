using HabitTracker.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Globalization;
using System.IO;

namespace HabitTracker.Models
{
    public class DBChecker
    {
        string connectionString = @"Data Source=habit-tracker.db";

        public void InitializeDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var habitTableCmd = connection.CreateCommand();
                var occurrencesTableCmd = connection.CreateCommand();
                var clearTables = connection.CreateCommand();
                clearTables.CommandText = "DROP TABLE IF EXISTS occurrences;";
                clearTables.ExecuteNonQuery();

                habitTableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS habits(
                habit_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                habit_name varchar(50) NOT NULL UNIQUE,
                quantity_name varchar(50) NOT NULL
                )";

                occurrencesTableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS occurrences (
                occurrence_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                habit_id INTEGER, 
                habit_quantity INTEGER NOT NULL,
                date TEXT NOT NULL,
                FOREIGN KEY (habit_id) REFERENCES habits (habit_id)
                )";

                var result = habitTableCmd.ExecuteNonQuery();
                occurrencesTableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SeedDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var habitsToAdd = connection.CreateCommand();
                habitsToAdd.CommandText =
                    @"INSERT OR IGNORE INTO habits(habit_name, quantity_name) VALUES('Water drank', 'Glasses');
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name) VALUES('Miles Ran', 'Miles');
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name) VALUES('Mario Levels Completed', 'Levels');
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name) VALUES('Book Pages Read', 'Pages');
";
                habitsToAdd.ExecuteNonQuery();

                var occurrencesToAdd = connection.CreateCommand();
                occurrencesToAdd.CommandText =
                    $@"
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-02');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-04');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-06');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-04');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(2, 1, '2025-11-03');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(2, 2, '2025-11-04');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(2, 3, '2025-11-05');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(2, 13, '2025-11-01');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(3, 4, '2025-11-08');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(3, 9, '2025-11-08');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(4, 10, '2025-11-01');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(4, 37, '2025-11-03');
                INSERT INTO occurrences(habit_id, habit_quantity, date) VALUES(4, 54, '2025-11-07');
";
                occurrencesToAdd.ExecuteNonQuery();

                connection.Close();
            }

        }
    }
}