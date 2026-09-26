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
    public void Start()
    {
        while (true)
        {
            board.Display();

            PlayTurn();

            if (board.IsWinner(currentPlayer.Symbol))
            {
                board.Display();
                Console.WriteLine($"{currentPlayer.Name} wins!");
                break;
            }

            if (board.IsFull())
            {
                board.Display();
                Console.WriteLine("The game is a draw!");
                break;
            }

            SwitchTurn();
        }
    }
    private void SwitchTurn()
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
    private void PlayTurn()
    {
        bool moveSuccessful = false;

        while (!moveSuccessful)
        {
            Console.WriteLine($"{currentPlayer.Name}'s turn ({currentPlayer.Symbol})");
            Console.Write("Enter position (0-8): ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int position))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            moveSuccessful = board.MakeMove(position, currentPlayer.Symbol);

            if (!moveSuccessful)
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

}