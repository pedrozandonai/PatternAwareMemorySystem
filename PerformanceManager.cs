using System.Diagnostics;

namespace PatternAwareMemorySystem
{
    public class PerformanceManager
    {
        protected PerformanceManager()
        {
        }

        public static double MeasureExecutionTime(Func<long> operation, int iterations)
        {
            Console.WriteLine("Medição de tempo de execução em andamento...");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                operation();
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds / iterations;
        }

        public static async Task SaveExecutionTimes(string filename, List<string> times)
        {
            await File.AppendAllLinesAsync(filename, times);
        }
    }
}
