using static System.Console;
using System;
using System.Drawing;
using Console = Colorful.Console;
using Dapper;
using MySqlConnector;
class Menu

{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;

    public Menu(string prompt, string[] options)
    {
        Prompt = prompt;
        Options = options;
        SelectedIndex = 0;
    }

    private void DisplayOptions()
    {
         Menu.WriteLogo();
        Console.WriteLine(Prompt, Color.DarkViolet);
        for (int i = 0; i < Options.Length; i++)
        {
            string CurrentOption = Options[i];
            string prefix;
            if (i == SelectedIndex)
            {
                prefix = "*";
                Console.ForegroundColor = Color.Black;
                Console.BackgroundColor = Color.DarkViolet;

            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = Color.DarkViolet;
                Console.BackgroundColor = Color.Black;
            }
            Console.WriteLine($"{prefix}<< {CurrentOption} >>");

        }
        Console.ResetColor();

    }

    public int Run()
    {

        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }
            }

        }
        while (keyPressed != ConsoleKey.Enter);
        return SelectedIndex;


    }

    public static void WriteLogo()
    {

        string logo = @" __     ___      
\ \   / (_) __| | ___  ___ | |_ ___| | __
\ \ / /| |/ _` |/ _ \/ _ \| __/ _ \ |/ /
 \ V / | | (_| |  __/ (_) | ||  __/   < 
  \_/  |_|\__,_|\___|\___/ \__\___|_|\_\

";

     Console.WriteLine(logo, Color.DarkViolet);
    }

}
