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
                for (int j = 0; j < tab.Colunas; j++) //Colunas
                {
                    if (tab.Peca(i, j) == null) //vai testar para verificar se é null a linha e coluna, caso seja vai colocar o traço -
                    {
                        Console.Write("- ");
                    }
                    else //caso nao seja null vai imprimir a peça
                    {
                        Console.Write(tab.Peca(i, j) + " "); //vai imprimir a peça mais o espaço em branco
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
