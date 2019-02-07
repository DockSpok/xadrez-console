
namespace tabuleiro
{
    abstract class Peca
    {
        // Propriedades.

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        // Construtores.
        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        // Métodos.
        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }
        // Testa se a peça escolhida pelo jogador não está bloqueada.
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (mat[i, c])
                    {
                        return true;
                    }
                }
            }
            // Se depois de percorrer todo o tabuleiro não houver casa 'true'...
            return false;
        }

        // Método validador de movimento.
        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
