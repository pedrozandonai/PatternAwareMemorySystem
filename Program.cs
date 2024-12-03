namespace PatternAwareMemorySystem
{
    public static class Program
    {
        public static async Task Main()
        {
            // Constantes
            const long arraySize = 10_000_000;
            const long blockSize = 1_000_000;
            const long accessIterations = arraySize * 100;
            const int timeMeasurementIterations = 10;
            const int cacheSize = 10;
            const int numTests = 5;
            const bool executeOnAzure = false;

            if (executeOnAzure)
            {

            }
            else
            {
                await Tests.RunTests(
                    arraySize,
                    blockSize,
                    accessIterations,
                    timeMeasurementIterations,
                    cacheSize,
                    numTests
                );
            }
        }
    }
}