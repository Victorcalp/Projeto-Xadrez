using Tabuleiro;

namespace Xadrez
{
    class PosicaXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }

        //vai converter a posição do Xadrez para uma posição interna da Matriz
        public Posicao ToPosicao() 
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

    }
}
