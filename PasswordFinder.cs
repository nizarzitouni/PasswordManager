using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Globalization;

namespace PasswordManager
{
    internal class PasswordManager
    {

        static List<PasswordModel> passwords = new List<PasswordModel>();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string passwordsFilePath = "passwords.csv";
            // string passwordsFilePath = "passwordsOrigine.csv";
            passwords = ReadPasswordsFromCsv(passwordsFilePath);

            bool exit = false;


            do
            {
                Console.Clear(); // Clear the console screen
                DisplayMenu(); // Display the menu options
                string? choice = Console.ReadLine(); // Read user input

                switch (choice)
                {
                    case "1":
                        SearchByPassword();
                        break;
                    case "2":
                        exit = true; // Exit the loop and terminate the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(); // Wait for user to press a key before continuing

            } while (!exit);

        }


        private static List<PasswordModel> ReadPasswordsFromCsv(string passwordsFilePath)
        {
            var passwordModels = new List<PasswordModel>();
            using (var reader = new StreamReader(passwordsFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null, // Ignore header validation
            }))
            {
                // Register the custom class map for PasswordModel
                csv.Context.RegisterClassMap<PasswordMap>();
                // GetRecords will automatically use the constructor with parameters based on the mapping
                passwordModels = csv.GetRecords<PasswordModel>().ToList();
            }
            return passwordModels;
        }

        // Method to display menu options
        private static void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Password Manager");
            Console.WriteLine("1. Search by Password");
            Console.WriteLine("2. Exit");
            Console.Write("\nEnter your choice: ");
        }

        // Method to search by password
        private static void SearchByPassword()
        {
            Console.Write("Enter the password or the beginning of the password: ");
            string? searchTerm = Console.ReadLine();

            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("No search term provided.");
                return;
            }

            List<PasswordModel> matchingPasswords = new List<PasswordModel>();

            foreach (PasswordModel password in passwords)
            {
                if (password.PasswordValue != null && password.PasswordValue.StartsWith(searchTerm))
                {
                    matchingPasswords.Add(password);
                }
            }

            DisplaySearchResults(matchingPasswords);
        }


        // Method to display search results
        private static void DisplaySearchResults(List<PasswordModel> results)
        {
            if (results.Count == 0)
            {
                Console.WriteLine("No matching passwords found.");
            }
            else
            {
                Console.WriteLine("Matching passwords:\n");
                foreach (PasswordModel password in results)
                {
                    Console.WriteLine($"[x] URL: {password.Url}");
                    Console.WriteLine($"    Username: {password.Username}");
                    Console.WriteLine($"    Password: {password.PasswordValue}");
                    Console.WriteLine();
                }
            }
        }
    }
}