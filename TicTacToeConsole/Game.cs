using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{
    private Player _player1;
    private Player _player2;
    private ShowMessages _message;
    private string[] _board;
    private bool _player1Turn;
    private int _numTurns;

    private int[][] _VictoryPatterns =
    {
    new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
    new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
    new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
    };

    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _message = new ShowMessages();
        _board = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        _player1Turn = true;
        _numTurns = 0;
    }

    public void StartGame()
    {
        Thread.Sleep(800);

        int[] winIndexes = Array.Empty<int>();

        while (!IsVictory(out winIndexes, _board) && _numTurns < 9)
        {
            PrintBoard(winIndexes);

            Player player = _player1Turn ? _player1 : _player2;

            Console.WriteLine($"\nPlayer's '{player._name}' Turn (symbol: {player._figure})!");

            int index;

            if (player._IsAI)
            {
                MiniMax minimax = new MiniMax(_numTurns, this, player);
                index = minimax.FindOptimalMove(_board);

                Thread.Sleep(900);
                Console.WriteLine($"AI choose column [{index}]");
            }
            else
            {
                Console.Write("Select column (enter existing number): ");
                var valid = new Validation();
                index = valid.MoveValidation(_board, winIndexes, player, this);
            }

            _board[index] = player._figure.ToString();
            _numTurns++;

            _player1Turn = !_player1Turn;
        }

        PrintBoard(winIndexes);
        GameResult(winIndexes);
    }

    private void GameResult(int[] winIndexes)
    {
        if (winIndexes.Length > 0)
        {
            Player winner = _player1Turn ? _player2 : _player1;
            Player loser = _player1Turn ? _player1 : _player2;

            _message.ShowColorMessage($"\n\nCongrats! Player '{winner._name}' wins!\n\n", ConsoleColor.Green);

            winner.IncrementWinsCount();
            loser.IncrementLosesCount();

            Counter.matchesCount++;
        }
        else
        {
            Console.WriteLine("\nIt's a tie!");
            Counter.tiesCount++;
            Counter.matchesCount++;
        }
    }

    public bool IsVictory(out int[] winIndex, string[] board)
    {
        foreach (var i in _VictoryPatterns)
        {
            if (board[i[0]] == board[i[1]] && board[i[1]] == board[i[2]])
            {
                winIndex = i;
                return true;
            }
        }

        winIndex = Array.Empty<int>();
        return false;
    }

    public void PrintBoard(int[] indexes)
    {
        Console.WriteLine("\n\n-------------");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;

                _message.ShowColorMessage(_board[index], GetColor(indexes, index));
                Console.Write(" | ");
            }
            Console.WriteLine("");
            Console.WriteLine("-------------");
        }
    }

    private ConsoleColor GetColor(int[] indexes, int index)
    {
        if (indexes != null && indexes.Contains(index))
            return ConsoleColor.Green;

        return _board[index] switch
        {
            "X" => ConsoleColor.Red,
            "O" => ConsoleColor.Blue,
            _ => ConsoleColor.White
        };
    }
}

