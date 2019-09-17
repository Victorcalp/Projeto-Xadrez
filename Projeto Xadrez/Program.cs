using System;
using Tabuleiro;

namespace Projeto_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiros tab = new Tabuleiros(8,8);
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
