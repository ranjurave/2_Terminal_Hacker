using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen CurrentScreen;
     
    // Use this for initialization
    void Start () {
        ShowMainMenu();
        
     }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal Hacker Game");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 1 for NASA");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string  input)
    {
        if (input == "Menu")
        {
            ShowMainMenu();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
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

    void StartGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.WriteLine("level " + level + " selected...");
        Terminal.WriteLine("Enter the password");
    }
}
