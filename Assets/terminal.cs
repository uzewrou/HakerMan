using UnityEngine;

public class terminal : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string password = "test";
    string[] level1Password = { "MissleLaunchers", "Heat Missiles", "Shield", "MachineGuns" };
    string[] level2Password = { "ArmoredTank", "Bullets", "Uniform", "Glock" };
    string[] level3Password = { "ToothBrush", "Towel", "Soap", "ShowerCurtain" };

    // Start is called before the first frame update
    //ISI: MissleLaunchers, 
    //CSI:ArmoredTank 
    //Bathroom:ToothBrush,                              
    void Start()
    {
        ShowMainMenu();
      
    }



    private void StartGame() {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level" + level);
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0,level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[Random.Range(0, level3Password.Length)];
                break;
            default:
                Terminal.WriteLine("You Blind! There is no such level");
                break;

        }
        Terminal.WriteLine("Enter the Password to hack into the system: " + password.Anagram());
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Press (1) to hack ISI");
        Terminal.WriteLine("Press (2) to hack CSI");
        Terminal.WriteLine("Press (3) to hack Bathroom");
        Terminal.WriteLine("Enter your selection");
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch(level) {
            case 1:
                Terminal.WriteLine(@"
 _____  _____ _____ 
|_   _|/ ____|_   _|
  | | | (___   | |  
  | |  \___ \  | |  
 _| |_ ____) |_| |_ 
|_____|_____/|_____|
  ");
                break;
            case 2:
                Terminal.WriteLine(@"
  _____  _____ _____ 
 / ____|/ ____|_   _|
| |    | (___   | |  
| |     \___ \  | |  
| |____ ____) |_| |_ 
 \_____|_____/|_____|
");
                break;
            case 3:
                Terminal.WriteLine(@"
   ____        _   _     _____                       
|  _ \      | | | |   |  __ \                      
| |_) | __ _| |_| |__ | |__) |___   ___  _ __ ___  
|  _ < / _` | __| '_ \|  _  // _ \ / _ \| '_ ` _ \ 
| |_) | (_| | |_| | | | | \ \ (_) | (_) | | | | | |
|____/ \__,_|\__|_| |_|_|  \_\___/ \___/|_| |_| |_|
");
                break;
            default:
                Terminal.WriteLine("Try Again or type 'menu' to go back");
                break;
        }
    }
    void OnUserInput(string input)
    {
        Terminal.ClearScreen();
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            SelectLevel(input); //call Option() 
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password) 
        {
            DisplayWinScreen();
            Terminal.WriteLine("YOU WIN!");
        } 
    
        else 
        {
            Terminal.WriteLine("Try Again or Type Menu");
        }
    } 

    void SelectLevel(string input)
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
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {

        }
    }



}
   
 
   

    

