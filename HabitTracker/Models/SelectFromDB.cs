using HabitTracker.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace HabitTracker.Models
{
    internal class SelectFromDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public List<HabitOccurrence> GetAllRecords()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT occurrences.habit_id, habit_name, occurrence_id, habit_quantity, date, quantity_name FROM occurrences 
                    LEFT JOIN habits on habits.habit_id = occurrences.habit_id;
                    ";

                List<HabitOccurrence> result = new List<HabitOccurrence>();

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new HabitOccurrence
                        {
                            habitId = reader.GetInt32(0),
                            habitName = reader.GetString(1),
                            occurrenceId = reader.GetInt32(2),
                            habitQuantity = reader.GetInt32(3),
                            date = DateTime.ParseExact(reader.GetString(4), "yyyy-MM-dd", new CultureInfo("en-US")),
                            quantityName = reader.GetString(5)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No records found.");
                }

                connection.Close();

                return result;
            }
        }

        public List<Habit> GetAllHabits()
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from habits;";

                SqliteDataReader reader = command.ExecuteReader();

                List<Habit> result = new List<Habit>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Habit
                        {
                            habitId = reader.GetInt32(0),
                            habitName = reader.GetString(1),
                            quantityName = reader.GetString(2),
                            defaultQuantity = reader.GetInt32(3)
                        });
                    }


                }
                else
                {
                    Console.WriteLine("No habits found.");
                }
                return result;
            }

        }

        public List<int> GetAvailableIds()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT occurrence_id FROM occurrences;";

                SqliteDataReader reader = command.ExecuteReader();
                List<int> result = new();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0));
                    }
                }
                else
                {
                    Console.WriteLine("No Occurrences found.");
                }
                return result;
            }
        }
    }
}