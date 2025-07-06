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
            Console.WriteLine("9. Please explain about Search|Sort");
            Console.WriteLine("10. Please explain about Collection|Generic Collection");
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
        
                Console.WriteLine("Exercise 1. Payment for Guest House...");
                CalculateGuestHousePayment();

                break;
            case 2:
                Console.WriteLine("Exercise 2. Payment for KTV...");
                CalculateKtvPayment();
                break;
            case 3:
                Console.WriteLine("Exercise 3. Please writing a program to sum a series of the numbers below...");
                break;
            case 4:
                Console.WriteLine("Exercise 4. Please writing a program to generate following pyramid of numbers...");
                break;
            case 5:
                Console.WriteLine("Exercise 5. Please writing a program to solve a general quadratic equation: (aX2+bX+c=0)...");
                break;
            case 6:
                Console.WriteLine("Exercise 6. Please create function to validate data as below...");
                break;
            case 7:
                Console.WriteLine("Exercise 7. Please create functions below...");
                break;
            case 8:
                Console.WriteLine("Exercise 8. Please do researching and explain about C# Naming Convention...");
                break;
            case 9:
                Console.WriteLine("Exercise 9. Please explain about Search|Sort");
                break;
            case 10:
                Console.WriteLine("Exercise 10. Please explain about Collection|Generic Collection...");
                break;
            case 11:
                Console.WriteLine("Exercise 11. Please create any kind of A lottery (or lotto) game by using C# Console Application...");
                break;
            default:
                Console.WriteLine("Unknown exercise.");
                break;
        }
    }

    static void CalculateGuestHousePayment()
    {
        const decimal pricePerDay = 15m;
        DateTime checkIn, checkOut;

        // Input check-in date and time
        while (true)
        {
            Console.Write("Enter check-in date and time (yyyy-MM-dd HH:mm): ");
            string checkInInput = Console.ReadLine();
            if (DateTime.TryParseExact(checkInInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out checkIn))
            {
                break;
            }
            Console.WriteLine("Invalid format. Please try again.");
        }

        // Input check-out date and time
        while (true)
        {
            Console.Write("Enter check-out date and time (yyyy-MM-dd HH:mm): ");
            string checkOutInput = Console.ReadLine();
            if (DateTime.TryParseExact(checkOutInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out checkOut))
            {
                if (checkOut > checkIn)
                    break;
                else
                    Console.WriteLine("Check-out must be after check-in. Please try again.");
            }
            else
            {
                Console.WriteLine("Invalid format. Please try again.");
            }
        }

        // Calculate number of days
        int totalDays = (int)(checkOut.Date - checkIn.Date).TotalDays + 1;

        // If checkout time is after 12:00pm, add one more day
        if (checkOut.TimeOfDay > new TimeSpan(12, 0, 0))
        {
            totalDays += 1;
        }

        decimal totalAmount = totalDays * pricePerDay;

        Console.WriteLine($"Total days charged: {totalDays}");
        Console.WriteLine($"Total amount to pay: ${totalAmount}");
    }

    static void CalculateKtvPayment()
    {
        const decimal pricePerHour = 3m;
        DateTime checkIn, checkOut;

        // Input check-in time
        while (true)
        {
            Console.Write("Enter check-in time (yyyy-MM-dd HH:mm): ");
            string checkInInput = Console.ReadLine();
            if (DateTime.TryParseExact(checkInInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out checkIn))
            {
                break;
            }
            Console.WriteLine("Invalid format. Please try again.");
        }

        // Input check-out time
        while (true)
        {
            Console.Write("Enter check-out time (yyyy-MM-dd HH:mm): ");
            string checkOutInput = Console.ReadLine();
            if (DateTime.TryParseExact(checkOutInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out checkOut))
            {
                if (checkOut > checkIn)
                    break;
                else
                    Console.WriteLine("Check-out must be after check-in. Please try again.");
            }
            else
            {
                Console.WriteLine("Invalid format. Please try again.");
            }
        }

        TimeSpan duration = checkOut - checkIn;
        int hours = duration.Hours + duration.Days * 24;
        int minutes = duration.Minutes;

        decimal totalHours = hours;

        if (minutes > 45)
        {
            totalHours += 1;
        }
        else if (minutes > 15)
        {
            totalHours += 0.5m;
        }
        else if (minutes > 0)
        {
            // If minutes are between 1 and 15, do not add extra time
        }

        decimal totalAmount = totalHours * pricePerHour;

        Console.WriteLine($"Total hours charged: {totalHours}");
        Console.WriteLine($"Total amount to pay: ${totalAmount}");
    }

}