using System.ComponentModel;
using BenchmarkDotNet.Running;
using SpanUsageExample.Operations;

namespace SpanUsageExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Reducing GC stress");

        var loop = true;
        while (loop)
        {
            Console.WriteLine("To view the benchmark results of operations, enter the heading number in the repository's readme file (To exit, press 8): ");
            var type = Convert.ToInt32(Console.ReadLine());
       
            switch ((OperationType)type)
            {
                case OperationType.InitialCapacityForDynamicCollections:
                    BenchmarkRunner.Run<StringInterningOperations>();
                    break;
                case OperationType.UseArrayPool:
                    BenchmarkRunner.Run<ArrayPoolOperations>();
                    break;
                case OperationType.StructsVsClass:
                    BenchmarkRunner.Run<StructClassComparisonOperations>();
                    break;
                case OperationType.SuppressFinalizers:
                    BenchmarkRunner.Run<AvoidFinalizersOperations>();
                    break;
                case OperationType.StackAllocUsage:
                    BenchmarkRunner.Run<StackAllocUsageOperations>();
                    break;
                case OperationType.StringBuilderUsage:
                    BenchmarkRunner.Run<StringBuilderOperations>();
                    break;
                case OperationType.StringInterning:
                    BenchmarkRunner.Run<StringInterningOperations>();
                    break;
                case OperationType.Exit:
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Please enter supported key!");
                    break;
            }
        }
        
    }
    enum OperationType
    {
           InitialCapacityForDynamicCollections = 1,
           UseArrayPool,
           StructsVsClass,
           SuppressFinalizers,
           StackAllocUsage,
           StringBuilderUsage,
           StringInterning,
           Exit
    }
}

