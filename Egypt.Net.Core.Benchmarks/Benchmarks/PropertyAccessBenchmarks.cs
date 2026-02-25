using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Egypt.Net.Core.Enums;

namespace Egypt.Net.Core.Benchmarks.Benchmarks;

/// <summary>
/// Benchmarks for property access operations.
/// These measure the cost of accessing computed properties.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class PropertyAccessBenchmarks
{
    private readonly EgyptianNationalId _id = new("30101010123458");

    // Birth & Age Properties
    [Benchmark(Baseline = true, Description = "Access BirthDate")]
    public DateTime AccessProperty_BirthDate()
    {
        return _id.BirthDate;
    }

    [Benchmark(Description = "Access Age")]
    public int AccessProperty_Age()
    {
        return _id.Age;
    }

    [Benchmark(Description = "Access BirthYear, Month, Day (3 properties)")]
    public (int year, int month, int day) AccessProperty_BirthComponents()
    {
        return (_id.BirthYear, _id.BirthMonth, _id.BirthDay);
    }

    // Gender Properties
    [Benchmark(Description = "Access Gender")]
    public Gender AccessProperty_Gender()
    {
        return _id.Gender;
    }

    [Benchmark(Description = "Access GenderAr")]
    public string AccessProperty_GenderAr()
    {
        return _id.GenderAr;
    }

    // Governorate Properties
    [Benchmark(Description = "Access Governorate")]
    public Governorate AccessProperty_Governorate()
    {
        return _id.Governorate;
    }

    [Benchmark(Description = "Access GovernorateNameAr")]
    public string AccessProperty_GovernorateNameAr()
    {
        return _id.GovernorateNameAr;
    }

    // Region Properties
    [Benchmark(Description = "Access BirthRegion")]
    public Region AccessProperty_BirthRegion()
    {
        return _id.BirthRegion;
    }

    [Benchmark(Description = "Access IsFromUpperEgypt")]
    public bool AccessProperty_IsFromUpperEgypt()
    {
        return _id.IsFromUpperEgypt;
    }

    // Generation Properties
    [Benchmark(Description = "Access Generation")]
    public Generation AccessProperty_Generation()
    {
        return _id.Generation;
    }

    [Benchmark(Description = "Access GenerationAr")]
    public string AccessProperty_GenerationAr()
    {
        return _id.GenerationAr;
    }

    // Multiple Property Access (typical usage pattern)
    [Benchmark(Description = "Access 5 common properties")]
    public (DateTime birth, int age, Gender gender, string gov, Region region) AccessMultipleProperties()
    {
        return (_id.BirthDate, _id.Age, _id.Gender, _id.GovernorateNameAr, _id.BirthRegion);
    }

    [Benchmark(Description = "Access all demographic properties")]
    public (Gender gender, Generation gen, bool isAdult) AccessAllDemographics()
    {
        return (_id.Gender, _id.Generation, _id.IsAdult);
    }
}