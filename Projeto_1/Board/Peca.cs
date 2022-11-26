using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_1.Board
{
    abstract class Peca
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

        public void IncrementarMovimento()
        {
            Movimentos++;
        }
        public void DecrementarMovimento()
        {
            Movimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tab.Linhas; i++)
            {
                for(int j = 0; j < Tab.Colunas; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
