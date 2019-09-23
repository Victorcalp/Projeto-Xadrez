﻿using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiros Tab { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiros(8, 8);
            Turno = 1;
            //sempre começa a partida com a peça branca
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            //vai tirar a peça de onde está e colocar em outro ponto
            Peca p = Tab.RetirarPeca(origem);
            //vai incrementar o movimento
            p.IncrementarQtdMovimentos();
            //vai verificar se existe, caso exista vai retirar a peça
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            // vai colocar a peça em outra posição
            Tab.ColocarPeca(p, destino);
            //se nao for null
            if (PecaCapturada != null)
            {
                //vai inserir nas pecas capturadas
                Capturadas.Add(PecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if (Tab.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (JogadorAtual != Tab.Peca(origem).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            //se não existe movimentos possiveis para a peça escolhida
            if (!Tab.Peca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Peça escolhida nao tem movimentos possiveis");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            //se a peça nao pode mover para a posicao de destino
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            //vai retornar todas as pecas capturadas apenas pela cor informada
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            //vai retirar todas as pecas capturadas da mesma cor
            aux.ExceptWith(PecasCapturadas(cor));
            //vai sobrar as pecas que nao foram capturadas
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaXadrez(coluna, linha).ToPosicao());
            //adiciona a peça no conjunto
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 3, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 4, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 2, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 3, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 4, new Torre(Tab, Cor.Preta));
        }
    }
}
