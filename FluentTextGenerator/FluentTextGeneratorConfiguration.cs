using FluentTextGeneratorLibrary.Contracts;
using System;
using System.Text;

namespace FluentTextGeneratorLibrary
{
    /// <summary>
    /// Fluent generator configuration implementation
    /// </summary>
    public sealed class FluentTextGeneratorConfiguration : IFluentTextGeneratorConfiguration
    {
        #region Constants
        private const int randomUpperBound = 251;
        
        private const string alphabetSmall = @"abcdefghijklmnopqrstuvwxyz";
        private const string alphabetCapital = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string alphabetNumbers = @"0123456789";
        private const string alphabetSpecial = @".,+-*/!?;:{}()[]%$&~#@|<>";
        #endregion

        #region Private Fields
        private readonly FluentTextGeneratorConfigurationOptions options = new FluentTextGeneratorConfigurationOptions();
        private Random random = new Random();
        #endregion

        #region Private Methods
        private T iif<T>(bool condition, T t, T f)
        {
            return condition ? t : f;
        }

        private string buildAlphabet()
        {
            var specials = iif(!String.IsNullOrEmpty(options.SpecialCharactersList), options.SpecialCharactersList, alphabetSpecial);

            var alphabet = new StringBuilder();

            alphabet.Append(iif(options.IncludeSmallCharacters, alphabetSmall, String.Empty));
            alphabet.Append(iif(options.IncludeCapitalCharacters, alphabetCapital, String.Empty));
            alphabet.Append(iif(options.IncludeNumbers, alphabetNumbers, String.Empty));
            alphabet.Append(iif(options.IncludeSpecialCharacters, specials, String.Empty));
            // exclude characters
            foreach (var character in options.ExcludeCharactersList.Trim())
            {
                alphabet.Replace(character.ToString(), String.Empty);
            }
            //
            return alphabet.ToString();
        }

        private Tuple<int, int> calculateLowerAndUpperBound()
        {
            var lowerBound = 0;
            var upperBound = 0;
            var minLength = options.MinLength;
            // force min length to be always smaller or equal to max length.
            var maxLength = Math.Max(minLength, options.MaxLength);
            // 
            if ((minLength <= 0) && (maxLength <= 0))
            {
                lowerBound = random.Next(1, randomUpperBound);
                upperBound = Math.Max(lowerBound, random.Next(1, randomUpperBound));
            }
            else if ((minLength <= 0) && (maxLength > 0))
            {
                lowerBound = random.Next(1, maxLength);
                upperBound = random.Next(lowerBound, maxLength + 1);
            }
            else if ((minLength > 0) && (maxLength <= 0))
            {
                lowerBound = minLength;
                upperBound = random.Next(minLength, randomUpperBound);
            }
            else
            {
                lowerBound = random.Next(minLength, maxLength + 1);
                var max = Math.Max(lowerBound, maxLength + 1);
                upperBound = random.Next(lowerBound, max);
            }

            return new Tuple<int, int>(lowerBound, upperBound);
        }
        #endregion

        #region Constructors
        public FluentTextGeneratorConfiguration()
        {
        }

        public FluentTextGeneratorConfiguration(string optionsAsJson) : this()
        {
            this.options = new FluentTextGeneratorConfigurationOptions(optionsAsJson);
        }
        #endregion

        #region Public Methods and Interface Implementation

        /// <summary>
        /// Sets the minimal length of the generated string.
        /// </summary>
        /// <param name="min">The minimal length of the generated string. Default value 0 means that a random number between 1 and 250 will be generated.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration MinLength(int min = 0)
        {
            options.MinLength = iif(min < 0, 0, min);
            return this;
        }

        /// <summary>
        /// Sets the maximal length of the generated string.
        /// </summary>
        /// <param name="max">The maximal length of the generated string. Default value 0 means that a random number between 1 and 250 will be generated.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration MaxLength(int max = 0)
        {
            options.MaxLength = iif(max < 0, 0, max);
            return this;
        }

        /// <summary>
        /// The alphabet used for the string generation should include small characters (a-z)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include small characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration IncludeSmallCharacters(bool yes = true)
        {
            options.IncludeSmallCharacters = yes;
            return this;
        }

        /// <summary>
        /// The alphabet used for the string generation should include capital characters (A-Z)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include capital characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration IncludeCapitalCharacters(bool yes = true)
        {
            options.IncludeCapitalCharacters = yes;
            return this;
        }

        /// <summary>
        /// The alphabet used for the string generation should include numbers (0-9)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include numbers; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration IncludeNumbers(bool yes = true)
        {
            options.IncludeNumbers = yes;
            return this;
        }

        /// <summary>
        /// The alphabet used for the string generation should include special characters.
        /// Default characters are:
        /// .,+-*/!?;:{}()[]%$&~#@
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will special characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <param name="specialCharacters">List of custom special characters that overwrites the default list.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration IncludeSpecialCharacters(bool yes = true, string specialCharacters = "")
        {
            options.IncludeSpecialCharacters = yes;
            options.SpecialCharactersList = specialCharacters;
            return this;
        }

        /// <summary>
        /// Removes the specified characters from the final alphabet - the generated string does not contain the excluded characters. 
        /// </summary>
        /// <param name="excludeCharacters">String containing the characters to be excluded from the final alphabet used for the string generation.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration ExcludeCharacters(string excludeCharacters = "")
        {
            options.ExcludeCharactersList = excludeCharacters;
            return this;
        }

        /// <summary>
        /// Replace all oldValue characters with the newValue characters in the generated text.
        /// </summary>
        /// <param name="oldValue">Value to be replaced.</param>
        /// <param name="newValue">Value to be used instead of oldValue.</param>
        /// <returns>Current configuration instance</returns>
        public IFluentTextGeneratorConfiguration Replace(string oldValue, string newValue)
        {
            if (!options.ReplaceDictionary.ContainsKey(oldValue))
            {
                options.ReplaceDictionary.Add(oldValue, newValue);
            }
            return this;
        }

        /// <summary>
        /// Generates a random string regarding all configuration options.
        /// Default values are (if nothing is specified <code>object.Configure().Generate()</code>):
        /// Minimal length: random from 1 to 251
        /// Maximal length: random from minLength to 251
        /// Include small characters: true
        /// Include capital characters: true;
        /// Include numbers: true;
        /// Include special characters: true;
        /// </summary>
        /// <returns>A random string.</returns>
        public string Generate()
        {
            if (!options.IncludeSmallCharacters && 
                !options.IncludeSpecialCharacters && 
                !options.IncludeCapitalCharacters && 
                !options.IncludeNumbers)
            {
                throw new Exception("At least one character configuration should be true in order to create an alphabet!");
            }
            Func<string, char> characterAtRandomPositionFrom = a => a[random.Next(0, a.Length)];
            Action<StringBuilder, char> appendTo = (sb, ch) => sb.Append(ch);
            // build alphabet
            var alphabet = buildAlphabet();
            // start empty
            var text = new StringBuilder();
            //
            var lub = calculateLowerAndUpperBound();
            var lowerBound = lub.Item1;
            var upperBound = lub.Item2;
            // generate text with at least the specified min length
            for (var i = 0; i < lowerBound; i++)
            {
                appendTo(text, characterAtRandomPositionFrom(alphabet));
            }
            // generate text with max the upper bound length
            while (lowerBound < upperBound)
            {
                appendTo(text, characterAtRandomPositionFrom(alphabet));
                lowerBound++;
            }
            // replace characters
            foreach (var replaceItem in options.ReplaceDictionary)
            {
                text.Replace(replaceItem.Key, replaceItem.Value);
            }
            // build string
            return text.ToString();
        }

        #endregion
    }
}
