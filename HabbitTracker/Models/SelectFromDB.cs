using HabitTracker.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace HabbitTracker.Models
{
    internal class SelectFromDB
    {
        string connectionString = @"Data Source=habit-tracker.db";
        public List<HabitOccurence> GetAllRecords()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT occurences.habit_id, habit_name, occurence_id, habit_quantity, date, quantity_name FROM occurences 
                    LEFT JOIN habits on habits.habit_id = occurences.habit_id;
                    ";

                List<HabitOccurence> result = new List<HabitOccurence>();

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new HabitOccurence
                        {
                            habitId = reader.GetInt32(0),
                            habitName = reader.GetString(1),
                            occurenceId = reader.GetInt32(2),
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

                foreach (HabitOccurence occurence in result)
                {
                    Console.WriteLine($"{occurence.date.ToString("yyyy-MM-dd")}: {occurence.habitName} {occurence.habitQuantity} {occurence.quantityName}");
                }

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
    }
}