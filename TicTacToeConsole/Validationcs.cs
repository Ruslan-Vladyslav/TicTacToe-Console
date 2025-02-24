using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


public class Validation
{
    public Validation() { }

    public string NameValidation(string message)
    {
        Console.Write(message);
        string? name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            ValidColorOutput("\nError: name cannot be empty.");
            Console.Write(message);
            name = Console.ReadLine();
        }
        return name;
    }

    public char SymbolValidation(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input) || input.Length != 1 || (char.ToUpper(input[0]) != 'X' && char.ToUpper(input[0]) != 'O'))
        {
            ValidColorOutput("\nError: should choose one symbol (X or O).\n");
            Console.Write(message);
            input = Console.ReadLine();
        }

        return char.ToUpper(input[0]);
    }

    public int MoveValidation(string[] board, int[] indexes, Player player, Game g)
    {
        string? choice = Console.ReadLine();

        while (!board.Contains(choice))
        {
            g.PrintBoard(indexes);

            ValidColorOutput($"\nPlayer '{player._name}' Please select an available number from the board.");
            Console.Write("Select column (enter available number): ");

            choice = Console.ReadLine();
        }

        return Convert.ToInt32(choice) - 1;
    }

    private void ValidColorOutput(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public int InputValidation()
    {
        int menu;
        string? input = Console.ReadLine();

        while (!int.TryParse(input, out menu) || (menu != 1 && menu != 2))
        {
            Console.WriteLine("\nInvalid input! Please enter 1 or 2.");
            Console.Write(">> ");
            input = Console.ReadLine();
        }

        return menu;
    }
}
