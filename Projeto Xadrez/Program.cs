using System;
using Tabuleiro;
using Xadrez;

namespace Projeto_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear(); //limpar tela
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao(); //vai ler a posicao e converter a posiçao para matriz

                    bool[,] PosicaoPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis(); //vai verificar as posições possiveis da peca


                    Console.Clear(); //limpar tela
                    Tela.ImprimirTabuleiro(partida.Tab, PosicaoPossiveis);


                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
