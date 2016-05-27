using FluentTextGeneratorLibrary.Contracts;

namespace FluentTextGeneratorLibrary
{
    /// <summary>
    /// Entry point to the generator configuration.
    /// </summary>
    public sealed class FluentTextGenerator : IFluentTextGenerator
    {
        public IFluentTextGeneratorConfiguration Configure()
        {
            return new FluentTextGeneratorConfiguration();
        }
    }
}
