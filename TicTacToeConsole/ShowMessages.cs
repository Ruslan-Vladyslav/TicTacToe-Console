using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class ShowMessages
{

    public ShowMessages() { }


    public void ShowMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1 New round");
        Console.WriteLine("2 Show players stats");
        Console.WriteLine("3 Change symbols");
        Console.WriteLine("4 Exit");
        Console.Write(">> ");
    }

    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ResetColor();
    }

    public void ShowColorMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
}

