# Indexador de Palavras em C# - Árvore Trie

Este projeto consiste em um indexador de palavras desenvolvido em **C# (.NET 8)**. O sistema realiza a leitura de arquivos de texto (`.txt`), tokeniza as palavras de acordo com regras predefinidas e constrói um índice invertido em memória utilizando a estrutura de **Árvore Trie** com abordagem *Filho-Irmão* e **Listas Encadeadas Manuais de Ocorrências**.

O projeto foi desenvolvido para fins acadêmicos, não utilizando coleções nativas do .NET, como `List<T>`, `Dictionary<>`, `HashSet<T>` ou `LinkedList<T>`).

---

## 🚀 Como Executar o Projeto

Certifique-se de ter o **SDK do .NET 8 ou superior** instalado em sua máquina.

1. Clone este repositório.
2. Abra o terminal na pasta raiz do projeto (onde está o arquivo `IndexadorPalavras.sln`).
3. Execute o comando abaixo para compilar e rodar a aplicação:

```bash
dotnet run
```

4. Quando solicitado, informe o caminho do arquivo `.txt` que deseja indexar. Você pode usar os arquivos de exemplo incluídos no projeto:

```
amostra.txt
amostra_maior.txt
```

---

## 🗂️ Estrutura do Projeto

```
IndexadorPalavras/
├── Estruturas/
│   ├── ArvoreTrie.cs
│   └── TrieNo.cs
├── Modelos/
│   ├── ListaOcorrencias.cs
│   └── OcorrenciaNo.cs
├── Servicos/
│   └── VerificadorTexto.cs
├── Program.cs
├── amostra.txt
├── amostra_maior.txt
└── README.md
```

---

## 📦 Descrição das Classes

### `Estruturas/TrieNo.cs`
Representa um **nó da Árvore Trie** com abordagem *Filho-Irmão*. Cada nó armazena:
- O caractere que representa naquele nível da árvore.
- Referência para o **primeiro filho** (próximo caractere na sequência).
- Referência para o **próximo irmão** (próximo caractere alternativo no mesmo nível).
- Uma instância de `ListaOcorrencias`, preenchida quando o nó marca o fim de uma palavra indexada.

### `Estruturas/ArvoreTrie.cs`
Implementa a **Árvore Trie**. É responsável por:
- Inserir palavras na estrutura, criando ou navegando pelos nós existentes.
- Registrar cada ocorrência (número da linha) na lista encadeada do nó correspondente ao fim da palavra.
- Buscar uma palavra na Trie e retornar suas ocorrências.
- Percorrer toda a árvore para listar o índice completo em ordem alfabética.

### `Modelos/OcorrenciaNo.cs`
Representa um **nó da lista encadeada de ocorrências**. Armazena:
- O número da linha onde a palavra foi encontrada.
- Referência para o próximo nó da lista.

### `Modelos/ListaOcorrencias.cs`
Implementa a **lista encadeada de ocorrências** associada a cada palavra indexada. É responsável por:
- Inserir novos números de linha sem duplicatas.
- Percorrer e exibir todas as linhas onde a palavra aparece.

### `Servicos/VerificadorTexto.cs`
Responsável pela **leitura e tokenização** do arquivo de texto. Realiza:
- Leitura linha a linha do arquivo `.txt` informado.
- Extração dos tokens com base nas regras de separação definidas.
- Normalização dos tokens (conversão para letras minúsculas).
- Envio de cada token e seu número de linha para ser inserido na `ArvoreTrie`.

### `Program.cs`
Ponto de entrada da aplicação. Coordena o fluxo principal:
- Solicita ao usuário o caminho do arquivo a ser indexado.
- Instancia a `ArvoreTrie` e o `VerificadorTexto`.
- Dispara a indexação e, em seguida, apresenta o menu interativo de consulta ao índice.

---

## 🧪 Instruções de Teste

A validação é feita de forma **manual e interativa** pelo terminal.

### Passo a passo para testar

1. Execute a aplicação com `dotnet run`.

2. Informe o caminho de um dos arquivos de exemplo quando solicitado:

```
Digite o caminho do arquivo: amostra.txt
```

> Use `amostra_maior.txt` para um teste com volume maior de dados.

3. Após a indexação, utilize o menu interativo para:
   - **Buscar uma palavra** — o programa exibirá as linhas onde ela ocorre.
   - **Listar o índice completo** — exibe todas as palavras indexadas em ordem alfabética com suas respectivas ocorrências.
   - **Encerrar** a aplicação.

### Casos de teste sugeridos

| Cenário | O que verificar |
|---|---|
| Palavra presente no arquivo | Linhas de ocorrência exibidas corretamente |
| Palavra ausente no arquivo | Mensagem de "não encontrada" |
| Palavra com variações de maiúsculas/minúsculas | Deve ser tratada como a mesma entrada |
| Palavra com pontuação adjacente (`fim.`, `fim,`) | Deve ser tokenizada como `fim` |
| Listagem completa do índice | Palavras em ordem alfabética com todas as linhas |

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET 8
- **Estruturas de dados:** Implementadas manualmente Trie com Filho-Irmão, Lista Encadeada

---

## 📄 Observações Acadêmicas

Este projeto foi desenvolvido com a restrição explícita de **não utilizar coleções do namespace `System.Collections.Generic`**, como `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>` ou `LinkedList<T>`. Todas as estruturas de dados foram implementadas do zero para fins de aprendizado sobre gerenciamento de memória e estruturas fundamentais da computação.