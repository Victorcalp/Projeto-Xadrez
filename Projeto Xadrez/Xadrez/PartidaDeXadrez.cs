using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiros Tab { get; private set; }
        public bool Terminada { get; private set; }
        private int Turno;
        private Cor JogadorAtual;

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

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaXadrez('c', 2).ToPosicao());


        }
    }
}
