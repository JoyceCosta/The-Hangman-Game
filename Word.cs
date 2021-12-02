using System;

namespace HangmanGame
{   
    // Manages the active word of the game.
    public class Word
    {
        // Character to be displayed in place of the unguessed letters.
        private const char WildCard = '*'; 

        // Object that manages the words of the game. 
        private Words words = new Words(); 

        // Characters of the complete word.
        private char[] completeWordChars; 

        // Partial word characters, which may contain wildcards.
        private char[] partialWordChars; 

        // Full word. 
        public string CompleteWord { get; private set; } 

        // Partial word. 
        public string PartialWord 
        {
            get 
            {
            // Creates a string using the character array.
            return new string(partialWordChars);
            }
        } 

        // Indicates whether the game has ended (if the word was completely guessed).
        public bool Finished 
        {
            get 
            {
                // Checks whether the partial word equals the complete word
                return PartialWord == CompleteWord;
            }
        } 

        // Constructor.
        public Word() 
        {
            // When the object is built, it searches for the first word.
            Next();
        } 

        // Get a new word.
        public void Next()
        {
            // Draw a new word. 
            this.CompleteWord = words.Pick();

            // Converts the word into a char[].
            this.completeWordChars = this.CompleteWord.ToCharArray();
            
            //Instantiates the partial word character array and assigns the wildcard to all positions.
            this.partialWordChars = new char[completeWordChars.Length];
            for (int i = 0; i < partialWordChars.Length; i++) 
            {
                if (completeWordChars[i] != ' ') 
                {
                    partialWordChars[i] = WildCard;
                } 
                else 
                {
                    partialWordChars[i] = ' ';
                }
            }
        } 


        // Try to guess a letter. 
        public bool Guess(char letter) 
        {
            bool found = false;

            // Converts the character to uppercase, as the words are all uppercase.
            letter = Char.ToUpper(letter); 

            // Search for the letter in the word. 
            for (int i = 0; i < completeWordChars.Length; i++) 
            {
                if (completeWordChars[i] == letter) 
                {
                    // If the letter is found, the partial word character array has the 
                    // corresponding wildcard replaced by the letter.
                    partialWordChars[i] = letter;
                    found = true;
                }
            } 

            return found;
        }
    }
}