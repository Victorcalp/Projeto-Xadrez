using Tabuleiro;

namespace Xadrez
{
    class PosicaXadrez
    {
        public char Colunas { get; set; }
        public int Linhas { get; set; }

        public PosicaXadrez(char coluna, int linha)
        {
            Colunas = coluna;
            Linhas = linha;
        }

        public override string ToString()
        {
            return "" + Colunas + Linhas;
        }

        //vai converter a posição do Xadrez para uma posição interna da Matriz
        public Posicao ToPosicao() 
        {
            return new Posicao(8 - Linhas, Colunas - 'a');
        }

    }
}
