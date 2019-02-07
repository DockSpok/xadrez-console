using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;
/* Esta classe possui apenas um método para imprimir o tabuleiro.
 * Por ser apenas para manipulação de tela, foi criada na raiz do projeto;
 */
namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capuradas: ");
            Console.Write("Brancas: ");
            // Imprimindo capturadas Brancas.
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            // Mudando a cor.
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Imprimindo capturadas Pretas. Em amarelo.
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            // Voltando a cor.
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    imprimirPeca(tab.peca(i,c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        // Uma nova sobrecarga do método para imprimir o tabuleiro quando uma peça é selecionada. 
        // destacando a cor de fundo das casas de movimentos possíveis.
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (posicoesPossiveis[i, c])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, c));
                    // Voltando o fundo para o original.
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            // Voltando o fundo para o original.
            Console.BackgroundColor = fundoOriginal;
        }
        // Este método serve para ler a posição 
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + ""); // o +"" serve apenas para forçar o resultado a tornar-se string.
            // Destacando a cor de fundo da peça escolhida.
            return new PosicaoXadrez(coluna, linha);
        }
        // Este método serve para mudar a cor da peça no tabuleiro.
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor auxiliar = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = auxiliar;
                }
                Console.Write(" ");
            }
        }
    }
}
