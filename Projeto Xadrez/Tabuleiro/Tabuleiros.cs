
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

        public Peca peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos) //operação para colocar peça no tabuleiro
        {
            if (ExistePeca(pos))//vai verificar se já tem peça na posição, caso seja verdadeiro vai apresentar a mensagem abaixo
            {
                throw new TabuleiroException("Já existe peça nessa posição!");
            }
            else //caso não exista, vai da continuidade
            {
                Pecas[pos.Linha, pos.Coluna] = p; //vai colocar a peça na linha e coluna
                p.Posicao = pos; //vai informar a posição a peça }

            }
        }

        public bool ExistePeca(Posicao pos) //testa para verificar se existe uma peça em uma dada posição
        {
            ValidaPosicao(pos); //vai verificar se a posição existe, caso exista vai da continuidade, senão vai cortar o metodo e cair na exceção
            return peca(pos) != null; //se retornar diferente de nulo é porque existe uma peça nessa posição
        }

        public bool PosicaoValida(Posicao pos) //vai verificar se tem mais Linha/Coluna que o tabuleiro
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ValidaPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos)) //se a posição nao for valida
            {
                throw new TabuleiroException("Posição Invalida");
            }
        }
    }
}
