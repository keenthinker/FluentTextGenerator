namespace FluentTextGeneratorLibrary.Contracts
{
    /// <summary>
    /// Entry point to the generator configuration.
    /// </summary>
    public interface IFluentTextGenerator
    {
        IFluentTextGeneratorConfiguration Configure();
    }
}
