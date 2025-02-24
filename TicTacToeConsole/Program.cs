

class Program
{
    static void Main(string[] args)  
    {
        Console.WriteLine("\nSimple Tic Tac Toe game\n");

        Player player1;
        Player player2;

        var valid = new Validation();

        string name = valid.NameValidation("\nPlayer 1, enter your name: ");
        char symbol1 = valid.SymbolValidation($"Player '{name}', choose your symbol ('X' or 'O'): ");

        player1 = new Player(name, symbol1);


        name = valid.NameValidation("\nPlayer 2, enter your name: ");
        char symbol2 = symbol1 == 'X' ? 'O' : 'X';

        Console.Write($"Player '{name}', your symbol is '{symbol2}'\n\n");
        player2 = new Player(name, symbol2);

        var game = new Game(player1, player2);
        game.StartGame();
    }


    /*
    //ShowOpponentMenu();
    //int firstMenu = valid.InputValidation();
    //if (firstMenu == 1) { }
    static void ShowMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("1");
        Console.WriteLine("2");
        Console.WriteLine("3");
        Console.Write(">> ");
    }*/
}