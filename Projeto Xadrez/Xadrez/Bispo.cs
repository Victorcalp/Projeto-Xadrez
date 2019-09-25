using System;
using Tabuleiro;

namespace Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiros tabuleiro , Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna -1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //Suldeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            //SudoEste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            return mat;
        }
    }
}
