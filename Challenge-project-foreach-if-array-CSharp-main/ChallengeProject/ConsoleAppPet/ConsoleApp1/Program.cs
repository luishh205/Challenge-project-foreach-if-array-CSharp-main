using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables that support data entry
            int maxPets = 8;
            string menuSelection = "";

            // array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 6];

            // Menu options
            Console.WriteLine("Please select an animal:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Cat with missing details");
            Console.WriteLine("Enter your choice (1-3):");

            // Read user input
            string readResult = Console.ReadLine();
            int numb;
            bool isValid = int.TryParse(readResult, out numb);

            if (isValid)
            {
                string animalSpecies = "";
                string animalID = "";
                string animalAge = "";
                string animalPhysicalDescription = "";
                string animalPersonalityDescription = "";
                string animalNickname = "";

                // Handle user selection
                switch (numb)
                {
                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "loki";
                        break;
                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "Puss";
                        break;
                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
                        break;
                }

                if (!string.IsNullOrEmpty(animalSpecies))
                {
                    Console.WriteLine($"Animal Species: {animalSpecies}");
                    Console.WriteLine($"Animal ID: {animalID}");
                    Console.WriteLine($"Animal Age: {animalAge}");
                    Console.WriteLine($"Animal Physical Description: {animalPhysicalDescription}");
                    Console.WriteLine($"Animal Personality Description: {animalPersonalityDescription}");
                    Console.WriteLine($"Animal Nickname: {animalNickname}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
        }
    }
}
