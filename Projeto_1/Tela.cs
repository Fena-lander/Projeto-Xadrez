﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_1.Board;
using Projeto_1.Chess;

namespace Projeto_1
{
    internal class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");
            if (!partida.Terminada)
            {
                Console.WriteLine($"Jogador: {partida.JogadorAtual}");
                if (partida.Xeque)
                {
                    Console.WriteLine("Xequê");
                }
            }
            else
            {
                Console.WriteLine("Xeque-Mate");
                Console.WriteLine($"Vencedor {partida.JogadorAtual}");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++)
                { 
                    ImprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.Red;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.BackgroundColor = FundoOriginal;
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if(posicoesPossiveis[i , j])
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = FundoAlterado;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = FundoOriginal;
            Console.WriteLine("  a b c d e f g h ");
        }


        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string x = Console.ReadLine();
            char coluna = x[0];
            int linha = int.Parse(x[1] + " ");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }
    }
}
