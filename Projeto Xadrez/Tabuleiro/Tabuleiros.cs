
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
    }
}
