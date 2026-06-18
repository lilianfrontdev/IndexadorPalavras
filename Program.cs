using IndexadorPalavras.Estruturas;
using IndexadorPalavras.Servicos;
using System;
using IndexadorPalavras.Modelos;

namespace IndexadorPalavras.Console
{
    class Program
    {
        private static ArvoreTrie _arvore = new ArvoreTrie();
        private static VerificadorTexto _verificador = new VerificadorTexto();
        private static bool _arquivoIndexado = false;
        static void Main(string[] args)
        {
            bool executar = true;
            while (executar)
            {
                ExibirCabecalho("MENU PRINCIPAL");
                System.Console.WriteLine("1 - Indexar Arquivo Texto");
                System.Console.WriteLine("2 - Buscar Palavra no Índice");
                System.Console.WriteLine("3 - Sair");
                System.Console.Write("\nEscolha uma opção: ");

                string opcao = System.Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        IndexarArquivo();
                        break;
                    case "2":
                        BuscarPalavra();
                        break;
                    case "3":
                        executar = false;
                        System.Console.WriteLine("Encerrando o programa. Obrigado por usar o Indexador de Palavras!");
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        PausarTela();
                        break;
                }
            }
        }

        private static void IndexarArquivo()
        {
            ExibirCabecalho("Indexação de Arquivo");
            System.Console.Write("Informe o caminho do arquivo texto a ser indexado: ");
            string caminhoArquivo = System.Console.ReadLine();

            ArvoreTrie novaArvore = new ArvoreTrie();
            System.Console.WriteLine("Processando o arquivo, por favor aguarde...");

            bool sucesso = _verificador.IndexarArquivo(caminhoArquivo, novaArvore);

            if (sucesso)
            {
                _arvore = novaArvore;
                _arquivoIndexado = true;

                System.Console.WriteLine("\n --- Resumo da Indexação ---");
                System.Console.WriteLine($"Total de Linhas Processadas: {_verificador.TotalLinhasProcessadas}");
                System.Console.WriteLine($"Total de Palavras Processadas: {_verificador.TotalPalavrasProcessadas}");
                System.Console.WriteLine($"Total de Palavras Diferentes Indexadas: {_arvore.TotalPalavrasDiferentes}");
            }
            PausarTela();
        }

        private static void BuscarPalavra()
        {
            ExibirCabecalho("Busca de Palavra");

            if (!_arquivoIndexado)
            {
                System.Console.WriteLine("Nenhum arquivo foi indexado ainda. Por favor, indexe um arquivo antes de realizar buscas.");
                PausarTela();
                return;
            }
            System.Console.Write("Digite a palavra que deseja buscar: ");
            string termo = System.Console.ReadLine();

            ListaOcorrencias ocorrencias = _arvore.Buscar(termo);

            if (ocorrencias == null || ocorrencias.Quantidade == 0)
            {
                System.Console.WriteLine($"A palavra '{termo}' não foi encontrada no índice.");
            }
            else
            {
                System.Console.WriteLine($"A palavra '{termo}' foi encontrada {ocorrencias.Quantidade} vezes.");
                System.Console.WriteLine("{0,-10} {1,-10}", "Linha", "Coluna");
                System.Console.WriteLine("---------------------");

                OcorrenciaNo atual = ocorrencias.Primeiro;
                while (atual != null)
                {
                    System.Console.WriteLine("{0,-10} {1,-10}", atual.Linha, atual.Coluna);
                    atual = atual.Proximo;
                }
            }
            PausarTela();
        }
        private static void ExibirCabecalho(string titulo)
        {
            System.Console.Clear();
            System.Console.WriteLine($"========================================");
            System.Console.WriteLine($"=== {titulo} ===");
            System.Console.WriteLine($"========================================\n");
        }

        private static void PausarTela()
        {
            System.Console.WriteLine("\nPressione qualquer tecla para continuar...");
            System.Console.ReadKey();
        }
    }
}