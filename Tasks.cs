using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using OopPractice;

namespace Tasks;

public class Tasks {
    public void FirstTask()
    {
        string? name = string.Empty;
        int age = 0;
        string? city = string.Empty;
        decimal salary = 0;
        bool isCorrect = false;
        while(!isCorrect)
        {
            Console.WriteLine("Введите ваше имя:");
            name = Console.ReadLine();

            Console.WriteLine("Введите ваш возраст:");
            bool successAge = int.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Введите ваш город проживания:");
            city = Console.ReadLine();

            Console.WriteLine("Введите желаемую зарплату (EUR):");
            bool successSalary = decimal.TryParse(Console.ReadLine(), out salary);

            isCorrect =
                !string.IsNullOrWhiteSpace(name) &&
                successAge &&
                age > 0 &&
                !string.IsNullOrWhiteSpace(city) &&
                successSalary &&
                salary > 0;

            if (!isCorrect)
            {
                Console.WriteLine("Заполните информацию корректно!");
            }
        }

        Console.WriteLine($"Привет, {name}!\nТебе {age} лет.\nТы живешь в городе {city}.\nТвоя желаемая зарплата {salary} EUR.");
    }

    public void SecondTaskIfMethod()
    {
        const string adminLogin = "admin";
        const string adminPassword = "123456";

        bool isCorrect = false;

        while (!isCorrect)
        {
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            Console.Write("Введите возраст: ");

            bool successAge = int.TryParse(Console.ReadLine(), out int age);

            if (!successAge)
            {
                Console.WriteLine("Возраст должен быть числом!");
                continue;
            }

            if (login != adminLogin)
            {
                Console.WriteLine("Wrong login!");
                continue;
            }

            if (password != adminPassword)
            {
                Console.WriteLine("Wrong password!");
                continue;
            }

            if (age < 18)
            {
                Console.WriteLine("Adults only!");
                continue;
            }

            isCorrect = true;

            Console.WriteLine($"Добро пожаловать, {login}!");
        }
    }

    public void ThirdTaskMultiplyTable()
    {
        int number = 0;
        bool isCorrect = false;
        while (!isCorrect)
        {
            Console.WriteLine("Введите целое число: ");
            bool successNumber = int.TryParse(Console.ReadLine(), out number);
            if(successNumber)
            {
                isCorrect = true;
                Console.WriteLine("Таблица умножения для вашего числа: ");
                for (int i = 1; i <= 10; i++)
                {
                    int result = number * i;
                    Console.WriteLine($"{number} * {i} = {result}");
                }
                Console.WriteLine("\nТолько четный вывод: ");
                for (int i = 1; i <=10; i++)
                {
                    int resultEven = number * i;
                    if (resultEven % 2 == 0)
                    {
                        Console.WriteLine($"{number} * {i} = {resultEven}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат числа, попробуйте еще раз.");
            }
        }
    }

    public void FourthTaskArrays()
    {
        int[] numbers = {5, 2, 8, 1, 9, 10, 3, 7, 4, 6};
        Console.WriteLine("Данный массив: ");
        foreach(int number in numbers)
        {
            Console.Write($"{number} ");
        }

        int sumOfArray = 0;
        foreach(int number in numbers)
        {
            sumOfArray += number;
        }
        Console.WriteLine($"\nСумма данного массива равна: {sumOfArray}");

        int maxNumber = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if(maxNumber < numbers[i])
            {
                maxNumber = numbers[i];
            }
        }
        Console.WriteLine($"Максимальное число в массиве: {maxNumber}");
        
        int minNumber = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if(minNumber > numbers[i])
            {
                minNumber = numbers[i];
            }
        }
        Console.WriteLine($"Минимальное число в массиве: {minNumber}");

        int evenCounter = 0;
        Console.WriteLine("Четные числа в массиве: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.Write($"{numbers[i]} ");
                evenCounter++;
            }
        }
        Console.WriteLine($"\nКоличество четных чисел: {evenCounter}");
    }

    public void FourthTaskArraysSinglePassAlgorithm()
    {
        int[] numbers = { 5, 2, 8, 1, 9, 10, 3, 7, 4, 6 };
        int sum = 0;
        int max = numbers[0];
        int min = numbers[0];
        int evenCounter = 0;

        foreach(int number in numbers)
        {
            Console.Write($"{number} ");
            sum += number;

            if(max < number)
            {
                max = number;
            }

            if(min > number)
            {
                min = number;
            }

            if(number % 2 == 0)
            {
                evenCounter++;
            }
        }

        Console.WriteLine($"\nSum of array elements: {sum}");
        Console.WriteLine($"Max value: {max}");
        Console.WriteLine($"Min value: {min}");
        Console.WriteLine($"Amount of even numbers: {evenCounter}");
    }

    public void FifthTaskStringAnalysys()
    {
        string text = "  CSharp Backend Developer  ";
        Console.WriteLine(text);

        string noWhiteSpaces = text.Trim();
        Console.WriteLine(noWhiteSpaces);

        string upperText = noWhiteSpaces.ToUpper();
        Console.WriteLine(upperText);

        string lowerText = noWhiteSpaces.ToLower();
        Console.WriteLine(lowerText);

        if (noWhiteSpaces.Contains("Backend"))
        {
            Console.WriteLine($"string contains word {"Backend"} ");
        }
        else
        {
            Console.WriteLine("There are no such words");
        }

        string[] wordsOutOfText = noWhiteSpaces.Split(" ");
        foreach(string word in wordsOutOfText)
        {
            Console.WriteLine(word);
        }

        string noSpaces = noWhiteSpaces.Replace(" ", "");
        Console.WriteLine($"letters without whitespaces: {noSpaces.Length}");
    }

    public void TaskNumberSixListCS()
    {
        var users = new List<string>();

        users.Add("admin");
        users.Add("Vlad");
        users.Add("Lera");
        users.Add("Wadim");
        users.Add("God");

        users.AddRange(new [] {"Mutant", "Vampire"});

        foreach (string user in users)
        {
            Console.Write(user + " ");
        }

        Console.WriteLine($"\nКоличество пользователей: {users.Count}");
        
        if (users.Contains("admin"))
        {
            Console.WriteLine("Admin found");
        }

        Console.WriteLine($"User {users[1]} was deleted");
        users.Remove(users[1]);
        Console.WriteLine($"Количество пользователей: {users.Count}");

        users.Insert(0, "superadmin");
        Console.WriteLine($"User {users[0]} was added");
        Console.WriteLine($"Количество пользователей: {users.Count}");

        users.Sort();
        foreach(string user in users)
        {
            Console.Write(user + " ");
        }

        string longestUsername = users[0];
        foreach (string user in users)
        {
            if (longestUsername.Length < user.Length)
            {
                longestUsername = user;
            }
        }
        Console.WriteLine ($"\nLongest username: {longestUsername}");
    }

    public void TaskNumberSevenDictionary()
    {
        Dictionary<string, string> contacts = new ();

        contacts.Add("Vlad", "+375447122520");
        contacts.Add("Lera", "+375447224520");
        contacts.Add("Wadim", "+37529123123");
        contacts.Add("Kirill", "+375337152530");
        contacts.Add("admin", "+375296488767");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Key}, {contact.Value}");
        }

        if (contacts.ContainsKey("admin"))
        {
            Console.WriteLine("admin found");
        }

        if(contacts.TryGetValue("admin", out string? phoneNumber))
        {
            Console.WriteLine($"phone number of admin is {phoneNumber}");
        }

        contacts.Remove("Vlad");
        Console.WriteLine($"Contacts amount is {contacts.Count()}");

        string longestName = "";
        foreach(var contact in contacts)
        {
            if(contact.Key.Length > longestName.Length)
            {
                longestName = contact.Key;
            }
        }
        Console.WriteLine($"Longest contact name is {longestName}");
    }

    //task number eight

    public void TaskNumberEightMethods()
    {
        //1
        Console.WriteLine(Sum(4, 6));
        //2
        IsAdult(23);
        //3
        Console.WriteLine(GetGreeting("Vlad"));
        //4
        List<string> users = new ();
        users.Add("Vlad");
        users.Add("Lera");
        users.Add("admin");
        PrintUsers(users);
    }

    public int Sum(int a, int b)
    {
        return a + b;
    }

    public bool IsAdult (int age)
    {
        if (age >= 18)
        {
            Console.WriteLine("Access granted!");
            return true;
        }
        else
        {
            Console.WriteLine("You're not an adult!");
            return false;
        }
    }

    public string GetGreeting(string name)
    {
        return $"Hello, {name}!";
    }

    public void PrintUsers(List<string> users)
    {
        foreach(var user in users)
        {
            Console.Write($"{user} ");
        }
    }

    public void DelegatePractice()
    {
        Func<int, int ,int> multiply = (a, b) => a * b;
        Console.WriteLine(multiply(4, 5));

        Action<string> print = Console.WriteLine;
        print("Test");

        Predicate<int> isEven = a => a % 2 == 0;
        Console.WriteLine(isEven(288));

        int bonus = 10;
        Func<int, int> salaryWithBonus = x => x * bonus;
        Console.WriteLine(salaryWithBonus(200));

        List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };

        foreach (int number in numbers)
        {
            if (isEven(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    public static int SumLambda(int a, int b) => a + b;
    public static int MultiplyLambda(int x, int y) => x * y;

    public delegate int MathOperations(int a, int b);

    public void DelegateOutput()
    {
        MathOperations operationSum = SumLambda;
        Console.WriteLine(operationSum(10, 20));
        MathOperations operationMultiply = MultiplyLambda;
        Console.WriteLine(operationMultiply(12, 12));
    }

    public void LinqWherePractice()
    {
        List<int> numbers = new List<int> { 1, 5, 8, 10, 13, 20, 25, 30 };
        List<int> result = new();

        result = numbers.Where(number => number > 10).ToList();
        foreach (var r in result)
        {
            Console.Write(r + " ");
        }
        Console.WriteLine("\n");

        result = numbers.Where(number => number % 2 == 0).ToList();
        foreach (var r in result)
        {
            Console.Write(r + " ");
        }
        Console.WriteLine("\n");

        result = numbers.Where(number => number >= 5 && number <= 20).ToList();
        foreach (var r in result)
        {
            Console.Write(r + " ");
        }
    }

    public void LinqSelectPractice()
    {
        List<int> numbers = new List<int> { 1, 5, 8, 10 };
        foreach(int n in numbers)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        List<int> multipliedNumbers = numbers.Select(number => number * 2).ToList();
        foreach(var m in multipliedNumbers)
        {
            Console.Write(m + " ");
        }
        Console.WriteLine();

        List<string> intToStringList = numbers.Select(number => $"Number: {number}").ToList(); 
        foreach(var its in intToStringList)
        {
            Console.Write(its + " ");
        }
        Console.WriteLine();

        List<int> squareList = numbers.Select(number => number * number).ToList();
        foreach(var square in squareList)
        {
            Console.Write(square + " ");
        }
    }

    public void LinqWhereSelectPractice()
    {
        List<int> numbers = new List<int> { 1, 5, 8, 10, 13, 20, 25, 30 };
        foreach(int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        List<int> greaterThanTenThenMultiplied = numbers
            .Where(number => number > 10)
            .Select(number => number * 2)
            .ToList();
        foreach(var gtm in greaterThanTenThenMultiplied)
        {
            Console.Write(gtm + " ");
        }
        Console.WriteLine();

        List<string> onlyEvenToList = numbers
            .Where(number => number % 2 == 0)
            .Select(number => $"Number: {number}")
            .ToList();
        foreach(var oe in onlyEvenToList)
        {
            Console.Write(oe + " ");
        }
        Console.WriteLine();

        List<int> squares = numbers
            .Where(number => number >= 5 && number <= 20)
            .Select(number => number * number)
            .ToList();
        foreach(var square in squares)
        {
            Console.Write(square + " ");
        }
    }

    public void LinqOrderByPractice()
    {
        List<int> numbers = new List<int> { 5, 1, 10, 3, 8 };
        foreach(var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        
        List<int> sorted = numbers
            .OrderBy(number => number)
            .ToList();
        foreach(var s in sorted)
        {
            Console.Write(s + " ");
        }
        Console.WriteLine();

        List<int> descSorted = numbers
            .OrderByDescending(number => number)
            .ToList();
        foreach(var ds in descSorted)
        {
            Console.Write(ds + " ");
        }
        Console.WriteLine();

        List<string> names = new List<string> { "Vlad", "Anna", "Kirill", "Bob", "Alexandra" };
        foreach(var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();

        List<string> sortByName = names
            .OrderBy(name => name)
            .ToList();
        foreach(var sbn in sortByName)
        {
            Console.Write(sbn + " ");
        }
        Console.WriteLine();

        List<string> sortByLength = names
            .OrderBy(name => name.Length)
            .ThenBy(name => name)
            .ToList();
        foreach(var sbl in sortByLength)
        {
            Console.Write(sbl + " ");
        }
        Console.WriteLine();

        List<string> sortDescByLength = names
            .OrderByDescending(name => name.Length)
            .ThenByDescending(name => name)
            .ToList();
        foreach(var sdbl in sortDescByLength)
        {
            Console.Write(sdbl + " ");
        }
    }

    public void LinqFirstAnyAllPractice()
    {
        List<int> numbers = new List<int> { 5, 1, 10, 3, 8 };
        foreach(int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        int firstItem = numbers.FirstOrDefault();
        Console.WriteLine(firstItem);

        int intFirstItemGreaterThan = numbers.FirstOrDefault(number => number > 6);
        Console.WriteLine(intFirstItemGreaterThan);

        bool hasEvens = numbers.Any(number => number % 2 == 0);
        if (hasEvens)
        {
            Console.WriteLine("Evens");
        }
        else { Console.WriteLine("No evens");
        }

        bool isPositive = numbers.All(number => number > 0);
        if (isPositive)
        {
            Console.WriteLine("All numbers are positive");
        }
        else
        {
            Console.WriteLine("Not all numbers are positive");
        }

        bool hasGreater = numbers.Any(number => number > 100);
        if (hasGreater)
        {
            Console.WriteLine("Greater than 100!");
        }
        else
        {
            Console.WriteLine("Numbers greater than 100 not found");
        }

        List<string> names = new List<string> { "Vlad", "Anna", "Kirill", "Bob", "Alexandra" };

        string? nameWithA = names.FirstOrDefault(name => name.StartsWith("A"));
        Console.WriteLine(nameWithA);

        string? nameLongerThanEight = names.FirstOrDefault(name => name.Length > 8);
        if (nameLongerThanEight is not null)
        {
            
            Console.WriteLine(nameLongerThanEight);
        }
        else
        {
            Console.WriteLine("Name with legth longer than 8 not found");
        }

        bool isNotEmpty = names.All(name => !string.IsNullOrWhiteSpace(name));
        if (isNotEmpty)
        {
            Console.WriteLine("names are not empty");
        }
    }

    public void LinqCountTakeSkipPractice()
    {
        List<int> numbers = new List<int> { 5, 1, 10, 3, 8, 15, 20, 25, 30 };
        foreach(int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        int countElements = numbers.Count();
        Console.WriteLine($"list numbers have {countElements} elements");

        int countEvens = numbers.Count(number => number % 2 == 0);
        Console.WriteLine($"list numbers have {countEvens} even elements");

        List<int> firstThreeElements = numbers.Take(3).ToList();
        foreach(var fte in firstThreeElements)
        {
            Console.Write(fte + " ");
        }
        Console.WriteLine();

        List<int> afterFour = numbers.Skip(4).ToList();
        foreach(var af in afterFour)
        {
            Console.Write(af + " ");
        }
        Console.WriteLine();

        //pagination
        Console.WriteLine("Enter page number: ");
        bool isCorrect = int.TryParse(Console.ReadLine(), out int pageNumber);

        if (!isCorrect || pageNumber <= 0)
        {
            Console.WriteLine("Invalid page number");
            return;
        }

        int pageSize = 3;

        List<int> numbersOnPage = numbers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        if (numbersOnPage.Count == 0)
        {
            Console.WriteLine("Page is empty");
            return;
        }

        foreach (int number in numbersOnPage)
        {
            Console.Write(number + " ");
        }
    }

    public void LinqGroupByPractice()
    {
        List<string> names = new List<string>
        {
            "Vlad",
            "Anna",
            "Bob",
            "Alex",
            "Kirill",
            "Kate",
            "John"
        };
        foreach(var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();

        var groupedByLength = names.GroupBy(name => name.Length);

        foreach(var group in groupedByLength)
        {
            Console.WriteLine($"Length: {group.Key}");
            foreach (string name in group)
            {
                Console.WriteLine(name);
            }
        }
    }

    public void LinqGroupByUsersPractice()
    {
        List<User> users = new()
        {
            new User { Name = "Vlad", Age = 23, Country = "Lithuania" },
            new User { Name = "Anna", Age = 20, Country = "Poland" },
            new User { Name = "Bob", Age = 17, Country = "Lithuania" },
            new User { Name = "Kate", Age = 30, Country = "Poland" },
            new User { Name = "John", Age = 25, Country = "Germany" },
            new User { Name = "Alex", Age = 16, Country = "Germany" }
        };

        var groupedByCountry = users.GroupBy(user => user.Country);

        foreach (var group in groupedByCountry)
        {
            Console.WriteLine($"Country: {group.Key}, amount of users: {group.Count()}");

            foreach (User user in group)
            {
                Console.WriteLine($"{user.Name}, {user.Age} y.o.");
            }
        }
    }

    public void LinqToDictionaryPractice()
    {
        List<User> users = new()
        {
            new User { Name = "Vlad", Age = 23, Country = "Lithuania" },
            new User { Name = "Anna", Age = 20, Country = "Poland" },
            new User { Name = "Bob", Age = 17, Country = "Lithuania" },
            new User { Name = "Kate", Age = 30, Country = "Poland" },
            new User { Name = "John", Age = 25, Country = "Germany" },
            new User { Name = "Alex", Age = 16, Country = "Germany" }
        };

        Dictionary<string, User> usersByName = users.ToDictionary(user => user.Name);

        string? userName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userName))
        {
            if(usersByName.TryGetValue(userName, out User? user))
            {
                Console.WriteLine($"{user.Name}, {user.Age}, {user.Country}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid username");
        }

        Dictionary<string, int> userAges = users.ToDictionary( user => user.Name, user => user.Age);
        foreach(var pair in userAges)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        var groupedByCountry = users.GroupBy(user => user.Country);

        Dictionary<string, int> userCountByCountry = groupedByCountry
            .ToDictionary(group => group.Key, group => group.Count());
        foreach (var pair in userCountByCountry)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    public void LinqFinalUsersPractice()
    {
        List<User> users = new()
        {
            new User { Name = "Vlad", Age = 23, Country = "Lithuania" },
            new User { Name = "Anna", Age = 20, Country = "Poland" },
            new User { Name = "Bob", Age = 17, Country = "Lithuania" },
            new User { Name = "Kate", Age = 30, Country = "Poland" },
            new User { Name = "John", Age = 25, Country = "Germany" },
            new User { Name = "Alex", Age = 16, Country = "Germany" },
            new User { Name = "Maria", Age = 28, Country = "Lithuania" }
        };

        var usersMature = users.Where(user => user.Age >= 18);
        foreach (var user in usersMature)
        {
            Console.Write($"{user.Name}, {user.Age} y.o. ");
        }
        Console.WriteLine();
        var usersNames = users.Select(user => user.Name);
        foreach(var user in usersNames)
        {
            Console.Write(user + " ");
        }
        Console.WriteLine();

        var adultUserNamesSorted = users
            .Where(user => user.Age >= 18)
            .OrderBy(user => user.Name)
            .Select(user => user.Name)
            .ToList();

        foreach(var user in adultUserNamesSorted)
        {
            Console.Write(user + " ");
        }
        Console.WriteLine();

        var userFromGermany = users.FirstOrDefault(user => user.Country == "Germany");
        Console.WriteLine(userFromGermany?.Name);

        var immatureUser = users.Any(user => user.Age < 18);
        if (immatureUser)
        {
            Console.WriteLine("Immatures found");
        }
        else
        {
            Console.WriteLine("All users are mature");
        }

        bool isNotEmptyNames = users.All(user => !string.IsNullOrWhiteSpace(user.Name));
        if (isNotEmptyNames)
        {
            Console.WriteLine("No empty names");
        }
        else
        {
            Console.WriteLine("Empty name found");
        }

        var groupedByCountry = users.GroupBy(user => user.Country).ToList();
        foreach(var group in groupedByCountry)
        {
            if(group.Key == "Lithuania")
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }
        
        Console.WriteLine("Enter page number: ");
        bool isCorrect = int.TryParse(Console.ReadLine(), out int pageNumber);

        if (!isCorrect || pageNumber <= 0)
        {
            Console.WriteLine("Invalid page number");
            return;
        }
        
        int pageSize = 3;

        List<User> usersOnpage = users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        if (usersOnpage.Count == 0)
        {
            Console.WriteLine("Page is empty");
            return;
        }

        foreach (var user in usersOnpage)
        {
            Console.Write(user.Name + " ");
        }
        Console.WriteLine();

        foreach(var group in groupedByCountry)
        {
            Console.WriteLine($"{group.Key}, {group.Count()}");
        }

        Dictionary<string, User> usersByName = users.ToDictionary(user => user.Name);
        if (usersByName.TryGetValue("Maria", out User? userMasha))
        {
            Console.WriteLine($"{userMasha.Name}, {userMasha.Age}, {userMasha.Country}");
        }
        else
        {
            Console.WriteLine("User named Maria not found");
        }
    }

    public void OopPractice()
    {
        BankAccount account = new BankAccount("Vlad", 1500);
        Console.WriteLine(account.PrintInfo());
        account.Deposit(500);
        Console.WriteLine(account.PrintInfo());
        account.Withdraw(300);
        Console.WriteLine(account.PrintInfo());
    }

    public void OopPracticeAccessModifiers()
    {
        UserProfile profile = new UserProfile("Vlad", "pesotskiyvlad9@gmail.com", "meowmeow123");

        Console.WriteLine($"Username: {profile.Username}, Email: {profile.Email}");

        if (profile.CheckPassword("meowmeow123"))
        {
            Console.WriteLine($"Password is correct");
        }
        else
        {
            Console.WriteLine("Something is wrong!");
        }
        
        profile.ChangeEmail("pesotskiyvlad888@gmail.com");
        Console.WriteLine($"UPDATED: profile {profile.Username}, Email: {profile.Email}");
    }

    public void OopInheritancePractice()
    {
        //Manager manager = new Manager("Vlad", 1000, 500);
        //Console.WriteLine(manager.PrintInfo());
    }

    public void OopPolymorphismPractice()
    {
        List<Employee> employees = new()
        {
            //new Manager("Vlad", 1000, 500),
            new Developer("Anna", 2000, 300)
        };

        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee.PrintInfo());
        }
    }

    /*public void OopInterfacePractice()
    {
        Manager manager = new Manager("Vlad", 1000, 500);
        Developer developer = new Developer("Anna", 2000, 300);
        
        IReportable reportable = manager;
        ICodeReviewer codeReviewer = developer;
        
        Console.WriteLine(reportable.GenerateReport());
        Console.WriteLine(codeReviewer.ReviewCode());
    }*/

    public void OopCompositionPractice()
    {
        ReportGenerator reportGenerator = new();
        Manager manager = new Manager("Vlad", 1000, 500, reportGenerator);
        
        Console.WriteLine(manager.GenerateReportUsingReportGenerator());
    }
}


public class User
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}
