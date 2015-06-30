using System;
using System.Diagnostics;

namespace Benchmarks
{
    public class ArrayCopyTests
    {
        private const int byteSize = sizeof(double);

        public static TimeSpan ArrayBufferBlockCopy(double[] original)
        {
            Stopwatch watch = new Stopwatch();
            double[] copy = new double[original.Length];
            watch.Start();
            Buffer.BlockCopy(original, 0 * byteSize, copy, 0 * byteSize, original.Length * byteSize);
            watch.Stop();
            return watch.Elapsed;
        }

        public static TimeSpan ArrayCopy(double[] original)
        {
            Stopwatch watch = new Stopwatch();
            double[] copy = new double[original.Length];
            watch.Start();
            Array.Copy(original, 0, copy, 0, original.Length);
            watch.Stop();
            return watch.Elapsed;
        }

        public static TimeSpan ArrayManualCopy(double[] original)
        {
            Stopwatch watch = new Stopwatch();
            double[] copy = new double[original.Length];
            watch.Start();
            for (int i = 0; i < original.Length; i++)
            {
                copy[i] = original[i];
            }
            watch.Stop();
            return watch.Elapsed;
        }
    }
    
}