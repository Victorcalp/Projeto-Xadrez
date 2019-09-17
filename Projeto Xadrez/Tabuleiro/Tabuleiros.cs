
namespace Tabuleiro
{
    class Tabuleiros
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiros(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        //como a matriz é privada(por segurança)

        public Peca Peca(int linha, int coluna) //metodo criado para acessar a linha e coluna
        {
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos) //operação para colocar peça no tabuleiro
        {
            Pecas[pos.Linha, pos.Coluna] = p; //vai colocar a peça na linha e coluna
            p.Posicao = pos; //vai informar a posição a peça
        }
    }
}
