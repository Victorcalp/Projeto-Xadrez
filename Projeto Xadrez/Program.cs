using System;
using Tabuleiro;
using Xadrez;

namespace Projeto_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiros tab = new Tabuleiros(8,8); //quantidade de linhas e colunas


            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

            Tela.ImprimirTabuleiro(tab);
        }
    }
}
