using System;
using System.Data.SQLite;

namespace LifeInsuranceCode
{
    public class DatabaseHandler
    {
        private SQLiteConnection _connection;

        public DatabaseHandler(string databaseFilePath)
        {
            _connection = new SQLiteConnection($"Data Source={databaseFilePath};Version=3;");
            _connection.Open();
        }

        public void CreateTable()
        {
            string tableCreationQuery = @"
                CREATE TABLE IF NOT EXISTS Clients (
                    ClientID INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT,
                    LastName TEXT,
                    DateOfBirth TEXT,
                    Age INTEGER,
                    Height REAL,
                    Weight REAL,
                    NumMedications INTEGER,
                    Gender TEXT
                );";

            SQLiteCommand command = new SQLiteCommand(tableCreationQuery, _connection);
            command.ExecuteNonQuery();
        }

        public void AddClient(string firstName, string lastName, string dateOfBirth, int age, float height, float weight, int numMedications, string gender)
        {
            string insertQuery = @"
                INSERT INTO Clients (FirstName, LastName, DateOfBirth, Age, Height, Weight, NumMedications, Gender) 
                VALUES (@FirstName, @LastName, @DateOfBirth, @Age, @Height, @Weight, @NumMedications, @Gender);";

            SQLiteCommand command = new SQLiteCommand(insertQuery, _connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Height", height);
            command.Parameters.AddWithValue("@Weight", weight);
            command.Parameters.AddWithValue("@NumMedications", numMedications);
            command.Parameters.AddWithValue("@Gender", gender);

            command.ExecuteNonQuery();
        }

        public void ViewClients()
        {
            string selectQuery = @"
                SELECT ClientID, FirstName, LastName, DateOfBirth, Age, Height, Weight, NumMedications, Gender 
                FROM Clients";

            SQLiteCommand command = new SQLiteCommand(selectQuery, _connection);
            SQLiteDataReader reader = command.ExecuteReader();

            Console.WriteLine("Viewing all clients:");
            while (reader.Read())
            {
                int clientID = reader.GetInt32(0); // ClientID
                string firstName = reader.GetString(1); // FirstName
                string lastName = reader.GetString(2); // LastName
                string dateOfBirth = reader.GetString(3); // DateOfBirth
                int age = reader.GetInt32(4); // Age
                float height = reader.GetFloat(5); // Height
                float weight = reader.GetFloat(6); // Weight
                int numMedications = reader.GetInt32(7); // NumMedications
                string gender = reader.GetString(8); // Gender

                Console.WriteLine($"{clientID} - {firstName} {lastName} - {dateOfBirth} - {age} years old - Height: {height} cm - Weight: {weight} kg - Medications: {numMedications} - Gender: {gender}");
            }
        }

        public void DeleteClient(int clientId)
        {
            string deleteQuery = "DELETE FROM Clients WHERE ClientID = @ClientID;";
            SQLiteCommand command = new SQLiteCommand(deleteQuery, _connection);
            command.Parameters.AddWithValue("@ClientID", clientId);
            command.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
