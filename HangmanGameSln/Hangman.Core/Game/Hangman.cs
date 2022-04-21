using System;
using System.Collections.Generic;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
         List<string> _wordDictionary = new List<string> { "bottle", "code", "speed", "snapchat", "radio", "random", "rands", "hands", "robot", "drive", "truck", "dance", "string", "license", "game", "phone", "time", "spoon", "cake", "drunk" };

        private string _randomWord;
        private string _guess;
        private int _numberOflives = 6;
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
            Random random = new Random();
            int index = random.Next(_wordDictionary.Count);
            _randomWord = _wordDictionary[index];
            for (int i = 0; i < _randomWord.Length; i++)
            {
                _guess = _guess + "_";
            }
            //   _guess = guess;
        }
        public void Run()
        {
            //   _renderer.Render(10, 5, 0);
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            while (_numberOflives > 0 && _numberOflives <= 6)
            {
                _renderer.Render(10, 5, _numberOflives);
                Console.SetCursorPosition(0, 15);
                Console.Write("Your current guess: ");
                Console.WriteLine(_guess);
                Console.Write("What is your next guess: ");
                var nextGuess = Console.ReadLine();
                char[] guessArray = _guess.ToCharArray();
                bool correct = false;
                for (int i = 0; i < _randomWord.Length; i++)
                {
                    if (_randomWord[i] == nextGuess[0])
                    {
                        guessArray[i] = _randomWord[i];
                        correct = true;
                        //we know its correct
                    }
                    //it was not correct
                }
                _guess = new string(guessArray);
                if (!correct)
                    _numberOflives--;
            }
        }

    }
}
