public class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;
    private bool gameOver;

    public Game(Player player1, Player player2)
    {
        this.board = new Board();
        this.player1 = player1;
        this.player2 = player2;
        this.currentPlayer = player1;
    }

    public bool MakeMove(int position)
    {
        if (gameOver)
        {
            return false;
        }

        return board.MakeMove(position, currentPlayer.Symbol);
    }
    public bool HasWinner()
    {
        if (board.IsWinner(currentPlayer.Symbol))
        {
            gameOver = true;
            return true;
        }

        return false;
    }
    public bool IsDraw()
    {
        if (board.IsFull())
        {
            gameOver = true;
            return true;
        }

        return false;
    }

    public void SwitchTurn()
    {
        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else
        {
            currentPlayer = player1;
        }
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void DisplayBoard()
    {
        board.Display();
    }
    public char[] GetBoard()
    {
        return board.GetCells();
    }
    public bool IsGameOver()
    {
        return gameOver;
    }
}