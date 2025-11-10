using HabbitTracker.Models;
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
                var occurencesTableCmd = connection.CreateCommand();

                habitTableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS habits(
                habit_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                habit_name varchar(125) NOT NULL UNIQUE,
                quantity_name varchar(125) NOT NULL,
                default_quantity 
                )";

                occurencesTableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS occurences (
                occurence_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                habit_id INTEGER, 
                habit_quantity INTEGER NOT NULL,
                date TEXT NOT NULL,
                FOREIGN KEY (habit_id) REFERENCES habits (habit_id)
                )";

                var result = habitTableCmd.ExecuteNonQuery();
                occurencesTableCmd.ExecuteNonQuery();

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
                    @"INSERT OR IGNORE INTO habits(habit_name, quantity_name, default_quantity) VALUES('Water drank', 'Glasses', 1);
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name, default_quantity) VALUES('Miles Ran', 'Miles', 2);
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name, default_quantity) VALUES('Mario Levels Completed', 'Levels', 5);
                  INSERT OR IGNORE INTO habits(habit_name, quantity_name, default_quantity) VALUES('Book Pages Read', 'Pages', 30);
";
                habitsToAdd.ExecuteNonQuery();

                var occurencesToAdd = connection.CreateCommand();
                occurencesToAdd.CommandText =
                    $@"
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-02');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-04');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-06');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(1, 1, '2025-11-04');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(2, 1, '2025-11-03');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(2, 2, '2025-11-04');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(2, 3, '2025-11-05');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(2, 13, '2025-11-01');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(3, 4, '2025-11-08');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(3, 9, '2025-11-08');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(4, 10, '2025-11-01');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(4, 37, '2025-11-03');
                INSERT INTO occurences(habit_id, habit_quantity, date) VALUES(4, 54, '2025-11-07');
";
                occurencesToAdd.ExecuteNonQuery();

                var verifyInput = connection.CreateCommand();
                verifyInput.CommandText = @"select * from occurences;";
                List<Occurences> tableData = new();

                SqliteDataReader reader = verifyInput.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(new Occurences
                        {
                            occurenceId = reader.GetInt32(0),
                            habitId = reader.GetInt32(1),
                            habitQuantity = reader.GetInt32(2),
                            Date = DateTime.ParseExact(reader.GetString(3), "yyyy-MM-dd", new CultureInfo("en-US"))
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }

                connection.Close();

                Console.WriteLine("------------------------------------------");
                foreach (var occurences in tableData)
                {
                    Console.WriteLine($"{occurences.habitId} - {occurences.Date.ToString("yyyy-MM-dd")} - Quantity: {occurences.habitQuantity}");
                }
                Console.WriteLine("------------------------------------------");

            }

        }
    }
}