# Egypt.Net.Core.Benchmarks

Performance benchmarking suite for Egypt.Net.Core using BenchmarkDotNet.

---

## 🎯 Purpose

This project measures and tracks the performance characteristics of Egypt.Net.Core to:
- Establish performance baselines
- Identify optimization opportunities
- Prevent performance regressions
- Validate optimization efforts

---

## 🚀 Running Benchmarks

### Run All Benchmarks
```bash
cd Egypt.Net.Core.Benchmarks
dotnet run -c Release
```

### Run Specific Benchmark Category
```bash
dotnet run -c Release -- parsing
dotnet run -c Release -- validation
dotnet run -c Release -- formatting
dotnet run -c Release -- properties
dotnet run -c Release -- collections
```

### Run with Filters
```bash
# Run only parsing benchmarks
dotnet run -c Release --filter *Parsing*

# Run only validation benchmarks
dotnet run -c Release --filter *Validation*
```

---

## 📊 Benchmark Categories

### 1. ParsingBenchmarks
Measures the performance of creating `EgyptianNationalId` instances:
- Constructor creation
- TryCreate methods
- String extension methods
- Bulk parsing (10, 100 IDs)
- Invalid input handling

### 2. ValidationBenchmarks
Measures validation operation performance:
- Full validation (IsValid)
- Format-only validation
- Checksum validation
- Bulk validation (100, 1000 IDs)
- Invalid input detection

### 3. FormattingBenchmarks
Measures string formatting performance:
- ToString()
- FormatWithDashes()
- FormatWithSpaces()
- FormatWithBrackets()
- FormatMasked()
- FormatDetailed()
- Bulk formatting operations

### 4. PropertyAccessBenchmarks
Measures property access performance:
- Birth date properties
- Gender properties
- Governorate properties
- Region properties
- Generation properties
- Multiple property access patterns

### 5. CollectionBenchmarks
Measures collection operation performance:
- List operations
- HashSet operations
- LINQ queries (Where, GroupBy, OrderBy)
- Equality checks
- Sorting (IComparable)
- Large dataset operations (1000 IDs)

---

## 📈 Understanding Results

### Memory Diagnoser Output
```
|           Method |     Mean | Allocated |
|----------------- |---------:|----------:|
| ParseValid       | 2.130 μs |   2,777 B |
```

- **Mean**: Average execution time
- **Allocated**: Memory allocated per operation
- **μs**: Microseconds (1 μs = 0.001 ms)
- **ns**: Nanoseconds (1 ns = 0.001 μs)

### Statistical Metrics
- **StdErr**: Standard error of the mean
- **StdDev**: Standard deviation
- **Median**: Middle value
- **IQR**: Interquartile range (Q3 - Q1)
- **CI**: Confidence interval (99.9%)

---

## 📁 Results Location

Benchmark results are saved in:
```
Egypt.Net.Core.Benchmarks/BenchmarkDotNet.Artifacts/results/
```

Results include:
- `*-report.html` - HTML report with charts
- `*-report.csv` - CSV data for analysis
- `*-report.md` - Markdown summary

---

## 🔬 Baseline Measurements (v1.1.0)

### Parsing Performance (Actual Results)
| Metric | Value |
|--------|-------|
| **Mean** | 2.130 μs |
| **StdDev** | 0.032 μs |
| **Median** | 2.122 μs |
| **Min** | 2.092 μs |
| **Max** | 2.213 μs |
| **Allocated** | ~2,777 B per operation |
| **GC Collections** | 232 Gen0 per 262K ops |

#### Statistical Summary:
```
Mean = 2.130 μs, StdErr = 0.009 μs (0.42%)
N = 13, StdDev = 0.032 μs
Min = 2.092 μs, Q1 = 2.110 μs, Median = 2.122 μs
Q3 = 2.143 μs, Max = 2.213 μs
IQR = 0.032 μs
ConfidenceInterval = [2.092 us; 2.169 us] (CI 99.9%)
Margin = 0.039 μs (1.82% of Mean)
```

#### What This Means:
- **Very consistent performance** (low StdDev of 0.032 μs)
- **Predictable behavior** (narrow confidence interval)
- **~2.7 KB allocation per parse** needs optimization
- **High GC pressure** (232 Gen0 collections) - target for v1.2.0

### Memory Analysis
```
Total Operations: 262,144
Total Allocated: 727,827,312 B (~694 MB)
Per Operation: ~2,777 B (~2.7 KB)
GC Gen0: 232 collections
GC Gen1: 0 collections
GC Gen2: 0 collections
```

---

## 🎯 Optimization Targets (v1.2.0)

### Phase 1: Span<T> Migration
- [ ] Convert parsing to ReadOnlySpan<char>
- [ ] Convert validation to ReadOnlySpan<char>
- [ ] Convert formatting to use String.Create()
- **Target**: 50% reduction in allocations (~1,400 B per op)

### Phase 2: Caching
- [ ] Cache parsed birth date
- [ ] Cache governorate lookups
- [ ] Lazy initialization for properties
- **Target**: 30% faster property access

### Phase 3: Pooling
- [ ] ArrayPool for temporary buffers
- [ ] StringBuilder pooling
- **Target**: 80% reduction in GC pressure (~46 Gen0 collections)

### Expected v1.2.0 Performance:
| Metric | v1.1.0 Baseline | v1.2.0 Target | Improvement |
|--------|----------------|---------------|-------------|
| Mean | 2.130 μs | ~1.065 μs | **50% faster** |
| Allocated | 2,777 B | ~555 B | **80% less** |
| GC Gen0 | 232 | ~46 | **80% less** |

---

## 📝 Adding New Benchmarks

1. Create a new class in `Benchmarks/` folder
2. Add `[MemoryDiagnoser]` and `[SimpleJob]` attributes
3. Mark one benchmark as `[Baseline = true]`
4. Add descriptive `Description` to each benchmark
5. Update `Program.cs` to include the new benchmark

Example:
```csharp
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[RankColumn]
public class MyBenchmarks
{
    [Benchmark(Baseline = true, Description = "My baseline")]
    public void MyBaseline() { }
    
    [Benchmark(Description = "My optimization")]
    public void MyOptimization() { }
}
```

---

## 🤝 Contributing

When submitting performance optimizations:
1. Run benchmarks before optimization
2. Implement optimization
3. Run benchmarks after optimization
4. Include before/after results in PR
5. Ensure all tests still pass

### Example PR Description:
```markdown
## Performance Improvement

**Before:**
- Mean: 2.130 μs
- Allocated: 2,777 B

**After:**
- Mean: 1.065 μs (50% faster ✅)
- Allocated: 555 B (80% less ✅)
```

---

## 📚 Resources

- [BenchmarkDotNet Documentation](https://benchmarkdotnet.org/)
- [Performance Best Practices in .NET](https://docs.microsoft.com/en-us/dotnet/standard/performance/)
- [Span<T> and Memory<T> Guide](https://docs.microsoft.com/en-us/dotnet/standard/memory-and-spans/)
- [Writing High-Performance .NET Code](https://www.writinghighperf.net/)

---

## 📊 Performance History

### v1.1.0 (Current Baseline)
- Parsing: 2.130 μs, 2,777 B allocated
- GC: 232 Gen0 per 262K ops
- **Status**: Baseline established ✅

### v1.2.0 (Target)
- Parsing: ~1.065 μs (50% faster)
- Allocated: ~555 B (80% less)
- GC: ~46 Gen0 per 262K ops (80% less)
- **Status**: In progress 🔄

---

Made with ❤️ for performance optimization