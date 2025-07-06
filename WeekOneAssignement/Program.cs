internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Week One - Assigment Menu ====");
            Console.WriteLine("1. Payment for Guest House");
            Console.WriteLine("2. Payment for KTV");
            Console.WriteLine("3. Please writing a program to sum a series of the numbers below");
            Console.WriteLine("4. Please writing a program to generate following pyramid of numbers");
            Console.WriteLine("5. Please writing a program to solve a general quadratic equation: (aX2+bX+c=0)");
            Console.WriteLine("6. Please create function to validate data as below");
            Console.WriteLine("7. Please create functions below");
            Console.WriteLine("8. Please do researching and explain about C# Naming Convention");
            Console.WriteLine("9. Please explain about");
            Console.WriteLine("10. Please explain about");
            Console.WriteLine("11. Please create any kind of A lottery (or lotto) game by using C# Console Application");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option (0-11): ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int option) || option < 0 || option > 11)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            if (option == 0)
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            Console.WriteLine($"You selected Exercise {option}. Running...");
            RunExercise(option);

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

    }
    static void RunExercise(int number)
    {
        switch (number)
        {
            case 1:
                // Add your exercise logic here
                Console.WriteLine("Exercise 1 logic...");
                break;
            case 2:
                Console.WriteLine("Exercise 2 logic...");
                break;
            case 3:
                Console.WriteLine("Exercise 3 logic...");
                break;
            case 4:
                Console.WriteLine("Exercise 4 logic...");
                break;
            case 5:
                Console.WriteLine("Exercise 5 logic...");
                break;
            case 6:
                Console.WriteLine("Exercise 6 logic...");
                break;
            case 7:
                Console.WriteLine("Exercise 7 logic...");
                break;
            case 8:
                Console.WriteLine("Exercise 8 logic...");
                break;
            case 9:
                Console.WriteLine("Exercise 9 logic...");
                break;
            case 10:
                Console.WriteLine("Exercise 10 logic...");
                break;
            case 11:
                Console.WriteLine("Exercise 11 logic...");
                break;
            default:
                Console.WriteLine("Unknown exercise.");
                break;
        }
    }
}