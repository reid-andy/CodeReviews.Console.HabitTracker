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
                            date = reader.GetString(4),
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
                        string habitName = reader.GetString(1);
                        string quantityName = reader.GetString(2);
                        int habitId = reader.GetInt32(0);
                        result.Add(new Habit(habitName, quantityName, habitId));
                    }
                }
                else
                {
                    Console.WriteLine("No habits found.");
                }
                return result;
            }

        }

        public List<String[]> GetLifetimeTotals()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT habit_name, SUM(habit_quantity), quantity_name FROM occurrences " +
                    "LEFT JOIN habits ON habits.habit_id = occurrences.habit_id GROUP BY habit_name;";

                List<String[]> result = new();

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] reportItem = [reader.GetString(0), reader.GetString(1), reader.GetString(2)];
                        result.Add(reportItem);
                    }

                }
                return result;
            }
        }
    }
}