using System.Diagnostics;

namespace PatternAwareMemorySystem
{
    public static class Tests
    {
        public static async Task RunTests(long arraySize, long blockSize, long accessIterations, int timeMeasurementIterations, int cacheSize, int numTests)
        {
            var elapsedAllTestsTime = new Stopwatch();
            elapsedAllTestsTime.Start();

            Console.WriteLine("Iniciando o sistema de memória consciente de padrões...");

            var memorySystem = new MemoryManager(arraySize, blockSize, cacheSize);

            List<string> executionTimes = [];
            List<double> timesWithoutOptimization = [];
            List<double> timesWithOptimization = [];

            foreach (var i in Enumerable.Range(0, numTests))
            {
                // Criar um arquivo para cada teste
                string testFileName = $"teste_{i + 1}_output.txt";

                using var testWriter = new StreamWriter(testFileName);

                // Redirecionar o Console para o arquivo
                Console.SetOut(testWriter);

                var elapsedTestTime = new Stopwatch();
                elapsedTestTime.Start();

                Console.WriteLine("Iniciando o Teste...");

                // Gerar novos nomes para os blocos (em vez de 0-9)
                var blockNames = GenerateBlockNames(i);

                Console.WriteLine("\n=== Fase 1: Simulação de Acessos ===");
                await Task.Run(() => memorySystem.SimulateAccess(accessIterations));

                Console.WriteLine("\n=== Fase 2: Exibição de Padrões de Acesso ===");
                memorySystem.DisplayAccessPattern();

                Console.WriteLine("\n=== Fase 3: Medição de Tempo Sem Otimização ===");
                double timeWithoutOptimization = PerformanceManager.MeasureExecutionTime(
                    () => MemoryManager.ComputeSum(memorySystem.MainMemory, false),
                    timeMeasurementIterations
                );
                timesWithoutOptimization.Add(timeWithoutOptimization);
                executionTimes.Add($"Teste {i + 1} - Tempo médio de execução sem otimização: {timeWithoutOptimization:F6} segundos"); // Adicionando a string ao array

                Console.WriteLine("\n=== Fase 4: Otimização de Memória ===");

                // Exibir blocos removidos antes de mover os novos
                Console.WriteLine("\nBlocos que serão removidos para dar espaço a novos blocos:");
                memorySystem.DisplayBlocksToBeRemoved();

                await Task.Run(() => memorySystem.OptimizeMemory(blockNames)); // Passar os novos nomes para otimizar a memória

                Console.WriteLine("\n=== Fase 5: Medição de Tempo Com Otimização ===");
                double timeWithOptimization = PerformanceManager.MeasureExecutionTime(
                    () => MemoryManager.ComputeSum(memorySystem.FastMemory, true),
                    timeMeasurementIterations
                );
                timesWithOptimization.Add(timeWithOptimization);
                executionTimes.Add($"Teste {i + 1} - Tempo médio de execução com otimização: {timeWithOptimization:F6} segundos");

                elapsedTestTime.Stop();

                // Tempo total de execução do teste
                double totalTestTime = elapsedTestTime.Elapsed.TotalSeconds;
                Console.WriteLine($"Teste {i + 1} concluído em {totalTestTime:F6} segundos.");

                // Salvar os tempos de execução do teste no arquivo
                executionTimes.Add($"Teste {i + 1} - Tempo total do teste: {totalTestTime:F6} segundos."); 
                Console.WriteLine("\nTestes concluídos. Arquivo gerado com sucesso.");

                // Garantir que os dados sejam gravados no arquivo
                await testWriter.FlushAsync();

                // Restaurar a saída do Console após o teste
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            }

            // Salvar os tempos de execução em arquivos
            elapsedAllTestsTime.Stop();
            executionTimes.Add($"Tempo total de execução: {elapsedAllTestsTime.Elapsed.TotalSeconds:F6} segundos.");

            await WriteFinalOutputAsync(executionTimes);

            Console.WriteLine("\nProcesso concluído com sucesso!");
        }

        // Gerar novos nomes para os blocos com base no número do teste
        private static List<string> GenerateBlockNames(int testNumber)
        {
            var names = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                names.Add($"Block_{testNumber}_{i}");
            }
            return names;
        }

        private static async Task WriteFinalOutputAsync(List<string> executionTimes)
        {
            using var writer = new StreamWriter("execution_times.txt");

            foreach(var executionTime in executionTimes)
                await writer.WriteLineAsync(executionTime);
            
            await writer.FlushAsync();

            writer.Close();
        }
    }
}