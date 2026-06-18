using IndexadorPalavras.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexadorPalavras.Servicos
{
    public class VerificadorTexto
    {
        public int TotalLinhasProcessadas {get; set;}
        public int TotalPalavrasProcessadas { get; set; }

        public bool IndexarArquivo(string caminhoArquivo, ArvoreTrie arvore)
        {
            TotalLinhasProcessadas = 0;
            TotalPalavrasProcessadas = 0;

            if(string.IsNullOrEmpty(caminhoArquivo) || !File.Exists(caminhoArquivo))
            {
                System.Console.WriteLine("Arquivo não encontrado ou caminho inválido.");
                return false;
            }
            try
            {
                using(StreamReader leitor = new StreamReader(caminhoArquivo, Encoding.UTF8))
                {
                    string linha;
                    int numeroLinha = 1;

                    while((linha = leitor.ReadLine()) != null)
                    {
                        ProcessarLinha(linha, numeroLinha, arvore);
                        numeroLinha++;
                    }
                    TotalLinhasProcessadas = numeroLinha - 1;
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Erro ao processar o arquivo: {ex.Message}");
                return false;
            }
        }

        private void ProcessarLinha(string linha, int numeroLinha, ArvoreTrie arvore)
        {
            StringBuilder palavraAtual = new StringBuilder();
            int colunaInicial = 0;

            for(int i = 0; i < linha.Length; i++)
            {
                char caractere = linha[i];
                int colunaAtual = i + 1;

                if(char.IsLetterOrDigit(caractere))
                {
                    if(palavraAtual.Length == 0)
                    {
                        colunaInicial = colunaAtual;
                    }
                    palavraAtual.Append(caractere);
                }
                else
                {
                    FinalizarPalavraAtual(palavraAtual, numeroLinha, colunaInicial, arvore);
                }
            }
            FinalizarPalavraAtual(palavraAtual, numeroLinha, colunaInicial, arvore);
        }

        private void FinalizarPalavraAtual(StringBuilder atual, int linha, int coluna, ArvoreTrie arvore)
        {
            if (atual.Length > 0)
            {
                string palavraFinal = atual.ToString().ToLowerInvariant();
                arvore.Inserir(palavraFinal, linha, coluna);
                TotalPalavrasProcessadas++;
                atual.Clear();
            }
        }
    }
}
