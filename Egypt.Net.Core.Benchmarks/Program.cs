using BenchmarkDotNet.Running;
using Egypt.Net.Core.Benchmarks.Benchmarks;

namespace Egypt.Net.Core.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        // Run all benchmarks
        if (args.Length == 0 || args[0] == "all")
        {
            BenchmarkRunner.Run<ParsingBenchmarks>();
            BenchmarkRunner.Run<ValidationBenchmarks>();
            BenchmarkRunner.Run<FormattingBenchmarks>();
            BenchmarkRunner.Run<PropertyAccessBenchmarks>();
            BenchmarkRunner.Run<CollectionBenchmarks>();
        }
        // Run specific benchmark
        else
        {
            switch (args[0].ToLower())
            {
                case "parsing":
                    BenchmarkRunner.Run<ParsingBenchmarks>();
                    break;
                case "validation":
                    BenchmarkRunner.Run<ValidationBenchmarks>();
                    break;
                case "formatting":
                    BenchmarkRunner.Run<FormattingBenchmarks>();
                    break;
                case "properties":
                    BenchmarkRunner.Run<PropertyAccessBenchmarks>();
                    break;
                case "collections":
                    BenchmarkRunner.Run<CollectionBenchmarks>();
                    break;
                default:
                    Console.WriteLine("Unknown benchmark. Options: parsing, validation, formatting, properties, collections, all");
                    break;
            }
        }
    }
}