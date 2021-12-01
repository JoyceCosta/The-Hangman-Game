using System;
using System.IO;

namespace HangmanGame
{   
    // Manages the words that are part of the game.
     class Words
    { 
        // Name of the file where the words are. Words must be one on each line. 
        private const string FileName = "words.txt"; 

        // Random number generator. 
        private Random random = new Random(); 

        // Array with the words that are part of the game. 
        private string[] words; 

        // Constructor. 
        public Words() 
        {
            // Reads the words. 
            ReadWords();
        } 

        // Reads the words in the file. 
        private void ReadWords() 
        {
            // Read the words into the array. 
            this.words = File.ReadAllLines(FileName); 

            // Converts all letters of words to uppercase.
            for (int i = 0; i < words.Length; i++) 
            {
                words[i] = words[i].ToUpper();
            }
        } 

        
    }
}