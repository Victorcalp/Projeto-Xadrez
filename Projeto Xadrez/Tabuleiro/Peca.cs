namespace Tabuleiro
{
   abstract class Peca
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

        public void IncrementarQtdMovimentos ()
        {
            QtdMovimentos++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i=0; i<Tab.Linhas; i++)
            {
                for(int j=0; j<Tab.Colunas; j++)
                {
                    //vai verificar se tem movimento possivel para a peca
                    if (mat[i,j]) 
                    {
                        return true; 
                    }
                }
            }
            //caso nao retorne True, nao tem nenhum movimento possivel
            return false;
        }

        public bool PodeMoverPara(Posicao destino)
        {
            return MovimentosPossiveis()[destino.Linha, destino.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis(); 
    }
}
