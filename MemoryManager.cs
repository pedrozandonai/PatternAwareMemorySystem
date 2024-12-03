namespace PatternAwareMemorySystem
{
    public class MemoryManager
    {
        public long[] MainMemory { get; }
        public long[] FastMemory { get; }
        private readonly long[] _accessPattern;
        private readonly long _blockSize;
        private readonly int _cacheSize;
        private readonly LinkedList<int> _cacheHistory;
        private readonly Dictionary<int, int> _accessFrequency;

        public MemoryManager(long arraySize, long blockSize, int cacheSize)
        {
            MainMemory = new long[arraySize];
            FastMemory = new long[cacheSize * (int)blockSize]; // Cache limitado a um tamanho menor
            _blockSize = blockSize;
            _accessPattern = new long[arraySize / blockSize];
            _cacheSize = cacheSize;
            _cacheHistory = new LinkedList<int>(); // Mantém os blocos em ordem LRU
            _accessFrequency = new Dictionary<int, int>(); // Armazena a frequência de acesso a cada bloco
            InitializeMemory();
        }

        private void InitializeMemory()
        {
            var random = new Random();
            for (int i = 0; i < MainMemory.Length; i++)
            {
                MainMemory[i] = random.Next(0, 100);
            }
        }

        public void SimulateAccess(long iterations)
        {
            var random = new Random();
            for (long i = 0; i < iterations; i++)
            {
                int index = random.Next(MainMemory.Length);
                MainMemory[index]++;
                _accessPattern[index / _blockSize]++;

                int blockIndex = (int)(index / _blockSize);
                if (!_accessFrequency.ContainsKey(blockIndex))
                    _accessFrequency[blockIndex] = 0;
                _accessFrequency[blockIndex]++;
            }
        }

        public void DisplayAccessPattern()
        {
            for (int i = 0; i < _accessPattern.Length; i++)
            {
                Console.WriteLine($"Bloco {i:D2}: {_accessPattern[i]} acessos, Frequência: {_accessFrequency.GetValueOrDefault(i, 0)}");
            }
        }

        // Exibe os blocos que serão removidos da memória
        public void DisplayBlocksToBeRemoved()
        {
            foreach (var block in _cacheHistory)
            {
                Console.WriteLine($"Bloco {block} será removido.");
            }
        }

        public void OptimizeMemory(List<string> blockNames)
        {
            // Exemplo simples de otimização de memória
            foreach (var name in blockNames)
            {
                Console.WriteLine($"Movendo {name} para a Memória Rápida...");
                // Simula o movimento para a memória rápida
            }

            // Gerenciamento do cache
            while (_cacheHistory.Count >= _cacheSize)
            {
                int blockToRemove = _cacheHistory.Last!.Value;
                Console.WriteLine($"Removendo Bloco {blockToRemove} da Memória Rápida devido à falta de espaço.");
                _cacheHistory.RemoveLast();
            }

            // Simulação de otimização
            foreach (var block in blockNames)
            {
                _cacheHistory.AddFirst(int.Parse(block.Split('_')[2])); // Simula a adição do bloco ao cache
            }
        }

        public static long ComputeSum(long[] memory, bool isFastMemory)
        {
            long sum = 0;
            foreach (long value in memory)
            {
                if (!isFastMemory)
                {
                    sum += value * (value % 100); // Operação mais complexa para simulação
                }
                else
                {
                    sum += value;
                }
            }
            return sum;
        }
    }
}