using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations;

public class AvoidFinalizersOperations
{
        class Simple
        {
          public int X { get; set; }
        }
        class SimpleWithFinalizer
        {
            ~SimpleWithFinalizer()
            {
            }
            public int X { get; set; }
        }
        private int ITEMS = 100000;
        private static Simple _instance1;
        private static SimpleWithFinalizer _instance2;
        [Benchmark]
        public void AllocateSimple()
        {
            for (int i = 0; i < ITEMS; i++)
            {
                _instance1 = new Simple();
            }
        }
        [Benchmark]
        public void AllocateSimpleWithFinalizer()
        {
            for (int i = 0; i < ITEMS; i++)
            {
                _instance2 = new SimpleWithFinalizer();
            }
        }
}