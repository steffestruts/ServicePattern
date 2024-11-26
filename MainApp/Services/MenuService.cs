using MainApp.Factories;
using MainApp.Models;
using System.Transactions;

namespace MainApp.Services;

public class MenuService
{
    private readonly UserService _userService = new UserService();

    public void Show()
    {
        while (true) 
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine($"{"1.", -5} Create User");
        Console.WriteLine($"{"2.", -5} View Users");
        Console.WriteLine($"{"Q.",-5} Quit Application");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Choose your menu option: ");
        var option = Console.ReadLine()!;

        switch (option.ToLower())
        {
            case "q":
                QuitOption();
                break;
            case "1":
                CreateOption();
                break;
            case "2":
                ViewOption();
                break;
            default:
                InvalidOption();
                break;
        }
    }

    private void QuitOption()
    {
        Console.Clear();
        Console.WriteLine("Do you want to exit this application (y/n)");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }

    private void CreateOption() 
    {
        UserRegistrationForm userRegistrationForm = UserFactory.Create();

        Console.Clear();

        Console.WriteLine("Enter your first name: ");
        userRegistrationForm.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter your last name: ");
        userRegistrationForm.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter your email: ");
        userRegistrationForm.Email = Console.ReadLine()!;

        Console.WriteLine("Enter your password: ");
        userRegistrationForm.Password = Console.ReadLine()!;

        bool result = _userService.Create(userRegistrationForm);

        if (result) 
        {
            OutputDialog("User was successfully created");
        }
        else
        {
            OutputDialog("User was not created successfully");
        }

        Console.ReadKey();
    }

    private void ViewOption()
    {
        Console.Clear();

        var users = _userService.GetAll();
        foreach (var user in users) 
        {
            Console.WriteLine($"{"Id:",-15}{user.Id}");
            Console.WriteLine($"{"Name:",-15}{user.FirstName} {user.LastName}");
            Console.WriteLine($"{"Email:",-15}{user.Email}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }

    private void InvalidOption() 
    {
        Console.WriteLine("You must enter a valid option.");
        Console.Clear();
        Console.ReadKey();
    }

    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
