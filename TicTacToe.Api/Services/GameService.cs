public class GameService
{
    private Game game;

    public GameService()
    {
        Player player1 = new Player("Rahul", 'X');
        Player player2 = new Player("Amit", 'O');

        game = new Game(player1, player2);
    }

    public Game GetGame()
    {
        return game;
    }
}