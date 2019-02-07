using System;

namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        // Construtor para exceções personalizadas. Esta herdando a mensagem do sistema.
        public TabuleiroException(string msg) : base(msg)
        {
        }
    }
}
