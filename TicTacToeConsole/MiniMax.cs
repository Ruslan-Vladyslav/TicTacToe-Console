



public class MiniMax
{
    private int _movesCount;
    private Game _game;
    private Player _player;


    public MiniMax(int moves, Game game, Player player)
    {
        _movesCount = moves;
        _game = game;
        _player = player;
    }

    public int FindOptimalMove(string[] board)
    {
        int bestValue = int.MinValue;
        int index = -1;

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != "X" && board[i] != "O")
            {

            }
        }

        return index;
    }
}

