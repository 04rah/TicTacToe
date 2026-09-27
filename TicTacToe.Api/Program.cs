var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSingleton<GameService>();

var app = builder.Build();

app.MapGet("/api/game", (GameService gameService) =>
{
    return gameService.GetGame().GetBoard();
});

app.MapPost("/api/game/move", (int position, GameService gameService) =>
{
    Game game = gameService.GetGame();

    if (game.IsGameOver())
    {
        return Results.Conflict("Game is already over.");
    }

    bool success = game.MakeMove(position);

    if (!success)
    {
        return Results.BadRequest("Invalid move.");
    }

    Player player = game.GetCurrentPlayer();

    if (game.HasWinner())
    {
        return Results.Ok(new
        {
            board = game.GetBoard(),
            status = "Winner",
            winner = player.Name
        });
    }

    if (game.IsDraw())
    {
        return Results.Ok(new
        {
            board = game.GetBoard(),
            status = "Draw"
        });
    }

    game.SwitchTurn();

    Player nextPlayer = game.GetCurrentPlayer();

    return Results.Ok(new
    {
        board = game.GetBoard(),
        status = "Playing",
        nextPlayer = nextPlayer.Name,
        symbol = nextPlayer.Symbol
    });
});// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/game/reset", (
    StartGameRequest request,
    GameService gameService) =>
{
    gameService.ResetGame(
        request.Player1Name,
        request.Player2Name);

    Game game = gameService.GetGame();
    Player player = game.GetCurrentPlayer();

    return Results.Ok(new
    {
        board = game.GetBoard(),
        status = "Playing",
        nextPlayer = player.Name,
        symbol = player.Symbol
    });
});

app.Run();