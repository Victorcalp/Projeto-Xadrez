namespace Tabuleiro
{
    class Peca
    {

        public int QtdMovimentos { get; set; }
        public Cor Cor { get; protected set; }
        public Posicao Posicao { get; set; }
        public Tabuleiros Tab { get; set; }

        public Peca(Cor cor, Posicao posicao, Tabuleiros tab)
        {
            QtdMovimentos = 0;
            Cor = cor;
            Posicao = posicao;
            Tab = tab;
        }
    }
}
