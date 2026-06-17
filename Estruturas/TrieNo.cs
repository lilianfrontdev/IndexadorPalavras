using IndexadorPalavras.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexadorPalavras.Estruturas
{
    public class TrieNo
    {
        public char Caracter { get; set; }
        public bool FimPalavra { get; set; }
        public TrieNo FilhoEsquerdo { get; set; }
        public TrieNo IrmaoDireito { get; set; }
        public ListaOcorrencias Ocorrencias { get; set; }

        public TrieNo(char caracter)
        {
            Caracter = caracter;
            FimPalavra = false;
            FilhoEsquerdo = null;
            IrmaoDireito = null;
            Ocorrencias = new ListaOcorrencias();
        }
    }
}
