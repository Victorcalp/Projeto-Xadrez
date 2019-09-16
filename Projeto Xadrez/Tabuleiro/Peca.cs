namespace Tabuleiro
{
    class Peca
    {

        public int QtdMovimentos { get; set; }
        public Cor cor { get; protected set; }
        public Posicao Posicao { get; set; }
        public Tabuleiros tabu { get; set; }

    }
}
