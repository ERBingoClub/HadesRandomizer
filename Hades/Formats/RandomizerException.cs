namespace Hades.Formats;

public sealed class RandomizerException : Exception
{
    public RandomizerException(string message) : base(message) { }
    public RandomizerException(string message, Exception innerException) : base(message, innerException) { }
}