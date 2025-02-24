

class Program
{
    static void Main(string[] args)  
    {
        Player player1;
        Player player2;

        var valid = new Validation();
        var show = new ShowMessages();


        Console.WriteLine("\n-Simple Tic Tac Toe game (noughts and crosses)-\n");

        string name = valid.NameValidation("\nPlayer 1, enter your name: ");
        char symbol1 = valid.SymbolValidation($"Player '{name}', choose your symbol ('X' or 'O'): ");

        player1 = new Player(name, symbol1);

        name = valid.NameValidation("\nPlayer 2, enter your name: ");
        char symbol2 = symbol1 == 'X' ? 'O' : 'X';

        Console.Write($"Player '{name}', your symbol is '{symbol2}'\n\n");
        player2 = new Player(name, symbol2);

        Thread.Sleep(1500);

        int firstMenu;
        bool isFirstMove = true;

        do
        {
            show.ShowMenu();
            firstMenu = valid.InputValidation();

            switch (firstMenu)
            {
                case 1:
                    var game = isFirstMove ? new Game(player1, player2) : new Game(player2, player1);
                    game.StartGame();
                    isFirstMove = !isFirstMove;
                    break;
                case 2:
                    Console.WriteLine("\n\nPlayers stats:");
                    player1.ShowPlayerStats();
                    player2.ShowPlayerStats();
                    break;
                case 3:
                    (player1._figure, player2._figure) = (player2._figure, player1._figure);
                    Console.WriteLine($"\n\nPlayer '{player1._name}' new symbol - '{player1._figure}'");
                    Console.WriteLine($"Player '{player2._name}' new symbol - '{player2._figure}'\n");
                    break;
                case 4:
                    Console.WriteLine("\nThanks for playing!");
                    break;
            }
        } while (firstMenu != 4);
    }
}