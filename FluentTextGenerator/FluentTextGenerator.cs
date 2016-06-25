using FluentTextGeneratorLibrary.Contracts;

namespace FluentTextGeneratorLibrary
{
    /// <summary>
    /// Entry point to the generator configuration.
    /// </summary>
    public sealed class FluentTextGenerator : IFluentTextGenerator
    {
        public IFluentTextGeneratorConfiguration Configure(string optionsAsJson = "")
        {
            return new FluentTextGeneratorConfiguration(optionsAsJson);
        }
    }
}
