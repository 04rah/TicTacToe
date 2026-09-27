let currentPlayer1Name = "";
let currentPlayer2Name = "";
async function startGame() {
    currentPlayer1Name = document.getElementById("player1").value.trim();
    currentPlayer2Name = document.getElementById("player2").value.trim();

    if (!currentPlayer1Name || !currentPlayer2Name) {
        alert("Please enter both player names.");
        return;
    }
    localStorage.setItem("player1Name", currentPlayer1Name);
    localStorage.setItem("player2Name", currentPlayer2Name);

    await resetGame(currentPlayer1Name, currentPlayer2Name);

    document.getElementById("player-setup").style.display = "none";
    document.getElementById("game").style.display = "block";
}


async function resetGame() {
    const response = await fetch("/api/game/reset", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            player1Name: currentPlayer1Name,
            player2Name: currentPlayer2Name
        })
    });

    const result = await response.json();

    const buttons = document.querySelectorAll("#board button");

    result.board.forEach((cell, index) => {
        buttons[index].textContent = cell;
        buttons[index].disabled = false;
    });

    document.getElementById("status").textContent =
        `${result.nextPlayer}'s turn (${result.symbol})`;
}


async function makeMove(position) {
    const response = await fetch(`/api/game/move?position=${position}`, {
        method: "POST"
    });

    const result = await response.json();

    if (!response.ok) {
        console.log(result);
        return;
    }

    const buttons = document.querySelectorAll("#board button");

    result.board.forEach((cell, index) => {
        buttons[index].textContent = cell;
        buttons[index].disabled = cell !== " ";
    });

    if (result.status === "Winner") {
        document.getElementById("status").textContent =
            `${result.winner} wins!`;

        buttons.forEach(button => {
            button.disabled = true;
        });
    }
    else if (result.status === "Draw") {
        document.getElementById("status").textContent =
            "Game is a draw!";

        buttons.forEach(button => {
            button.disabled = true;
        });
    }
    else {
        document.getElementById("status").textContent =
            `${result.nextPlayer}'s turn (${result.symbol})`;
    }
}
window.addEventListener("load", async function () {
    const savedPlayer1 = localStorage.getItem("player1Name");
    const savedPlayer2 = localStorage.getItem("player2Name");

    if (savedPlayer1 && savedPlayer2) {
        currentPlayer1Name = savedPlayer1;
        currentPlayer2Name = savedPlayer2;

        document.getElementById("player1").value = savedPlayer1;
        document.getElementById("player2").value = savedPlayer2;

        await resetGame();

        document.getElementById("player-setup").style.display = "none";
        document.getElementById("game").style.display = "block";
    }
});