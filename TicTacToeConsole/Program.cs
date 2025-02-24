

class Program
{
    static void Main(string[] args)  
    {
        Player player1;
        Player player2;

        var valid = new Validation();


        Console.WriteLine("\nSimple Tic Tac Toe game (noughts and crosses)\n");

        string name = valid.NameValidation("\nPlayer 1, enter your name: ");
        char symbol1 = valid.SymbolValidation($"Player '{name}', choose your symbol ('X' or 'O'): ");

        player1 = new Player(name, symbol1);

        name = valid.NameValidation("\nPlayer 2, enter your name: ");
        char symbol2 = symbol1 == 'X' ? 'O' : 'X';

        Console.Write($"Player '{name}', your symbol is '{symbol2}'\n\n");
        player2 = new Player(name, symbol2);


        int firstMenu;

        do
        {
            ShowMenu();
            firstMenu = valid.InputValidation();

            switch (firstMenu)
            {
                case 1:
                    var game = new Game(player1, player2);
                    game.StartGame();
                    break;
                case 2:
                    Console.WriteLine("\nPlayers stats:");
                    player1.ShowPlayerStats();
                    player2.ShowPlayerStats();
                    break;
                case 3:
                    Console.WriteLine("\nThanks for playing!");
                    break;
            }
        } while (firstMenu != 3);
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1 New round");
        Console.WriteLine("2 Show players stats");
        Console.WriteLine("3 Exit");
        Console.Write(">> ");
    }
}