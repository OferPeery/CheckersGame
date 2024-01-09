# Checkers Game

**♟️ Windows Desktop Board Game** 

<img width="300" alt="Checkers Board" src="https://github.com/OferPeery/CheckersGame/assets/90853508/ae918ce5-0498-4d38-ae97-ef0e86baaafc">
<img width="250" alt="Settings Window" src="https://github.com/OferPeery/CheckersGame/assets/90853508/6dfc478b-7f7c-487e-98b8-fda9781de162">  


https://github.com/OferPeery/CheckersGame/assets/90853508/065bbac5-9a9f-497b-9c1e-4ec5a30e500c

## Prerequisites
- Microsoft Windows 10 or above
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) to build and run the application locally (installed by default on Windows 10 and above)
- [Visual Studio](https://visualstudio.microsoft.com/vs/) IDE, versions: Community 2022, or above

## Install & Run

- Open via Visual Studio the Solution file: `CheckersGame.sln`.
- On the top toolbar, click: `build` > `build solution`
- Click F5

## How to Play
- Choose the size board and one of the game modes:
    - 1 Player against the computer
    - 2 Players
- A player wins if all the checkers of the opponent have been eaten, or if the opponnent does not have any legal moves.
- The winner is granted with points which are the difference between the players' number of checkers, where a King is worth 4 checkers.
- Check out the [official game instruction](https://docs.google.com/document/d/13gC1NHoNyjfVQDZ5n0ETDZBm3hUAs9gXqNTmpc8H_5o/edit)

## Design & Tech
- Object Oriented designed, modeling a real-world game objects, encapsulating the logic into an event-driven game engine, which a decoupled UI project can consume.
- Using C#, the .NET Framework and Windows Forms.

## Authors

- Ofer Peery - peryofer7@gmail.com
- Yael Efrat - yaelef48@gmail.com

## License

This application was developed as part of the Object Oriented Programming with C# and .NET Course, lectured by Guy Ronen in Reichman University.  
This project is licensed under the MIT License (see `LICENSE` file for more details).  
We do not own any of the photos in this app, nor the game rules.
