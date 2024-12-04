# Pattern Aware Memory System (PAMS)

## Índice

- [Introdução](#introdução)
- [Motivação](#motivação)
- [Funcionalidades](#funcionalidades)
- [Estrutura do Projeto](#estrutura-do-projeto)
  - [Testes](#testes)
- [Como Executar](#como-executar)
  - [Pré-requisitos](#pré-requisitos)
  - [Passos](#passos)
- [Uso](#uso)
  - [Configuração dos Parâmetros](#configuração-dos-parâmetros)
- [Arquitetura](#arquitetura)
  - [Componentes](#componentes)
  - [Fluxo de Execução](#fluxo-de-execução)
- [Resultados Esperados](#resultados-esperados)
- [Como Contribuir](#como-contribuir)
- [Referências](#referências)

## Introdução

Este projeto implementa o **Pattern Aware Memory System (PAMS)**, um sistema de gerenciamento de memória inspirado por um artigo científico sobre gerenciamento de memória em computadores de alto desempenho (HPC). O PAMS otimiza padrões de acesso à memória e gerencia a movimentação de dados entre memória principal e memória de acesso rápido (scratchpad) para melhorar o desempenho.

## Motivação

A gestão eficiente de memória é crítica para aplicações que demandam alto desempenho. O **PAMS** analisa padrões de acesso à memória durante a execução para otimizar a alocação de dados em diferentes níveis da hierarquia de memória.

O projeto explora conceitos de gerenciamento de memória inspirados em sistemas de alto desempenho, utilizando padrões de acesso simulados para otimizar a movimentação de blocos de dados entre memória principal e memória rápida. Embora inspirado em conceitos como o **Sharing-Aware Memory Management Unit (SAMMU)**, o foco é em simulações baseadas em software para identificar e otimizar acessos frequentes.

## Funcionalidades

- **Simulação de acessos à memória:** Gera padrões de acesso baseados em simulações de leitura e escrita.
- **Exibição de padrões de acesso:** Analisa a frequência de acesso a blocos de memória.
- **Otimização de memória:** Movimenta blocos de dados para a memória rápida baseada em padrões de acesso identificados.
- **Medição de desempenho:** Mede o tempo de execução antes e depois da otimização.
- **Gerenciamento de cache:** Implementa um esquema básico de substituição de blocos baseado no conceito de LRU (Least Recently Used).

## Estrutura do Projeto

### Código

- **Namespace:** `PatternAwareMemorySystem`
- **Principais classes:**
  - `MemoryManager`: Gerencia a memória principal, memória rápida e padrões de acesso.
  - `PerformanceManager`: Mede o desempenho do sistema antes e depois da otimização.
  - `Tests`: Controla os testes e a geração de relatórios de resultados.

### Testes

A pasta `Testes` dentro do projeto contém exemplos de saídas geradas durante a execução do programa. Esses arquivos incluem:

- **Relatórios de desempenho:** Detalham os tempos médios de execução antes e depois da otimização.
- **Frequência de acesso à memória:** Apresentam os padrões identificados durante as simulações.
- **Blocos otimizados:** Descrevem os blocos de memória movidos para a memória rápida.

Esses arquivos servem como referência para entender os resultados e validar o funcionamento do sistema.

## Como Executar

### Pré-requisitos

- .NET SDK 8.0 ou superior instalado.
- Editor de código ou IDE compatível (Visual Studio, VS Code, etc.).

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/pedrozandonai/PatternAwareMemorySystem.git
   ```
2. Acesse o diretório do projeto:
   ```bash
   cd PatternAwareMemorySystem
   ```
3. Compile o projeto:
   ```bash
   dotnet build
   ```
4. Execute o programa:
   ```bash
   dotnet run
   ```

## Uso

O programa realiza uma série de testes configurados para simular padrões de acesso à memória. Os resultados incluem:

- Tempos de execução com e sem otimização.
- Relatórios salvos em arquivos gerados durante a execução.

### Configuração dos Parâmetros

Os parâmetros principais do sistema podem ser configurados no método `Main`:

- `arraySize`: Define o tamanho total da memória principal simulada. Este parâmetro controla quantos elementos podem ser armazenados na memória principal e influencia diretamente o desempenho e a capacidade de gerenciamento do sistema.

- `blockSize`: Determina o tamanho dos blocos de memória usados na simulação. Blocos maiores podem aumentar a eficiência do acesso em padrões sequenciais, mas podem desperdiçar memória em padrões de acesso aleatório.

- `accessIterations`: Especifica o número total de iterações de acesso à memória simuladas. Esse parâmetro define a intensidade da carga de trabalho e é proporcional ao número de elementos no array (arraySize).

- `timeMeasurementIterations`: Indica o número de vezes que as operações de medição de tempo devem ser repetidas. Isso permite calcular uma média precisa para avaliar o desempenho do sistema de maneira confiável.

- `cacheSize`: Representa o número de blocos que podem ser armazenados na memória rápida (cache). Esse valor afeta diretamente o desempenho do sistema, pois um cache maior pode reduzir a latência de acesso.

- `numTests`: Define o número de testes completos que serão executados. Esse parâmetro é útil para validar a consistência dos resultados ao executar múltiplos ciclos de teste.

Esses parâmetros podem ser ajustados para simular diferentes cenários de uso e avaliar o comportamento do sistema em situações variadas.

## Arquitetura

### Componenetes

1. `MemoryManager`
   - Simula operações de leitura e escrita.
   - Exibe padrões de acesso e gerencia a memória rápida.
2. `PerformanceManager`
   - Mede tempos médios de execução para análise de impacto.
3. `Tests`
   - Coordena os testes e gera arquivos de saída detalhados.

### Fluxo de Execução

1. Simulação de acessos à memória.
2. Análise de padrões de acesso.
3. Otimização dos blocos mais utilizados.
4. Medição de desempenho antes e depois da otimização.

## Resultados Esperados

Os testes geram relatórios contendo:

- Tempos de execução médios antes e depois da otimização.
- Frequência de acesso por bloco.
- Blocos otimizados e removidos durante a execução.

Os relatórios são salvos em arquivos .txt para análise posterior.

## Resultados de Desempenho

Abaixo estão os gráficos comparando os tempos de execução com e sem otimização, realizados em computadores com diferentes configurações de hardware, ordenados do mais poderoso (Teste 1) ao menos potente (Teste 4):

### Teste 1
![1](https://github.com/user-attachments/assets/6b46a3af-8270-423a-8fa4-2dc972bdb779)

### Teste 2
![2](https://github.com/user-attachments/assets/518c7b52-213b-4a8a-96a3-06e76d2bcc4e)

### Teste 3
![3](https://github.com/user-attachments/assets/b1f666d7-ec82-4ef0-b780-d3d5b9470bb4)

### Teste 4
![4](https://github.com/user-attachments/assets/f588daf4-7fa9-4623-a6eb-af4b9545bfa9)

## Como Contribuir

Contribuições são bem-vindas! Siga os passos abaixo para colaborar com o desenvolvimento do **Pattern Aware Memory System (PAMS)**:

1. **Faça um Fork do repositório**:

   - Clique em `Fork` no canto superior direito da página para criar uma cópia do repositório no seu perfil.

2. **Clone o repositório Fork**:

   - Clone o repositório no seu ambiente local usando o comando:
     ```bash
     git clone https://github.com/seu-usuario/PatternAwareMemorySystem.git
     ```

3. **Crie uma nova branch**:

   - Baseie sua branch na `develop`:
     ```bash
     git checkout develop
     git pull origin develop
     git checkout -b feature/nova-feature
     ```

4. **Implemente suas alterações**:

   - Faça suas modificações seguindo as boas práticas de codificação e o guia de estilo do projeto.
   - Teste suas mudanças localmente para garantir que funcionem como esperado.

5. **Commit e Push**:

   - Realize commits claros e informativos:
     ```bash
     git add .
     git commit -m "Descrição clara da mudança"
     git push origin feature/nova-feature
     ```

6. **Abra um Pull Request**:

   - No GitHub, navegue até o seu repositório Fork.
   - Clique em `Compare & pull request` para abrir um Pull Request com base na branch `develop`.
   - Descreva as mudanças realizadas, inclua detalhes do impacto e adicione evidências (como screenshots ou logs, se aplicável).

7. **Aguarde Revisão**:

   - Um revisor analisará o seu Pull Request. Esteja disponível para responder a comentários e ajustar o código, se necessário.

8. **Após Aprovação**:
   - O Pull Request será mesclado à branch `develop`.

## Referências

PUPYKINA, A.; AGOSTA, G. Survey of memory management techniques for HPC and cloud computing. IEEE access: practical innovations, open solutions, v. 7, p. 167351–167373, 2019.

Disponível em: <https://ieeexplore.ieee.org/stamp/stamp.jsp?tp=&arnumber=8906102>. Acesso em: 4 dez. 2024.
