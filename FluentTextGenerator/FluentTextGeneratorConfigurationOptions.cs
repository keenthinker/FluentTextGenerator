using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FluentTextGeneratorLibrary
{
    /// <summary>
    /// Fluent generator configuration options.
    /// </summary>
    public sealed class FluentTextGeneratorConfigurationOptions
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool IncludeSmallCharacters { get; set; }
        public bool IncludeCapitalCharacters { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        public string SpecialCharactersList { get; set; }
        public string ExcludeCharactersList { get; set; }
        public Dictionary<string, string> ReplaceDictionary { get; set; }

        /// <summary>
        /// Constructor with default configuration option values.
        /// </summary>
        public FluentTextGeneratorConfigurationOptions()
        {
            MinLength = 0;
            MaxLength = 0;
            IncludeSmallCharacters = true;
            IncludeCapitalCharacters = true;
            IncludeNumbers = true;
            IncludeSpecialCharacters = true;
            SpecialCharactersList = String.Empty;
            ExcludeCharactersList = String.Empty;
            ReplaceDictionary = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructor that reads and initializes the options from a JSON string.
        /// </summary>
        /// <param name="optionsAsJson">JSON string containing the configuration options</param>
        public FluentTextGeneratorConfigurationOptions(string optionsAsJson) : this()
        {
            if (!String.IsNullOrWhiteSpace(optionsAsJson))
            {
                try
                {
                    var options = JsonConvert.DeserializeObject<FluentGeneratorConfigurationOptionsDTO>(optionsAsJson);

                    this.MinLength = options.MinLength;
                    this.MaxLength = options.MaxLength;
                    this.IncludeSmallCharacters = options.IncludeSmallCharacters;
                    this.IncludeCapitalCharacters = options.IncludeCapitalCharacters;
                    this.IncludeNumbers = options.IncludeNumbers;
                    this.IncludeSpecialCharacters = options.IncludeSpecialCharacters;
                    this.SpecialCharactersList = options.SpecialCharactersList;
                    this.ExcludeCharactersList = options.ExcludeCharactersList;
                    this.ReplaceDictionary = options.ReplaceDictionary;
                }
                catch (Exception exception)
                {
                    throw new Exception("JSON string configuration error. See inner exception for more details.", exception);
                }
            }
        }
    }

    /// <summary>
    /// Helper class.
    /// </summary>
    internal sealed class FluentGeneratorConfigurationOptionsDTO
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool IncludeSmallCharacters { get; set; }
        public bool IncludeCapitalCharacters { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        public string SpecialCharactersList { get; set; }
        public string ExcludeCharactersList { get; set; }
        public Dictionary<string, string> ReplaceDictionary { get; set; }

        public FluentGeneratorConfigurationOptionsDTO()
        {
            MinLength = 0;
            MaxLength = 0;
            IncludeSmallCharacters = false;
            IncludeCapitalCharacters = false;
            IncludeNumbers = false;
            IncludeSpecialCharacters = false;
            SpecialCharactersList = String.Empty;
            ExcludeCharactersList = String.Empty;
            ReplaceDictionary = new Dictionary<string, string>();
        }
    }
}
