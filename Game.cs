using System;
using System.Collections.Generic;

namespace HangmanGame
{   
    // Represents the game.
    class Game
    {
        // Indicates the maximum number of errors the player can have before the game ends.
        private int maxErrors;

        // Constructor. 
        public Game(int maxErrors) 
        {
            this.maxErrors = maxErrors;
        } 

        // Play the game.
        public void Play() 
        {
            // Creates the object that will manage the active word in the game.
            Word w = new Word(); 

            while (true) 
            {
                Console.WriteLine("--- THE HANGMAN GAME ---\n");
                Console.WriteLine("You can get it wrong a maximum of {0} times\n", maxErrors);

                // Variable to control the player errors.
                int errors = 0;

                // Set to store already tried letters (to prevent the player from trying again).
                ISet<char> triedLetters = new HashSet<char>(); 

                // The game is active as long as the word is not found completely and as long as the player 
                // does not reach the maximum number of errors.
                while (!w.Finished && errors < maxErrors) 
                {
                    Console.WriteLine(w.PartialWord); 

                    // Asks the player for the letter.
                    Console.Write("\nType a letter: "); 
                    string letter = Console.ReadLine(); 

                    // If the player don't type, asks again. 
                    if (String.IsNullOrWhiteSpace(letter)) 
                    {
                        continue;
                    } 

                    // Check if the player has tried that letter.
                    if (triedLetters.Contains(letter[0])) 
                    {
                        // If it has, asks again.
                        Console.WriteLine("The letter {0} has already been tried\n", letter[0]);
                        continue;
                    } 
                    else 
                    {
                        // If not, add the letter to the set of attempted letters.
                        triedLetters.Add(letter[0]);
                    } 

                    // Searches the letter in the word.
                    bool found = w.Guess(letter[0]); 

                    if (found) 
                    {
                        // If found, shows the message.
                        Console.WriteLine("Congrats! The letter {0} was found!", letter[0]);
                    }
                    else
                    {
                        // If not found, increment the number of errors and display the message.
                        errors++;
                        Console.WriteLine("Sorry, the letter {0} does not exist in the word. Strike {1}.", letter[0], errors);
                    } 

                    Console.WriteLine();
                } 

                // If the loop ended, it's because the player won or lost.
                if (errors < maxErrors) 
                {
                    // If the maximum number of errors has not been reached, the player has won.
                    Console.Write("\nYou guessed the word: {0}. Want to play one more time? (Y/N): ", w.CompleteWord);
                }
                else 
                {
                    // If the maximum number of errors has been reached, the player has lost.
                    Console.Write("\nYou didn't guess the word it was: {0}. Want to play one more time? (Y/N): ", w.CompleteWord);
                } 

                // Wait for player option to play again.
                string playAgain = Console.ReadLine();
                if (playAgain.Length > 0 && (playAgain[0] == 'y' || playAgain[0] == 'Y'))
                {
                    // If user typed 'y' or 'Y', play again.
                    Console.WriteLine("Ok, let's play again!");

                    // Go to the next word.
                    w.Next();

                    // Clean the console.
                    Console.Clear();
                } 
                else
                {
                    // Any other option typed, ends the game.
                    Console.WriteLine("Bye!");
                    break;
                }
            }
        }
    }
}