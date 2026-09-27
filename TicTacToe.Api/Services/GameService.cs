public class GameService
{
    private Game game;

    public GameService()
    {
        game = new Game(
            new Player("Player 1", 'X'),
            new Player("Player 2", 'O')
        );
    }

    public Game GetGame()
    {
        return game;
    }

    public void ResetGame(string player1Name, string player2Name)
    {
        Player player1 = new Player(player1Name, 'X');
        Player player2 = new Player(player2Name, 'O');

        game = new Game(player1, player2);
    }
}