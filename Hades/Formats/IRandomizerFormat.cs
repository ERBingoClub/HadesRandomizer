using EldenRingParamsEditor;
using UniversalReplacementRandomizer;

namespace Hades.Formats;

public interface IRandomizerFormat
{
    string Id { get; }
    string DisplayName { get; }
    string Me3File { get; }
    void Exec(int? baseSeed);
}
