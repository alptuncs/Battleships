# Battleships

This is a simple .Net Framework Console Application project that lets you play a simple singleplayer game.

![alt text](https://github.com/alptuncs/Battleships/blob/S%C4%B0ngleplayer-Tutorial-Refactoring/Battleships/src/GameImages/game_screenshot.png)

The game is played GameSession class which uses BoardManager, GameManager classes to initialize the board and use the game logic and prints the board using BoardRenderer class, Ships are created using a TargetFactory and GameSession is created using a GameSessionFactory. BoardManager class initializes the board and contains board logic that places the ships that are created by a TargetFactory randomly by doing neighbor and adjacent square checks. BoardRenderer gets the board information from BoardManager and returns a string which when printed to the console shows the board. GameManager contains the game logic, asks for user input and determines which action should be taken based on that input and updates the game. GameSession is created using a GameSessionFactory, it terminates the game when game ending conditions occur.

During this project I started to learn using .Net Framework and GitHub, working on Unit Tests and Code Refactoring, Test Driven Developement, Design Patterns and also differences between student mindset and professional mindset which I experienced first hand the different aproach to when a work is complete or what to do when you need help.
