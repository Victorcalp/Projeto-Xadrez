using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiros Tab { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiros(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca; //sempre começa a partida com a peça branca
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem); //vai tirar a peça de onde está e colocar em outro ponto
            p.IncrementarQtdMovimentos(); //vai incrementar o movimento
            Peca PecaCapturada = Tab.RetirarPeca(destino); //vai verificar se existe, caso exista vai retirar a peça
            Tab.ColocarPeca(p, destino); // vai colocar a peça em outra posição
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }


        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if(Tab.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(JogadorAtual != Tab.Peca(origem).Cor){
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!Tab.Peca(origem).ExisteMovimentosPossiveis()) //se não existe movimentos possiveis para a peça escolhida
            {
                throw new TabuleiroException("Peça escolhida nao tem movimentos possiveis");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino)) //se a peça nao pode mover para a posicao de destino
            {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

         private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaXadrez('d', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('e', 2).ToPosicao());

        }
    }
}
