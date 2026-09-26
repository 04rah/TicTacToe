Player player1 = new Player("Rahul", 'X');
Player player2 = new Player("Amit", 'O');

Game game = new Game(player1, player2);

while (true)
{
    game.DisplayBoard();

    Player currentPlayer = game.GetCurrentPlayer();

    Console.WriteLine($"{currentPlayer.Name}'s turn ({currentPlayer.Symbol})");
    Console.Write("Enter position (0-8): ");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int position))
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    if (!game.MakeMove(position))
    {
        Console.WriteLine("Invalid move. Try again.");
        continue;
    }

    if (game.HasWinner())
    {
        game.DisplayBoard();
        Console.WriteLine($"{currentPlayer.Name} wins!");
        break;
    }

    if (game.IsDraw())
    {
        game.DisplayBoard();
        Console.WriteLine("The game is a draw!");
        break;
    }

    game.SwitchTurn();
}