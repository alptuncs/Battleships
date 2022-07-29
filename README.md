# Battleships

This is a simple .Net Framework Console Application project that lets you play a simple singleplayer game.

![alt text](https://github.com/alptuncs/Battleships/blob/S%C4%B0ngleplayer-Tutorial-Refactoring/Battleships/src/GameImages/game_screenshot.png)

## Game Rules

Game rules are similar to the boardgame Battleships, ships are placed on the board and the player tries to guess the coordinates of ships that are on the opposite board until one side looses all their ships but since this is a singleplayer game there is only one board and the ships are placed randomly, the game continues until all the ship coordinates are guessed by the user or until the user runs out of lives. 

## GameSession

The game is played in GameSession class which uses BoardManager, GameManager classes to initialize the board and use the game logic and prints the board using BoardRenderer class, Ships are created using a TargetFactory and GameSession is created using a GameSessionFactory, it lets you play the game untill a game ending condition occurs.

## BoardManager

BoardManager class initializes the board and contains board logic. Board manager tries to randomly place the ships that are created by a TargetFactory. BoardManager creates Coordinate with random values bounded with board dimensions and tries to place them by doing few checks. First it checks if the ship with given direction and size will fit in the board then it checks if there are allready a ship in those coordinates then it checks if adjacent squares of each square we want to place the ship contains a ship. If one of these checks returns a fail, BoardManager tries to place the same ship with another Coordinate with random values. When successful on placing the ship, repeats the same process until all the ships are placed on the board.

## BoardRenderer

BoardRenderer contains and returns a string called inputGraphicString which when printed to the console displays the board. BoardRenderer gets the board information from BoardManager and updates the inputGraphicString by iterating the board and visualizing the cell using the information each cell holds and returns the updated string. 

## GameManager

GameManager contains the game logic, asks for user input checks if the user input is in correct format, then creates a Coordinate with the user input and asks the BoardManager if there is a ship in that coordinate or if that coordinate is allready been hit and determines what to do next. Based on the performance of the user it keeps a score and reduces the player lives if user is not successful in finding a ship or entered a previously tried coordinate.

## Learning Objectives
During this project I started learning to use .Net Framework and GitHub, to work on Unit Tests and Code Refactoring, Test Driven Developement, Design Patterns and also the differences between student mindset and professional mindset which I experienced first hand the different aproach to when a work is complete or what to do when you need help.
