using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Egypt.Net.Core.Enums;

namespace Egypt.Net.Core.Benchmarks.Benchmarks;

/// <summary>
/// Benchmarks for collection operations and LINQ queries.
/// These measure the cost of working with collections of NationalIds.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class CollectionBenchmarks
{
    private readonly List<EgyptianNationalId> _ids100;
    private readonly List<EgyptianNationalId> _ids1000;
    private readonly HashSet<EgyptianNationalId> _hashSet;

    public CollectionBenchmarks()
    {
        // Create test data
        _ids100 = new List<EgyptianNationalId>(100);
        for (int i = 0; i < 100; i++)
        {
            _ids100.Add(new EgyptianNationalId("30101010123458"));
        }

        _ids1000 = new List<EgyptianNationalId>(1000);
        for (int i = 0; i < 1000; i++)
        {
            _ids1000.Add(new EgyptianNationalId("30101010123458"));
        }

        _hashSet = new HashSet<EgyptianNationalId>(_ids100);
    }

    [Benchmark(Baseline = true, Description = "Add 100 IDs to List")]
    public List<EgyptianNationalId> Collection_AddToList_100()
    {
        var list = new List<EgyptianNationalId>(100);
        for (int i = 0; i < 100; i++)
        {
            list.Add(new EgyptianNationalId("30101010123458"));
        }
        return list;
    }

    [Benchmark(Description = "Add 100 IDs to HashSet")]
    public HashSet<EgyptianNationalId> Collection_AddToHashSet_100()
    {
        var set = new HashSet<EgyptianNationalId>();
        for (int i = 0; i < 100; i++)
        {
            set.Add(new EgyptianNationalId("30101010123458"));
        }
        return set;
    }

    [Benchmark(Description = "LINQ: Filter adults (100 IDs)")]
    public List<EgyptianNationalId> LINQ_FilterAdults_100()
    {
        return _ids100.Where(id => id.IsAdult).ToList();
    }

    [Benchmark(Description = "LINQ: Filter by governorate (100 IDs)")]
    public List<EgyptianNationalId> LINQ_FilterGovernorate_100()
    {
        return _ids100.Where(id => id.Governorate == Governorate.Cairo).ToList();
    }

    [Benchmark(Description = "LINQ: Filter by region (100 IDs)")]
    public List<EgyptianNationalId> LINQ_FilterRegion_100()
    {
        return _ids100.Where(id => id.IsFromUpperEgypt).ToList();
    }

    [Benchmark(Description = "LINQ: Filter by generation (100 IDs)")]
    public List<EgyptianNationalId> LINQ_FilterGeneration_100()
    {
        return _ids100.Where(id => id.Generation == Generation.GenerationZ).ToList();
    }

    [Benchmark(Description = "LINQ: Group by region (100 IDs)")]
    public Dictionary<Region, int> LINQ_GroupByRegion_100()
    {
        return _ids100
            .GroupBy(id => id.BirthRegion)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    [Benchmark(Description = "LINQ: Group by generation (100 IDs)")]
    public Dictionary<Generation, int> LINQ_GroupByGeneration_100()
    {
        return _ids100
            .GroupBy(id => id.Generation)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    [Benchmark(Description = "LINQ: Order by age (100 IDs)")]
    public List<EgyptianNationalId> LINQ_OrderByAge_100()
    {
        return _ids100.OrderBy(id => id.Age).ToList();
    }

    [Benchmark(Description = "LINQ: Order by birth date (100 IDs)")]
    public List<EgyptianNationalId> LINQ_OrderByBirthDate_100()
    {
        return _ids100.OrderBy(id => id.BirthDate).ToList();
    }

    [Benchmark(Description = "LINQ: Complex query (100 IDs)")]
    public List<EgyptianNationalId> LINQ_ComplexQuery_100()
    {
        return _ids100
            .Where(id => id.IsAdult)
            .Where(id => id.IsFromUpperEgypt)
            .Where(id => id.Generation == Generation.GenerationZ)
            .OrderBy(id => id.Age)
            .ToList();
    }

    [Benchmark(Description = "HashSet: Contains check (100 IDs)")]
    public bool Collection_HashSetContains()
    {
        var testId = new EgyptianNationalId("30101010123458");
        return _hashSet.Contains(testId);
    }

    [Benchmark(Description = "Equality comparison (100 comparisons)")]
    public int Collection_EqualityCheck_100()
    {
        var testId = new EgyptianNationalId("30101010123458");
        int equalCount = 0;
        for (int i = 0; i < 100; i++)
        {
            if (_ids100[i] == testId)
                equalCount++;
        }
        return equalCount;
    }

    [Benchmark(Description = "Sort 100 IDs (IComparable)")]
    public void Collection_Sort_100()
    {
        var copy = new List<EgyptianNationalId>(_ids100);
        copy.Sort();
    }

    // Large dataset benchmarks (1000 IDs)
    [Benchmark(Description = "LINQ: Filter adults (1000 IDs)")]
    public List<EgyptianNationalId> LINQ_FilterAdults_1000()
    {
        return _ids1000.Where(id => id.IsAdult).ToList();
    }

    [Benchmark(Description = "LINQ: Group by region (1000 IDs)")]
    public Dictionary<Region, int> LINQ_GroupByRegion_1000()
    {
        return _ids1000
            .GroupBy(id => id.BirthRegion)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}