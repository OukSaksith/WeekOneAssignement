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
                ShowSumSeriesMenu();
                break;
            case 4:
                Console.WriteLine("Exercise 4. Please writing a program to generate following pyramid of numbers...");
                GenerateNumberPyramid();
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

    static void ShowSumSeriesMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Sum Series Sub-Menu ====");
            Console.WriteLine("1. Sum of n + (n-1) + (n-2) + ... + 1");
            Console.WriteLine("2. Sum of 1 + 3 + 5 + ... + n (odd numbers)");
            Console.WriteLine("3. Sum of 1 + 2 + 4 + 6 + 8 + ... + n (1, then all even numbers up to n)");
            Console.WriteLine("4. Sum of 1^2 + 2^2 + 3^2 + ... + n^2");
            Console.WriteLine("5. Sum of 1^2 + 3^2 + 5^2 + ... + n^2 (odd squares)");
            Console.WriteLine("6. Sum of 1^2 + 2^2 + 4^2 + ... + n^2 (1^2, then all even squares up to n^2)");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option (0-6):");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option) || option < 0 || option > 7)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            if (option == 0)
                break;

            Console.Write("Enter N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("Invalid N. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine($"Sum of n + (n-1) + ... + 1 where n={n}: {SumDescendingTo1(n)}");
                    break;
                case 2:
                    Console.WriteLine($"Sum of 1 + 3 + 5 + ... + n: {SumOddSeriesToN(n)}");
                    break;
                case 3:
                    Console.WriteLine($"Sum of 1 + 2 + 4 + 6 + 8 + ... + n: {SumOneAndEvensToN(n)}");
                    break;
                case 4:
                    Console.WriteLine($"Sum of 1^2 + 2^2 + ... + {n}^2: {SumSquaresToN(n)}");
                    break;
                case 5:
                    Console.WriteLine($"Sum of 1^2 + 3^2 + ... + {n}^2: {SumOddSquaresToN(n)}");
                    break;
                case 6:
                    Console.WriteLine($"Sum of 1^2 + 2^2 + 4^2 + ... + {n}^2: {SumOneAndEvenSquaresToN(n)}");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    static int SumDescendingTo1(int n)
    {
        int sum = 0;
        for (int i = n; i >= 1; i--)
            sum += i;
        return sum;
    }

    static int SumOddSeriesToN(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i += 2)
            sum += i;
        return sum;
    }

    static int SumOneAndEvensToN(int n)
    {
        int sum = 1;
        for (int i = 2; i <= n; i += 2)
            sum += i;
        return sum;
    }

    static int SumSquaresToN(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
            sum += i * i;
        return sum;
    }

    static int SumOddSquaresToN(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i += 2)
            sum += i * i;
        return sum;
    }

    static int SumOneAndEvenSquaresToN(int n)
    {
        int sum = 1 * 1;
        for (int i = 2; i <= n; i += 2)
            sum += i * i;
        return sum;
    }

    static void GenerateNumberPyramid()
    {
        int rows = 7;
        int maxWidth = (rows - 1) * 2 + 1; // The width of the last row (number of digits)

        for (int i = 0; i < rows; i++)
        {
            // Build the line as a string
            var line = new System.Text.StringBuilder();

            // Descending part
            for (int j = i; j >= 0; j--)
            {
                line.Append(j);
            }
            // Ascending part
            for (int j = 1; j <= i; j++)
            {
                line.Append(j);
            }

            // Calculate padding for center alignment
            int padding = (maxWidth - line.Length) / 2;
            Console.Write(new string(' ', padding));
            Console.WriteLine(line.ToString());
        }
    }
}