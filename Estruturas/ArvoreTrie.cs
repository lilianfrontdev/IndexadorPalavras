using IndexadorPalavras.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexadorPalavras.Estruturas
{
    public class ArvoreTrie
    {
        private readonly TrieNo _raiz;
        public int TotalPalavrasDiferentes { get; private set; }

        public ArvoreTrie()
        {
            _raiz = new TrieNo('0');
            TotalPalavrasDiferentes = 0;
        }

        public void Inserir(string palavra, int linha, int coluna)
        {
            if (string.IsNullOrEmpty(palavra))
                return;

            TrieNo atual = _raiz;

            foreach (char letra in palavra)
            {
                atual = ObterOuCriarFilho(atual, letra);
            }

            if ((!atual.FimPalavra))
            {
                atual.FimPalavra = true;
                TotalPalavrasDiferentes++;
            }
            atual.Ocorrencias.Inserir(linha, coluna);
        }

        public ListaOcorrencias Buscar(string palavra)
        {
            if (string.IsNullOrEmpty(palavra))
                return null;

            TrieNo atual = _raiz;

            foreach (char letra in palavra)
            {
                atual = EncontrarFilho(atual, letra);
                if (atual == null)
                    return null;
            }
            return atual.FimPalavra ? atual.Ocorrencias : null;
        }

        private TrieNo ObterOuCriarFilho(TrieNo pai, char letra)
        {
            if (pai.FilhoEsquerdo == null)
            {
                pai.FilhoEsquerdo = new TrieNo(letra);
                return pai.FilhoEsquerdo;
            }
            TrieNo atualFilho = pai.FilhoEsquerdo;
            TrieNo ultimoIrmao = null;

            while (atualFilho != null)
            {
                if (atualFilho.Caracter == letra)
                {
                    return atualFilho;
                }
                ultimoIrmao = atualFilho;
                atualFilho = atualFilho.IrmaoDireito;
            }
            TrieNo novoIrmao = new TrieNo(letra);
            ultimoIrmao.IrmaoDireito = novoIrmao;
            return novoIrmao;
        }

        private TrieNo EncontrarFilho(TrieNo pai, char letra)
        {
            TrieNo atualFilho = pai.FilhoEsquerdo;

            while (atualFilho != null)
            {
                if (atualFilho.Caracter == letra)
                    return atualFilho;
                atualFilho = atualFilho.IrmaoDireito;
            }
            return null;
        }
    }
}

