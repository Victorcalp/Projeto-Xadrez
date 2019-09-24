using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiros Tab { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiros(8, 8);
            Turno = 1;
            //sempre começa a partida com a peça branca
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            //vai tirar a peça de onde está e colocar em outro ponto
            Peca p = Tab.RetirarPeca(origem);
            //vai incrementar o movimento
            p.IncrementarQtdMovimentos();
            //vai verificar se existe, caso exista vai retirar a peça
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            // vai colocar a peça em outra posição
            Tab.ColocarPeca(p, destino);
            //se nao for null
            if (PecaCapturada != null)
            {
                //vai inserir nas pecas capturadas
                Capturadas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();
            if (pecaCapturada != null) //teve peça capturada
            {
                Tab.ColocarPeca(pecaCapturada, destino); //vai colocar a peça capturada de volta
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca PecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, PecaCapturada);
                throw new TabuleiroException("você nao pode se colocar em xeque");
            }
            //vai verificar se o adversario está em xeque com o jogador atual
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            //verifica se o adversario está em xeque mate
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                //vai verificar se a variavel da superclasse é uma instacia da subclasse
                if (x is Rei)
                {
                    return x;
                }
            }
            //se retornar null é porque nao tem Rei em jogo
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + "no tabuleiro");
            }

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna]) //verifica se está em xeque
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor)) //tal cor nao está em xeque
            {
                return false;
            }
            //vai procurar alguma peça que movendo vai tirar o rei do xeque
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            //movimento para verificar se tira do Xeque
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) //verifica se continua em xeque
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            //se fez todos os testes de cima e ainda continua em Xeque, vai retornar true (xeque mate)
            return true;
        }
        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if (Tab.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (JogadorAtual != Tab.Peca(origem).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            //se não existe movimentos possiveis para a peça escolhida
            if (!Tab.Peca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Peça escolhida nao tem movimentos possiveis");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            //se a peça nao pode mover para a posicao de destino
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            //vai retornar todas as pecas capturadas apenas pela cor informada
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            //vai retirar todas as pecas capturadas da mesma cor
            aux.ExceptWith(PecasCapturadas(cor));
            //vai sobrar as pecas que nao foram capturadas
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaXadrez(coluna, linha).ToPosicao());
            //adiciona a peça no conjunto
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            
            ColocarNovaPeca('a', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('g', 7, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Rei(Tab, Cor.Branca));
        }
    }
}
