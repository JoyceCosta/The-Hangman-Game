using System;

namespace HangmanGame
{
    class Program
    {
        static void Main()
        {
            // Start the game. 
            Game game = new Game(3);
            game.Play();
        }
    }
}
