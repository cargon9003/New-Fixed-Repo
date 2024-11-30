using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace LifeInsuranceCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Life Insurance Client Management System!");

            string dbPath = "ClientDatabase.sqlite"; // SQLite database file
            DatabaseHandler dbHandler = new DatabaseHandler(dbPath);

            // Create table if it doesn't exist
            dbHandler.CreateTable();

            while (true)
            {
                // Main menu options
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Client");
                Console.WriteLine("2. View All Clients");
                Console.WriteLine("3. Delete Client");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Client
                        AddClient(dbHandler);
                        break;
                    case "2":
                        // View All Clients
                        dbHandler.ViewClients();
                        break;
                    case "3":
                        // Delete Client
                        DeleteClient(dbHandler);
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddClient(DatabaseHandler dbHandler)
        {
            Console.WriteLine("\nEnter First Name:");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Date of Birth (YYYY-MM-DD):");
            string dateOfBirth = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Age:");
            int age = int.TryParse(Console.ReadLine(), out int parsedAge) ? parsedAge : 0;

            Console.WriteLine("Enter Height (in cm):");
            float height = float.TryParse(Console.ReadLine(), out float parsedHeight) ? parsedHeight : 0f;

            Console.WriteLine("Enter Weight (in kg):");
            float weight = float.TryParse(Console.ReadLine(), out float parsedWeight) ? parsedWeight : 0f;

            Console.WriteLine("Enter Number of Medications:");
            int numMedications = int.TryParse(Console.ReadLine(), out int parsedMedications) ? parsedMedications : 0;

            Console.WriteLine("Enter Gender (Male/Female):");
            string gender = Console.ReadLine() ?? string.Empty;

            // Add the client to the database
            dbHandler.AddClient(firstName, lastName, dateOfBirth, age, height, weight, numMedications, gender);

            Console.WriteLine("Client added successfully!");
        }

        static void DeleteClient(DatabaseHandler dbHandler)
        {
            Console.WriteLine("\nEnter Client ID to delete:");
            int clientId = int.TryParse(Console.ReadLine(), out int parsedClientId) ? parsedClientId : 0;

            dbHandler.DeleteClient(clientId);

            Console.WriteLine("Client deleted successfully!");
        }
    }
}
