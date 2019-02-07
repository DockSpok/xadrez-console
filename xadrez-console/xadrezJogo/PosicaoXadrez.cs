using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        // Esta classe servirá para traduzir as posições da matriz
        // do computador paraa matriz tradicional do Xadrez (A-H, 1-8)
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        // O método a seguir transforma a posição típica em posição de matriz.
        public Posicao toPosicao()
        {
            // Interessante como usou o próprio valor inteiro do CHAR para fazer a conversão.
            return new Posicao(8 - linha, coluna - 'a');
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
