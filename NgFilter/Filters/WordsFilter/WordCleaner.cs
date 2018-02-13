using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NgFilter.Filters.WordsFilter
{
    internal class WordCleaner
    {
        // contains all correct words with all possible forms
        HashSet<string> dictionary = new HashSet<string>();
        HashSet<char> alphabet = new HashSet<char>() {'a','ą','b','c','ć','d','e','ę','f','g','h','i','j','k','l', 'ł','m','n',
            'ń','o','ó','p','r','s','ś','t','u','w','y','z','ź','ż','x','-', '\'', '.'};

        #region Public methods

        public WordCleaner()
        {
            LoadDictionary();
        }

        /// <summary>
        /// Clear word by removing all incorrect chars. Also checks if what remains is correct word by 
        /// checking in dictionary
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Correct word or empty string</returns>
        public string Clear(String word)
        {
            word = RemoveIncorrectChars(word);

            if ((word.Length == 1 && word != ".") || IsCorrectWord(word))
                return word;
            else if (word.Length > 1)
            {
                if (word.Last() != '.')
                {
                    word = word.TrimEnd('.');
                    if (IsCorrectWord(word))
                        return word;
                }
            }
            return string.Empty;
        }

        #endregion

        #region Private methods

        private void LoadDictionary()
        {
            Console.WriteLine("Start loading dictionary...");
            var _words = File.ReadAllLines(@"Data\polishDictionary.txt");
            foreach (var w in _words)
                dictionary.Add(w);
            Console.WriteLine("Loaded dictionary");
        }

        // remove all incorrect characters in string except dots at the end
        private string RemoveIncorrectChars(string word)
        {
            string result = string.Empty;

            for (int i = 0; i < word.Length; ++i)
                if (alphabet.Contains(word[i]))
                    result += word[i];

            result = result.TrimEnd(new char[] { '-', '\'' });
            result = result.TrimStart(new char[] { '-', '\'', '.' });

            return result;
        }

        // Check if words is in dictionary 
        private bool IsCorrectWord(string word)
        {
            return dictionary.Contains(word);
        }

        #endregion
    }
}
