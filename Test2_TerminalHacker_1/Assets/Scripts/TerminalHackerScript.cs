using System;
using UnityEngine;

public class TerminalHackerScript : MonoBehaviour
{
    //<<Game configuaraiton data>>
    const string menuHint = "you may hit menu any time";
    string[] libraryPasswords = new string[5] { "library", "books", "chair", "table", "id" };
    string[] policePasswords = new string[] { "officer", "thief", "criminal", "prison" };
    string[] nasaPasswords = { "lighyear", "blackhole", "telescope", "spaceship", "astronaut" };
    string[] agent007Passwords = new string[5] { "jamesbond", "russianmafia", "stevenpinker", "mi6", "agentvinod" };

    //<<Game states>>
    int level;                                      //member variable to hold states; it should be natural property of the thing
    enum Screen { MainMenu, PassWord, Win };
    Screen CurrentScreen;                           //Variable of this enum type
    string password;

    //<<used for initialization>>
    void Start()                                    //use this for initialization
    {
        //print("Hello Console");                   //this prints hello on console of the unity
        //var greeting = "Hello max";               //variable name; var for compiletime compiler puts string instead of var; for flexiblility and code reusability.
        //ShowMainMenu(greeting);                   //This is called calling;  ***blackbox, encapsulation, let go of how if the funtion is named properly  ...gamedev.tv says this process is called Refactoring
        //ShowMainMenu("Hello Max");                //Directly also could be used
        //ShowMainMenu();                           //without any parameter can be provided the method signature also dont have parameters
        //print("1");                               //prints 1 on the artifitial terminal
        Terminal.WriteLine("enter : menu to show the menu");
        
    }



                                                    //debug.log("something something"); this is done in console



    //<<this should do is how to handle input by calling methods rather than actuly doing it>>

    void OnUserInput(string input)                  //Onuser Input probably is a mesaage rather than a method because we can not see its implementation but it works, its just like Start() funtion it just works ; sort of magic black box of the artifitial Termial
    {
        //print(input == "1");                      //shows output in terminal of unity as true if user enters  1


        if (input == "menu")
        {
            ShowMainMenu();
        }

        else if (input == "quit" || input == "close"|| input == "exit")
        {
            Terminal.WriteLine("if on the web close the tab");
            Application.Quit();
        }
        //<<TODO handle differently depending on the screeen>>

        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

        else if (CurrentScreen == Screen.PassWord)
        {
            RunPassWordCheck(input);
        }

        else if (CurrentScreen == Screen.Win)
        {
           
        }


    }

    void RunDisplayWin()
    {
        Terminal.ClearScreen();
        
        ShowLevelReward(level);
    }

    void ShowLevelReward(int level)
    {
        switch (level)
        {
            case 1:
                {
                    Terminal.WriteLine("You got a book ");
                    Terminal.WriteLine(@"

    ______ 
   /     // 
  /     //
 /_____//
(_____(/
                ");
                    break;
                }
            case 2:
                {
                    Terminal.WriteLine("You got a prison key");
                    Terminal.WriteLine(@"


  __
 /  \_________
| () ____ -  _|
 \__/    ' ''
                ");
                    break;
                }
            case 3:
                {
                    Terminal.WriteLine("welcome to inter security of nasa!");
                    Terminal.WriteLine(@"


nasa
                ");
                    break;
                }
            case 007:
                {
                    Terminal.WriteLine("Its risky, russian mafia are very dangerous beware agent 007");
                    Terminal.WriteLine(@"

007
                ");
                    break;
                }
        }
        CurrentScreen = Screen.MainMenu;
    }
    

    void RunPassWordCheck(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well Done");
            
            RunDisplayWin();
        }
        else
        {
            Terminal.WriteLine("password incorrect");
            Terminal.WriteLine("please retry Hint: " + password.Anagram());
            Terminal.WriteLine(menuHint);
        }
    }

    void RunMainMenu(string input)                  //RunMainMenu is what refactored so that not every code is in one big method.
    {
    
        level = Convert.ToInt32(input);
        if (input == "1")                           //Right now the program is in the state of level 1 (library) and currentScreen Main menu 
        {
            print("You have entered level 1: hack into Library");
            StartGame();

        }

        else if (input == "2")
        {
            print("You have entered level 2: hack into Police Station ");
            StartGame();
        }

        else if (input == "3")
        {
            print("You have entered level 3: hack into Nasa");
            StartGame();
        }
        else if (input == "007")                    //easter egg concept in game dev
        {
            print("you have found secret level easter egg : hack into Russian Intelligence");
            StartGame();
        }
        else                                        //catch all block
        {
            print("wrong input, try again");
        }
    }


    void StartGame()
    {
        //password = "passwd";                      //hard coded
        SetPassWord();
        Terminal.ClearScreen();
        Terminal.WriteLine("please enter the password for the level: " + level);
        CurrentScreen = Screen.PassWord;
    }

    private void SetPassWord()
    {
        switch (level)
        {
            case 1:
                {
                    password = libraryPasswords[UnityEngine.Random.Range(0, libraryPasswords.Length)]; //TODO random create and set the password to this random
                    break;
                }
            case 2:
                {
                    password = policePasswords[UnityEngine.Random.Range(0, policePasswords.Length)]; //TODO random create and set the password to this random
                    break;
                }
            case 3:
                {
                    password = nasaPasswords[UnityEngine.Random.Range(0, nasaPasswords.Length)]; //TODO random create and set the password to this random
                    break;
                }
            case 007:
                {
                    password = agent007Passwords[UnityEngine.Random.Range(0, agent007Passwords.Length)]; //TODO random create and set the password to this random
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    //public void ShowMainMenu(string greet);       //Show Main Menu must be a method  rather than a message a/c to gamedev.tv
    public void ShowMainMenu()
    {
        //Terminal.WriteLine(greet);
        Terminal.ClearScreen();
        Terminal.WriteLine("Hacker_io.lock-Key#19823735764__");
        Terminal.WriteLine("To Hack Into Library Press 1");
        Terminal.WriteLine("To Hack Into Police Press 2");
        Terminal.WriteLine("To Hack Into Nasa Press 3");
        Terminal.WriteLine("You Entered ");
        CurrentScreen = Screen.MainMenu;
    }
}
