using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    internal class JogadorComputador
    {
        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;

        public JogadorComputador(int linhas, int colunas)
        {
            this.pontuacao = 0;
            this.numTirosDados = 0;
            this.tabuleiro = new tabuleiro[linhas,colunas];
            this.posicao = new Posicao[linhas * colunas];

        }
    }
}
