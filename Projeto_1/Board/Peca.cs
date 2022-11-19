using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_1.Board
{
    class Peca
    {
        public Posicao Posicao{ get; set; }
        public Cor Cor { get; protected set; }
        public int Movimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.Posicao = null;
            this.Cor = cor;
            this.Tab = tab;
            Movimentos = 0;
        }
    }
}
