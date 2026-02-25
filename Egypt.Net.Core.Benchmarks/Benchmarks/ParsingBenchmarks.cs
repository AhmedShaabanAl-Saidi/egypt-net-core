using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Egypt.Net.Core.Benchmarks.Benchmarks;

/// <summary>
/// Benchmarks for parsing and creating EgyptianNationalId instances.
/// These measure the cost of constructing objects from strings.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class ParsingBenchmarks
{
    private const string ValidId = "30101010123458";
    private const string InvalidFormatId = "abc123";
    private const string InvalidDateId = "30113010123450"; // Invalid date: month 13

    [Benchmark(Baseline = true, Description = "Parse valid ID (constructor)")]
    public EgyptianNationalId ParseValid_Constructor()
    {
        return new EgyptianNationalId(ValidId);
    }

    [Benchmark(Description = "TryCreate with valid ID")]
    public bool ParseValid_TryCreate()
    {
        return EgyptianNationalId.TryCreate(ValidId, out _);
    }

    [Benchmark(Description = "TryCreate with valid ID (with result)")]
    public EgyptianNationalId? ParseValid_TryCreate_WithResult()
    {
        EgyptianNationalId.TryCreate(ValidId, out var result);
        return result;
    }

    [Benchmark(Description = "String extension: ToEgyptianNationalId()")]
    public EgyptianNationalId? ParseValid_StringExtension()
    {
        return ValidId.ToEgyptianNationalId();
    }

    [Benchmark(Description = "Parse 10 valid IDs")]
    public List<EgyptianNationalId> ParseMultiple_10()
    {
        var ids = new List<EgyptianNationalId>(10);
        for (int i = 0; i < 10; i++)
        {
            ids.Add(new EgyptianNationalId(ValidId));
        }
        return ids;
    }

    [Benchmark(Description = "Parse 100 valid IDs")]
    public List<EgyptianNationalId> ParseMultiple_100()
    {
        var ids = new List<EgyptianNationalId>(100);
        for (int i = 0; i < 100; i++)
        {
            ids.Add(new EgyptianNationalId(ValidId));
        }
        return ids;
    }

    [Benchmark(Description = "TryCreate with invalid format")]
    public bool ParseInvalid_Format()
    {
        return EgyptianNationalId.TryCreate(InvalidFormatId, out _);
    }

    [Benchmark(Description = "TryCreate with invalid date")]
    public bool ParseInvalid_Date()
    {
        return EgyptianNationalId.TryCreate(InvalidDateId, out _);
    }
}