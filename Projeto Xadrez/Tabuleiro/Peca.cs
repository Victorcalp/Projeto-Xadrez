namespace Tabuleiro
{
    class Peca
    {

        public int QtdMovimentos { get; set; }
        public Cor Cor { get; protected set; }
        public Posicao Posicao { get; set; }
        public Tabuleiros Tab { get; set; }

        public Peca(Tabuleiros tab, Cor cor)
        {
            Cor = cor;
            Tab = tab;
            Posicao = null; //quando cria uma peça a posição é null
            QtdMovimentos = 0; //vai começar com 0 movimentos
        }
    }
}
