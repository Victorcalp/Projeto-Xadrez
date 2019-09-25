using System;
using Tabuleiro;

namespace Xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiros tab, Cor cor) : base(tab, cor)
        { }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos); //pega a posicao da peça
            return p == null || p.Cor != Cor; //só vai pode mover quando a casa estiver vazia e a cor da peça for diferente 
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.Linha -= 1; //vai continuar verificando a linha
            }
            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.Linha += 1; //incrementa a linha  e continua verificando 
            }
            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.Coluna += 1; //incrementa a Coluna  e continua verificando 
            }
            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) //enquanto for verdade, vai movendo
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) //se pegar uma peça diversaria vai parar
                {
                    break;
                }
                pos.Coluna -= 1; //incrementa a linha  e continua verificando 
            }
            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
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
