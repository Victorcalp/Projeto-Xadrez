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
                    try
                    {
                        Console.Clear();

                        Tela.ImprimirPartida(partida);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao(); //vai ler a posicao e converter a posiçao para matriz
                        partida.ValidarPosicaoDeOrigem(origem);

                        //vai verificar as posições possiveis da peca e selecionar as posições
                        bool[,] PosicaoPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();


                        //limpar tela
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, PosicaoPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    Console.Clear();
                }

                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
