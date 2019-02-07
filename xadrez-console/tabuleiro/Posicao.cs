using System;

namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        
        // Esse método semelhante ao construtor serve para cada 'tipo de peça'
        // testar se é possível mover para uma determinada posição.
        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        public override string ToString()
        {
            return linha
                + ", "
                + coluna;
        }
    }
}
