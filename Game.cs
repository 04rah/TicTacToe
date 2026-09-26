public class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;

    public Game(Player player1, Player player2)
    {
        this.board = new Board();
        this.player1 = player1;
        this.player2 = player2;
        this.currentPlayer = player1;
    }

    public bool MakeMove(int position)
    {
        return board.MakeMove(position, currentPlayer.Symbol);
    }

    public bool HasWinner()
    {
        return board.IsWinner(currentPlayer.Symbol);
    }

    public bool IsDraw()
    {
        return board.IsFull();
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
}