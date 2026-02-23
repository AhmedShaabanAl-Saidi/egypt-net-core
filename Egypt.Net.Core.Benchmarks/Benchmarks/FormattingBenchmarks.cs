using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Egypt.Net.Core.Benchmarks.Benchmarks;

/// <summary>
/// Benchmarks for formatting operations.
/// These measure the cost of converting NationalId to different string formats.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class FormattingBenchmarks
{
    private readonly EgyptianNationalId _id = new("30101010123458");

    [Benchmark(Baseline = true, Description = "ToString()")]
    public string Format_ToString()
    {
        return _id.ToString();
    }

    [Benchmark(Description = "FormatWithDashes()")]
    public string Format_WithDashes()
    {
        return _id.FormatWithDashes();
    }

    [Benchmark(Description = "FormatWithSpaces()")]
    public string Format_WithSpaces()
    {
        return _id.FormatWithSpaces();
    }

    [Benchmark(Description = "FormatWithBrackets()")]
    public string Format_WithBrackets()
    {
        return _id.FormatWithBrackets();
    }

    [Benchmark(Description = "FormatMasked()")]
    public string Format_Masked()
    {
        return _id.FormatMasked();
    }

    [Benchmark(Description = "FormatDetailed()")]
    public string Format_Detailed()
    {
        return _id.FormatDetailed();
    }

    [Benchmark(Description = "Format 100 IDs with dashes")]
    public List<string> FormatMultiple_100_Dashes()
    {
        var results = new List<string>(100);
        for (int i = 0; i < 100; i++)
        {
            results.Add(_id.FormatWithDashes());
        }
        return results;
    }

    [Benchmark(Description = "Format 100 IDs masked")]
    public List<string> FormatMultiple_100_Masked()
    {
        var results = new List<string>(100);
        for (int i = 0; i < 100; i++)
        {
            results.Add(_id.FormatMasked());
        }
        return results;
    }
}