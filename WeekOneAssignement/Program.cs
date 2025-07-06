using System.Collections;

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
            Console.WriteLine("7. Please create functions to converting as below");
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
                SolveQuadraticEquation();
                break;
            case 6:
                Console.WriteLine("Exercise 6. Please create function to validate data as below...");
                ShowValidationMenu();
                break;
            case 7:
                Console.WriteLine("Exercise 7. Please create functions to converting as below...");
                ShowExercise7Menu();
                break;
            case 8:
                ExplainCSharpNamingConvention();
                break;
            case 9:
                ShowSearchAndSortMenu();
                break;
            case 10:
                Console.WriteLine("Exercise 10. Please explain about Collection|Generic Collection...");
                ShowCaseCollectionMenu();
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

    static void SolveQuadraticEquation()
    {
        float a, b, c, x, x1, x2, beta;

        // Input a, b, c
        Console.Write("Enter value for a: ");
        while (!float.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Invalid input. Enter a valid float for a: ");
        }

        Console.Write("Enter value for b: ");
        while (!float.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Invalid input. Enter a valid float for b: ");
        }

        Console.Write("Enter value for c: ");
        while (!float.TryParse(Console.ReadLine(), out c))
        {
            Console.Write("Invalid input. Enter a valid float for c: ");
        }

        // Special Case: a == 0
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("Infinite solutions (all real numbers are solutions).");
                }
                else
                {
                    Console.WriteLine("No solution (inconsistent equation).");
                }
            }
            else
            {
                x = -c / b;
                Console.WriteLine($"Linear equation. Single root: x = {x}");
            }
            return;
        }

        // Normal Case: a != 0
        beta = b * b - 4 * a * c;
        if (beta < 0)
        {
            Console.WriteLine("No real root.");
        }
        else if (beta == 0)
        {
            x = -b / (2 * a);
            Console.WriteLine($"One real root: x = {x}");
        }
        else
        {
            float sqrtBeta = (float)Math.Sqrt(beta);
            x1 = (-b - sqrtBeta) / (2 * a);
            x2 = (-b + sqrtBeta) / (2 * a);
            Console.WriteLine($"Two real roots: x1 = {x1}, x2 = {x2}");
        }
    }

    static void ShowValidationMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Data Validation Menu ====");
            Console.WriteLine("1. IsValidLength");
            Console.WriteLine("2. IsInteger");
            Console.WriteLine("3. IsFloat");
            Console.WriteLine("4. IsNumber");
            Console.WriteLine("5. IsDate");
            Console.WriteLine("6. IsDateTime");
            Console.WriteLine("7. IsLatinName");
            Console.WriteLine("8. IsKhmerName");
            Console.WriteLine("9. IsStrongPassword");
            Console.WriteLine("10. IsValidEmail");
            Console.WriteLine("11. IsValidWebsite");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option (0-11): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option) || option < 0 || option > 11)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }
            if (option == 0)
                break;

            string value = "";
            int length = 0;
            bool isValid = false;

            switch (option)
            {
                case 1:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    Console.Write("Enter required length: ");
                    if (!int.TryParse(Console.ReadLine(), out length))
                    {
                        Console.WriteLine("Invalid length. Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    isValid = IsValidLength(value, length);
                    Console.WriteLine(isValid ? "Valid length." : "Invalid length.");
                    break;
                case 2:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = int.TryParse(value, out _);
                    Console.WriteLine(isValid ? "Valid integer." : "Invalid integer.");
                    break;
                case 3:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = float.TryParse(value, out _);
                    Console.WriteLine(isValid ? "Valid float." : "Invalid float.");
                    break;
                case 4:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = double.TryParse(value, out _);
                    Console.WriteLine(isValid ? "Valid number." : "Invalid number.");
                    break;
                case 5:
                    Console.Write("Enter value to validate (yyyy-MM-dd): ");
                    value = Console.ReadLine();
                    isValid = DateTime.TryParseExact(value, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _);
                    Console.WriteLine(isValid ? "Valid date." : "Invalid date.");
                    break;
                case 6:
                    Console.Write("Enter value to validate (yyyy-MM-dd HH:mm): ");
                    value = Console.ReadLine();
                    isValid = DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out _);
                    Console.WriteLine(isValid ? "Valid date time." : "Invalid date time.");
                    break;
                case 7:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Za-z\s]+$");
                    Console.WriteLine(isValid ? "Valid Latin name." : "Invalid Latin name.");
                    break;
                case 8:
                    Console.OutputEncoding = System.Text.Encoding.UTF8; // Ensure console outputs Unicode correctly
                    Console.InputEncoding = System.Text.Encoding.UTF8;  // Ensure console reads Unicode input correctly
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();

                    // Improved Khmer Unicode validation: allow Khmer letters, spaces, and common Khmer punctuation
                    isValid = !string.IsNullOrEmpty(value) && System.Text.RegularExpressions.Regex.IsMatch(
                        value, @"^[\u1780-\u17FF\u200B\u25CC\u17D4\u17D6\s]+$");
                    Console.WriteLine(isValid ? "Valid Khmer name." : "Invalid Khmer name.");
                    break;
                case 9:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = IsStrongPassword(value);
                    Console.WriteLine(isValid ? "Strong password." : "Weak password.");
                    break;
                case 10:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = IsValidEmail(value);
                    Console.WriteLine(isValid ? "Valid email." : "Invalid email.");
                    break;
                case 11:
                    Console.Write("Enter value to validate: ");
                    value = Console.ReadLine();
                    isValid = Uri.TryCreate(value, UriKind.Absolute, out Uri uriResult) &&
                              (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    Console.WriteLine(isValid ? "Valid website." : "Invalid website.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static bool IsValidLength(string str, int ln)
    {
        if (string.IsNullOrEmpty(str)) return false;
        return str.Length == ln;
    }

    static bool IsStrongPassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8) return false;
        bool hasUpper = false, hasLower = false, hasDigit = false;
        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsLower(c)) hasLower = true;
            if (char.IsDigit(c)) hasDigit = true;
        }
        return hasUpper && hasLower && hasDigit;
    }

    static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    static void ShowExercise7Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For Khmer output
            Console.WriteLine("==== Exercise 7 Sub-Menu ====");
            Console.WriteLine("1. ConvertToKhmerNumber");
            Console.WriteLine("2. ReadNumberAsLatinText");
            Console.WriteLine("3. ReadNumberAsKhmerText");
            Console.WriteLine("4. ScanInteger");
            Console.WriteLine("5. ScanFloat");
            Console.WriteLine("6. ScanDate");
            Console.WriteLine("7. ScanNumeric (min/max)");
            Console.WriteLine("8. GetKhmerDateFormat");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option (0-8): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option) || option < 0 || option > 8)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }
            if (option == 0)
                break;

            switch (option)
            {
                case 1:
                    Console.Write("Enter a string with numbers: ");
                    string str = Console.ReadLine();
                    Console.WriteLine("Khmer number: " + ConvertToKhmerNumber(str));
                    break;
                case 2:
                    Console.Write("Enter a number: ");
                    if (double.TryParse(Console.ReadLine(), out double latinNum))
                        Console.WriteLine("Latin text: " + ReadNumberAsLatinText(latinNum));
                    else
                        Console.WriteLine("Invalid number.");
                    break;
                case 3:
                    Console.Write("Enter a number: ");
                    if (double.TryParse(Console.ReadLine(), out double khmerNum))
                        Console.WriteLine("Khmer text: " + ReadNumberAsKhmerText(khmerNum));
                    else
                        Console.WriteLine("Invalid number.");
                    break;
                case 4:
                    int intVal = ScanInteger();
                    Console.WriteLine("Scanned integer: " + intVal);
                    break;
                case 5:
                    float floatVal = ScanFloat();
                    Console.WriteLine("Scanned float: " + floatVal);
                    break;
                case 6:
                    DateTime dateVal = ScanDate();
                    Console.WriteLine("Scanned date: " + dateVal.ToString("yyyy-MM-dd"));
                    break;
                case 7:
                    Console.Write("Enter min value: ");
                    double min = double.TryParse(Console.ReadLine(), out min) ? min : 0;
                    Console.Write("Enter max value: ");
                    double max = double.TryParse(Console.ReadLine(), out max) ? max : 100;
                    double numVal = ScanNumeric(min, max);
                    Console.WriteLine("Scanned number: " + numVal);
                    break;
                case 8:
                    Console.Write("Enter date (yyyy-MM-dd): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime khmerDate))
                        Console.WriteLine("Khmer date: " + GetKhmerDateFormat(khmerDate));
                    else
                        Console.WriteLine("Invalid date.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static string ConvertToKhmerNumber(string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        char[] khmerDigits = { '០', '១', '២', '៣', '៤', '៥', '៦', '៧', '៨', '៩' };
        var result = new System.Text.StringBuilder();
        foreach (char c in str)
        {
            if (char.IsDigit(c))
                result.Append(khmerDigits[c - '0']);
            else
                result.Append(c);
        }
        return result.ToString();
    }

   
    static string ReadNumberAsLatinText(double num)
    {
        // For brevity, use built-in ToString for now. For full text, use a library or implement number-to-words.
        return num.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
    }

   
    static string ReadNumberAsKhmerText(double num)
    {
        // For demonstration, just convert digits to Khmer numerals
        return ConvertToKhmerNumber(num.ToString());
    }


    static int ScanInteger()
    {
        int value;
        while (true)
        {
            Console.Write("Enter an integer: ");
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid integer. Try again.");
        }
    }


    static float ScanFloat()
    {
        float value;
        while (true)
        {
            Console.Write("Enter a float: ");
            if (float.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid float. Try again.");
        }
    }


    static DateTime ScanDate()
    {
        DateTime value;
        while (true)
        {
            Console.Write("Enter a date (yyyy-MM-dd): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out value))
                return value;
            Console.WriteLine("Invalid date. Try again.");
        }
    }

    static double ScanNumeric(double minValue, double maxValue)
    {
        double value;
        while (true)
        {
            Console.Write($"Enter a number between {minValue} and {maxValue}: ");
            if (double.TryParse(Console.ReadLine(), out value) && value >= minValue && value <= maxValue)
                return value;
            Console.WriteLine("Invalid number or out of range. Try again.");
        }
    }

 
    static string GetKhmerDateFormat(DateTime date)
    {
        string[] khmerDays = { "អាទិត្យ", "ច័ន្ទ", "អង្គារ", "ពុធ", "ព្រហស្បតិ៍", "សុក្រ", "សៅរ៍" };
        string[] khmerMonths = { "", "មករា", "កុម្ភៈ", "មីនា", "មេសា", "ឧសភា", "មិថុនា", "កក្កដា", "សីហា", "កញ្ញា", "តុលា", "វិច្ឆិកា", "ធ្នូ" };
        string dayName = "ថ្ងៃ" + khmerDays[(int)date.DayOfWeek];
        string dayNum = "ទី" + ConvertToKhmerNumber(date.Day.ToString());
        string month = "ខែ" + khmerMonths[date.Month];
        string year = "ឆ្នាំ" + ConvertToKhmerNumber(date.Year.ToString());
        return $"{dayName} {dayNum} {month} {year}";
    }

    static void ExplainCSharpNamingConvention()
    {
        Console.Clear();
        Console.WriteLine("==== C# Naming Convention Explanation ====\n");
        Console.WriteLine("C# naming conventions help make code readable, maintainable, and consistent.");
        Console.WriteLine("Here are the most important conventions with examples:\n");

        Console.WriteLine("1. PascalCase");
        Console.WriteLine("   - Used for: Class, Method, Property, Namespace, Enum names");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     public class StudentInfo {");
        Console.WriteLine("         public string FirstName { get; set; }");
        Console.WriteLine("         public void PrintDetails() { }");
        Console.WriteLine("     }\n");

        Console.WriteLine("2. camelCase");
        Console.WriteLine("   - Used for: Local variables, method parameters, private fields (sometimes with _ prefix)");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     void CalculateTotal(int itemCount, double itemPrice) {");
        Console.WriteLine("         double totalAmount = itemCount * itemPrice;");
        Console.WriteLine("     }\n");

        Console.WriteLine("3. ALL_CAPS_WITH_UNDERSCORES");
        Console.WriteLine("   - Used for: Constants and static readonly fields");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     public const double PI = 3.14159;");
        Console.WriteLine("     private static readonly int MAX_SIZE = 100;\n");

        Console.WriteLine("4. Interface Names");
        Console.WriteLine("   - Start with 'I' and use PascalCase");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     public interface IRepository { }\n");

        Console.WriteLine("5. Event Names");
        Console.WriteLine("   - Use PascalCase, usually a verb or verb phrase");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     public event EventHandler DataLoaded;\n");

        Console.WriteLine("6. Namespace Names");
        Console.WriteLine("   - Use PascalCase, match project structure");
        Console.WriteLine("   - Example:");
        Console.WriteLine("     namespace MyCompany.Project.Module { }\n");

        Console.WriteLine("Summary Table:");
        Console.WriteLine("Element      | Convention   | Example");
        Console.WriteLine("-------------|-------------|----------------------");
        Console.WriteLine("Class        | PascalCase  | StudentInfo");
        Console.WriteLine("Method       | PascalCase  | PrintDetails()");
        Console.WriteLine("Property     | PascalCase  | FirstName");
        Console.WriteLine("Variable     | camelCase   | totalAmount");
        Console.WriteLine("Constant     | ALL_CAPS    | PI, MAX_SIZE");
        Console.WriteLine("Interface    | I + Pascal  | IRepository");
        Console.WriteLine("Namespace    | PascalCase  | MyCompany.Project\n");

        Console.WriteLine("References:");
        Console.WriteLine(" - https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions");
        Console.WriteLine(" - https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines\n");

        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void ExplainSearchAndSort()
    {
        Console.Clear();
        Console.WriteLine("==== Search and Sort Explanation ====\n");
        Console.WriteLine("Search and Sort are fundamental operations in computer science and programming.");
        Console.WriteLine("Here is an overview of common algorithms and their use cases:\n");

        Console.WriteLine("1. Search Algorithms:");
        Console.WriteLine("   - Linear Search:");
        Console.WriteLine("     * Description: Iterates through each element in a list to find the target.");
        Console.WriteLine("     * Complexity: O(n)");
        Console.WriteLine("     * Use Case: Small datasets or unsorted lists.\n");

        Console.WriteLine("   - Binary Search:");
        Console.WriteLine("     * Description: Divides a sorted list into halves to find the target.");
        Console.WriteLine("     * Complexity: O(log n)");
        Console.WriteLine("     * Use Case: Large datasets that are sorted.\n");

        Console.WriteLine("2. Sort Algorithms:");
        Console.WriteLine("   - Bubble Sort:");
        Console.WriteLine("     * Description: Repeatedly swaps adjacent elements if they are in the wrong order.");
        Console.WriteLine("     * Complexity: O(n^2)");
        Console.WriteLine("     * Use Case: Educational purposes or very small datasets.\n");

        Console.WriteLine("   - Quick Sort:");
        Console.WriteLine("     * Description: Divides the list into smaller sublists based on a pivot element.");
        Console.WriteLine("     * Complexity: O(n log n) on average.");
        Console.WriteLine("     * Use Case: General-purpose sorting.\n");

        Console.WriteLine("   - Merge Sort:");
        Console.WriteLine("     * Description: Divides the list into halves, sorts each half, and merges them.");
        Console.WriteLine("     * Complexity: O(n log n)");
        Console.WriteLine("     * Use Case: Sorting linked lists or datasets requiring stable sorting.\n");

        Console.WriteLine("3. Applications:");
        Console.WriteLine("   - Search and Sort are used in databases, file systems, and data analysis.");
        Console.WriteLine("   - Efficient algorithms improve performance in real-world applications.\n");

        Console.WriteLine("References:");
        Console.WriteLine(" - https://en.wikipedia.org/wiki/Search_algorithm");
        Console.WriteLine(" - https://en.wikipedia.org/wiki/Sorting_algorithm\n");

        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void ShowSearchAndSortMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Search & Sort Menu ====");
            Console.WriteLine("1. Documentation (Explain Search & Sort)");
            Console.WriteLine("2. Test Search & Sort Algorithms");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option (0-2): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option) || option < 0 || option > 2)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }
            if (option == 0)
                break;

            switch (option)
            {
                case 1:
                    ExplainSearchAndSort();
                    break;
                case 2:
                    TestSearchAndSort();
                    break;
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void TestSearchAndSort()
    {
        Console.Clear();
        int[] arr = { 5, 2, 9, 1, 7, 3 };
        Console.WriteLine("Original array: " + string.Join(", ", arr));

        // Linear Search
        Console.Write("Linear Search - Enter value to search: ");
        int target = int.TryParse(Console.ReadLine(), out target) ? target : 0;
        int idx = LinearSearch(arr, target);
        Console.WriteLine(idx >= 0 ? $"Found at index {idx}" : "Not found");

        // Binary Search (requires sorted array)
        Array.Sort(arr);
        Console.WriteLine("Sorted array for Binary Search: " + string.Join(", ", arr));
        Console.Write("Binary Search - Enter value to search: ");
        int bTarget = int.TryParse(Console.ReadLine(), out bTarget) ? bTarget : 0;
        int bIdx = BinarySearch(arr, bTarget);
        Console.WriteLine(bIdx >= 0 ? $"Found at index {bIdx}" : "Not found");

        // Bubble Sort
        int[] bubbleArr = { 5, 2, 9, 1, 7, 3 };
        BubbleSort(bubbleArr);
        Console.WriteLine("Bubble Sorted: " + string.Join(", ", bubbleArr));

        // Selection Sort
        int[] selArr = { 5, 2, 9, 1, 7, 3 };
        SelectionSort(selArr);
        Console.WriteLine("Selection Sorted: " + string.Join(", ", selArr));

        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target) return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == target) return mid;
            else if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }

    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[j] < arr[minIdx]) minIdx = j;
            int temp = arr[i];
            arr[i] = arr[minIdx];
            arr[minIdx] = temp;
        }
    }


    static void ShowCaseCollectionMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Generic and Non-Generic Collection ====");
            Console.WriteLine("1. Documentation (Explain Generic and Non-Generic Collection)");
            Console.WriteLine("2. Test Generic and Non-Generic Collection Algorithms");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option (0-2): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option) || option < 0 || option > 2)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }
            if (option == 0)
                break;

            switch (option)
            {
                case 1:
                    ExplainGenericAndNonGenericCollection();
                    break;
                case 2:
                    TestGenericAndNonGenericCollection();
                    break;
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ExplainGenericAndNonGenericCollection()
    {
        Console.WriteLine("=== .NET Core Collections and Generic Collections ===\n");

        Console.WriteLine("1. Non-Generic Collections:");
        Console.WriteLine("- Found in System.Collections");
        Console.WriteLine("- Store any type as object (no type safety)");
        Console.WriteLine("- Examples: ArrayList, Hashtable, Stack, Queue\n");

        Console.WriteLine("2. Generic Collections:");
        Console.WriteLine("- Found in System.Collections.Generic");
        Console.WriteLine("- Type-safe and better performance");
        Console.WriteLine("- Examples: List<T>, Dictionary<TKey,TValue>, HashSet<T>, Queue<T>\n");

        Console.WriteLine("3. Differences:");
        Console.WriteLine("- Generic collections prevent runtime errors by enforcing type safety.");
        Console.WriteLine("- Non-generic collections are legacy and may cause boxing/unboxing issues.\n");

        Console.WriteLine("4. Recommendation:");
        Console.WriteLine("- Always prefer generic collections in modern .NET applications.\n");


        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void TestGenericAndNonGenericCollection()
    {
        Console.WriteLine("=== Test: Non-Generic Collection (ArrayList) ===");

        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);             // int
        arrayList.Add("Hello");       // string
        arrayList.Add(DateTime.Now);  // DateTime

        foreach (var item in arrayList)
        {
            Console.WriteLine($"[ArrayList] Value: {item} (Type: {item.GetType()})");
        }

        // Casting required
        int numFromArrayList = (int)arrayList[0];
        Console.WriteLine($"First item cast to int: {numFromArrayList}\n");

        Console.WriteLine("=== Test: Generic Collection (List<int>) ===");

        List<int> intList = new List<int> { 10, 20, 30 };
        foreach (int number in intList)
        {
            Console.WriteLine($"[List<int>] Value: {number}");
        }

        int numFromList = intList[1]; // No cast needed
        Console.WriteLine($"Second item in List<int>: {numFromList}\n");





        Console.WriteLine("=== Test: Generic Collection (Dictionary<string, int>) ===");

        Dictionary<string, int> scores = new Dictionary<string, int>
            {
                { "Alice", 90 },
                { "Bob", 75 }
            };

        foreach (var entry in scores)
        {
            Console.WriteLine($"[Dictionary] Key: {entry.Key}, Value: {entry.Value}");
        }


        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }
}