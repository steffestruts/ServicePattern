namespace MainApp.Services;

public class MenuDialogs
{
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
        Console.WriteLine($"{"1.", -5} Create");
        Console.WriteLine($"{"2.", -5} View");
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
        Console.Clear();
        Console.WriteLine("Create");
        Console.ReadKey();
    }

    private void ViewOption()
    {
        Console.Clear();
        Console.WriteLine("View");
        Console.ReadKey();
    }

    private void InvalidOption() 
    {
        Console.Clear();
        Console.WriteLine("You must enter a valid option.");
        Console.ReadKey();
    }
}
