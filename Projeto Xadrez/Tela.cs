using System;
using Tabuleiro;

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
                    if (tab.Peca(i, j) == null) //vai testar para verificar se é null a linha e coluna, caso seja vai colocar o traço -
                    {
                        Console.Write("- ");
                    }
                    else //caso nao seja null vai imprimir a peça
                    {
                        ImprimirPeca(tab.Peca(i, j)); //vai imprimir a peça mais o espaço em branco
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirPeca(Peca peca)
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
