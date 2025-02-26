



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
        int bestScore = int.MinValue;
        int index = -1;

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != "X" && board[i] != "O")
            {
                string[] copy = (string[])board.Clone();
                copy[i] = _player._figure.ToString();

                int score = Minimax(copy, 0, false);

                if (score > bestScore)
                {
                    bestScore = score;
                    index = i;
                }
            }
        }

        return index;
    }

    public int Minimax(string[] board, int depth, bool IsMaximazing)
    {
        int[] winIndexes;

        if (_game.IsVictory(out winIndexes, board))
        {
            return IsMaximazing ? -(10 - depth) : (10 - depth);
        }
        else if (board.All(cell => cell == "X" || cell == "O")) return 0;

        if (IsMaximazing)
        {
            int bestScore = int.MinValue;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != "X" && board[i] != "O")
                {
                    string[] copy = (string[])board.Clone();
                    copy[i] = _player._figure.ToString();

                    int score = Minimax(copy, depth + 1, false);

                    bestScore = Math.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            char opponent = _player._figure == 'X' ? 'O' : 'X';

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != "X" && board[i] != "O")
                {
                    string[] copy = (string[])board.Clone();
                    copy[i] = opponent.ToString();

                    int score = Minimax(copy, depth + 1, true);

                    bestScore = Math.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }
}

