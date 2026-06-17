using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexadorPalavras.Modelos
{
    public class ListaOcorrencias
    {
        public OcorrenciaNo Primeiro { get; set; }
        public int Quantidade { get; set; }

        public ListaOcorrencias()
        {
            Primeiro = null;
            Quantidade = 0;
        }

        public void Inserir( int linha, int coluna)
        {
            OcorrenciaNo novoNo = new OcorrenciaNo(linha, coluna);

            if (Primeiro == null)
            {
                Primeiro = novoNo;
            }
            else
            {
                OcorrenciaNo atual = Primeiro;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }
                atual.Proximo = novoNo;
            }
            Quantidade++;
        }
    }
}
