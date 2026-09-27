# Tic-Tac-Toe

A Tic-Tac-Toe game built with **C# and .NET**, first developed as a console application and then extended into an **ASP.NET Core Web API with a browser-based UI**.

The project is mainly focused on learning how a frontend communicates with a backend API and how game logic can be separated into reusable classes and services.

---

## Tech Stack

- C#
- .NET 10
- ASP.NET Core Web API
- HTML
- CSS
- JavaScript
- REST APIs
- Git / GitHub

---

## Project Structure

```text
TicTacToe
│
├── TicTacToe.slnx
├── TicTacToe.csproj
│
├── Program.cs
├── Board.cs
├── Game.cs
├── Player.cs
│
├── README.md
│
└── TicTacToe.Api
    │
    ├── TicTacToe.Api.csproj
    ├── Program.cs
    │
    ├── Models
    │   └── StartGameRequest.cs
    │
    ├── Services
    │   └── GameService.cs
    │
    └── wwwroot
        ├── index.html
        ├── style.css
        └── script.js