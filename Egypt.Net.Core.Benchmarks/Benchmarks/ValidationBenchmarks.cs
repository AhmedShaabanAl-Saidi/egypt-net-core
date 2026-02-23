using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Egypt.Net.Core.Benchmarks.Benchmarks;

/// <summary>
/// Benchmarks for validation operations.
/// These measure the cost of checking if a string is a valid National ID.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class ValidationBenchmarks
{
    private const string ValidId = "30101010123458";
    private const string InvalidFormatId = "abc123";
    private const string InvalidLengthId = "123";
    private const string InvalidDateId = "30113010123450";

    [Benchmark(Baseline = true, Description = "IsValid (full validation)")]
    public bool IsValid_Valid()
    {
        return EgyptianNationalId.IsValid(ValidId);
    }

    [Benchmark(Description = "IsValid with invalid format")]
    public bool IsValid_InvalidFormat()
    {
        return EgyptianNationalId.IsValid(InvalidFormatId);
    }

    [Benchmark(Description = "IsValid with invalid length")]
    public bool IsValid_InvalidLength()
    {
        return EgyptianNationalId.IsValid(InvalidLengthId);
    }

    [Benchmark(Description = "IsValid with invalid date")]
    public bool IsValid_InvalidDate()
    {
        return EgyptianNationalId.IsValid(InvalidDateId);
    }

    [Benchmark(Description = "String extension: IsValidEgyptianNationalId()")]
    public bool StringExtension_IsValid()
    {
        return ValidId.IsValidEgyptianNationalId();
    }

    [Benchmark(Description = "HasValidFormat (format only)")]
    public bool HasValidFormat_Valid()
    {
        return ValidId.HasValidNationalIdFormat();
    }

    [Benchmark(Description = "HasValidFormat with invalid")]
    public bool HasValidFormat_Invalid()
    {
        return InvalidFormatId.HasValidNationalIdFormat();
    }

    [Benchmark(Description = "ValidateChecksum (if enabled)")]
    public bool ValidateChecksum_Valid()
    {
        return EgyptianNationalId.ValidateChecksum(ValidId);
    }

    [Benchmark(Description = "Validate 100 IDs")]
    public int ValidateMultiple_100()
    {
        int validCount = 0;
        for (int i = 0; i < 100; i++)
        {
            if (EgyptianNationalId.IsValid(ValidId))
                validCount++;
        }
        return validCount;
    }

    [Benchmark(Description = "Validate 1000 IDs")]
    public int ValidateMultiple_1000()
    {
        int validCount = 0;
        for (int i = 0; i < 1000; i++)
        {
            if (EgyptianNationalId.IsValid(ValidId))
                validCount++;
        }
        return validCount;
    }
}