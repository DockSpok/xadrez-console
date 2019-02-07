
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            // Esta será a matriz de peças do tabuleiro.
            // Terá a quantidade de linhas e colunas definidas pelo programa.
            // Será populada com as peças.
            pecas = new Peca[linhas, colunas];
        }
        // Método Peca para o programa poder acessar as peças encapsuladas nesta classe.
        // Esse método recebe do programa linha e coluna e retorna desta classe o elemento
        // da matriz 'pecas[l,c]'
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        // Melhoria do método anterior, a criação de peças recebe a posição.
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }
        // Antes de colocar uma peça temos que checar se a posição está ocupada e se é válida.
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        // o METODO abaixo serve para posicionar, colocar as peças no tabuleiro
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição.");
            }
            // Colocar uma peça 'p' em uma posição 'pos' da 'matriz de peças'.
            // 'pos' é a posição atual de cada peça 'p'.
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        // Criando um método para  Retirar peças do tabuleiro (quando uma peça é movida
        // ela é retirada de uma posição antes de ser colocada na próxima.
        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            // Criando uma peça auxiliar, temporária...
            Peca aux = peca(pos);
            aux.posicao = null;
            // Deixando o lugar vazio no tabuleiro.
            pecas[pos.linha, pos.coluna] = null;
            return aux;
            // Daqui em diante as regras do jogo estão na classe 'PartidaDeXadrez'
        }
        // Dois métodos para validar a posição.
        // O primeiro verifica se uma posição é válida...
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        // Este segundo lança uma exceção se a posição não for válida.
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida.");
            }
        }
    }
}
