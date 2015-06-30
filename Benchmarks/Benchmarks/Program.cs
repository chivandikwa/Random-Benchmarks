using System;
using System.Linq;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        private static void BenchmarkArrayCopies()
        {
            long[] bufferRes = new long[10000];
            long[] arrayCopyRes = new long[10000];
            long[] manualCopyRes = new long[10000];

            double[] src = Enumerable.Range(0, 100000).Select(x => (double)x).ToArray();

            for (int i = 0; i < 10000; i++)
            {
                bufferRes[i] = ArrayCopyTests.ArrayBufferBlockCopy(src).Ticks;
            }

            for (int i = 0; i < 10000; i++)
            {
                arrayCopyRes[i] = ArrayCopyTests.ArrayCopy(src).Ticks;
            }

            for (int i = 0; i < 10000; i++)
            {
                manualCopyRes[i] = ArrayCopyTests.ArrayManualCopy(src).Ticks;
            }

            Console.WriteLine("Loop Copy: {0}", manualCopyRes.Average());
            Console.WriteLine("Array.Copy Copy: {0}", arrayCopyRes.Average());
            Console.WriteLine("Buffer.BlockCopy Copy: {0}", bufferRes.Average());

            //more accurate results - average last 1000

            Console.WriteLine();
            Console.WriteLine("----More accurate comparisons----");

            Console.WriteLine("Loop Copy: {0}", manualCopyRes.Where((l, i) => i > 9000).ToList().Average());
            Console.WriteLine("Array.Copy Copy: {0}", arrayCopyRes.Where((l, i) => i > 9000).ToList().Average());
            Console.WriteLine("Buffer.BlockCopy Copy: {0}", bufferRes.Where((l, i) => i > 9000).ToList().Average());
            Console.ReadLine();
        }
    }
}
