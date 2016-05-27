namespace FluentTextGeneratorLibrary.Contracts
{
    /// <summary>
    /// Generator configuration.
    /// </summary>
    public interface IFluentTextGeneratorConfiguration
    {
        /// <summary>
        /// Sets the minimal length of the generated string.
        /// </summary>
        /// <param name="min">The minimal length of the generated string. Default value 0 means that a random number between 1 and 250 will be generated.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration MinLength(int min = 0);

        /// <summary>
        /// Sets the maximal length of the generated string.
        /// </summary>
        /// <param name="max">The maximal length of the generated string. Default value 0 means that a random number between 1 and 250 will be generated.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration MaxLength(int max = 0);

        /// <summary>
        /// The alphabet used for the string generation should include small characters (a-z)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include small characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration IncludeSmallCharacters(bool yes = true);

        /// <summary>
        /// The alphabet used for the string generation should include capital characters (A-Z)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include capital characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration IncludeCapitalCharacters(bool yes = true);

        /// <summary>
        /// The alphabet used for the string generation should include numbers (0-9)
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will include numbers; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration IncludeNumbers(bool yes = true);

        /// <summary>
        /// The alphabet used for the string generation should include special characters.
        /// Default characters are:
        /// .,+-*/!?;:{}()[]%$&~#@|<>
        /// </summary>
        /// <param name="yes">If set to <c>true</c> the alphabet will special characters; <c>false</c> otherwise. The default value is <c>true</c>.</param>
        /// <param name="specialCharacters">List of custom special characters that overwrites the default list.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration IncludeSpecialCharacters(bool yes = true, string specialCharacters = "");

        /// <summary>
        /// Removes the specified characters from the alphabet - the generated string does not contain the excluded characters. 
        /// </summary>
        /// <param name="excludeCharacters">String containing the characters to be excluded from the final alphabet used for the string generation.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration ExcludeCharacters(string excludeCharacters = "");

        // replace source character with destination character, e.g: Replace("1", "I") "gh1T6" => "ghIT6"
        /// <summary>
        /// Replace all oldValue characters with the newValue characters in the generated text.
        /// </summary>
        /// <param name="oldValue">Value to be replaced.</param>
        /// <param name="newValue">Value to be used instead of oldValue.</param>
        /// <returns>Current configuration instance</returns>
        IFluentTextGeneratorConfiguration Replace(string oldValue, string newValue);

        // TODO: only unique characters in generated string
        //IFluentTextGeneratorConfiguration OnlyUniqueCharacters(bool yes);

        /// <summary>
        /// Generates a string regarding all configuration options.
        /// Default values are (if nothing is specified <code>object.Configure().Generate()</code>):
        /// Minimal length: random from 1 to 251
        /// Maximal length: random from minLength to 251
        /// Include small characters: true
        /// Include capital characters: true;
        /// Include numbers: true;
        /// Include special characters: true;
        /// </summary>
        /// <returns>A random string.</returns>
        string Generate();
    }
}
