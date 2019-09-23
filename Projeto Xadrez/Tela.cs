using System;
using System.Collections.Generic;
using Tabuleiro;
using Xadrez;

namespace Projeto_Xadrez
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogador Atual: " + partida.JogadorAtual);
            
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Preta: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
        }

        //Imprimir o tabuleiro na tela
        public static void ImprimirTabuleiro(Tabuleiros tab)
        {
            //Linhas
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                //Colunas
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //vai imprimir a peça mais o espaço em branco
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiros tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkGray;

            //Linhas
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                //Colunas
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //se essas posicoes forem possiveis, vai pintar a tela
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    //vai imprimir a peça mais o espaço em branco
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = FundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = FundoOriginal;
        }

        //vai ler o teclado
        public static PosicaXadrez LerPosicaoXadrez()
        {
            string x = Console.ReadLine();
            char coluna = x[0];
            int linha = int.Parse(x[1] + "");
            return new PosicaXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {
            //se nao tiver peca vai colocar o -
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    //se a peça for branca vai imprimir ela branca
                    Console.Write(peca + " ");
                }
                //caso seja preta ou diferente de branca
                else
                {
                    //salva no aux a cor atual do console (branca)
                    ConsoleColor aux = Console.ForegroundColor;
                    //muda a cor para amarelo
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //imprime a peça
                    Console.Write(peca + " ");
                    //volta para a cor normal
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}
