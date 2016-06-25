namespace FluentTextGeneratorLibrary.Contracts
{
    /// <summary>
    /// Entry point to the generator configuration.
    /// </summary>
    public interface IFluentTextGenerator
    {
        /// <summary>
        /// Initialize the configuration. If the optional parameter is set, the values are parsend and used instead of the default values.
        /// </summary>
        /// <param name="optionsAsJson">JSON string containing the configuration options</param>
        /// <returns>A configuration instance</returns>
        IFluentTextGeneratorConfiguration Configure(string optionsAsJson = "");
    }
}
