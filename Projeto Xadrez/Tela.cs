using System;
using Tabuleiro;
using Xadrez;

namespace Projeto_Xadrez
{
    class Tela
    {
        //Imprimir o tabuleiro na tela
        public static void ImprimirTabuleiro(Tabuleiros tab)
        {
            for (int i = 0; i < tab.Linhas; i++) //Linhas
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) //Colunas
                {
                    ImprimirPeca(tab.Peca(i, j)); //vai imprimir a peça mais o espaço em branco
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiros tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++) //Linhas
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) //Colunas
                {
                    if (posicoesPossiveis[i, j])//se essas posicoes forem possiveis, vai pintar a tela
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j)); //vai imprimir a peça mais o espaço em branco
                    Console.BackgroundColor = FundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = FundoOriginal;
        }
        public static PosicaXadrez LerPosicaoXadrez() //vai ler o teclado
        {
            string x = Console.ReadLine();
            char coluna = x[0];
            int linha = int.Parse(x[1] + "");
            return new PosicaXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null) //se nao tiver peca vai colocar o -
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca + " "); //se a peça for branca vai imprimir ela branca
                }
                else //caso seja preta ou diferente de branca
                {
                    ConsoleColor aux = Console.ForegroundColor; //salva no aux a cor atual do console (branca)
                    Console.ForegroundColor = ConsoleColor.Yellow; //muda a cor para amarelo
                    Console.Write(peca + " ");  //imprime a peça
                    Console.ForegroundColor = aux; //volta para a cor normal
                }
            }
        }
    }
}
