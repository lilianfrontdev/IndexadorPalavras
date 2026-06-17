using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexadorPalavras.Modelos
{
    public class OcorrenciaNo
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public OcorrenciaNo Proximo { get; set; }

        public OcorrenciaNo(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Proximo = null;
        }
    }
}
