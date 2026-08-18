namespace Hades.Formats;

public interface IRandomizerFormat
{
    string Id { get; }
    string DisplayName { get; }
    string Me3File { get; }
    void Exec(int baseSeed, Action<string>? statusCallback = null);
    void Launch();
}
