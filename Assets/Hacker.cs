using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game Configuration
    const string menuHint = "Type menu at anytime.";
    string[] level1Passwords = { "books", "aisle", "font", "shelf", "stock", "reading" };
    string[] level2Passwords = { "prison", "handcuffs", "gun", "files", "officer" };
    string[] level3Passwords = { "rocket", "space", "sattelite", "moon", "alien", "solar", "gravity", "astronauts"};
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen CurrentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal Hacker Game");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "close" || input == "exit")
        {
            Application.Quit();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isVallidInput = (input == "1" || input == "2" || input == "3");
        if (isVallidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Enter valid input");
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        CurrentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("I dont know what it is...");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayeWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect Try again...");
        }
    }

    void DisplayeWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        DisplayLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void DisplayLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book....");
                Terminal.WriteLine(@"
    ...--~~~~-._   _.-~~~~--..
  //            `V'           \\ 
 //.....~~~~~._\ | /_.~~~~.....\\
===============\\|//==============
               `---`
");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key...");
                Terminal.WriteLine(@"
    o
  o   ooooooooooooo
    o          o  o
");
                break;
            case 3:
                Terminal.WriteLine("You unlocked the space...");
                Terminal.WriteLine(@"
           ___
     |     | |
    / \ ===| |
  /     \  | |
 |       | | |
 |       |=| |
 |_______| |_|
  |@| |@|  | |
___________|_|_
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
