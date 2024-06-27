using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BatalhaNaval
{
    internal class JogadorComputador
    {
        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;

        //------METODO CONSTRUTOR-----
        public JogadorComputador(int linhas, int colunas)
        {
            tabuleiro = new char[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    tabuleiro[i, j] = 'A';
                }
            }
            posTirosDados = new Posicao[100];
            pontuacao = 0;
            numTirosDados = 0;
        }

        //-------- METODOS ------------

        public Posicao[] EscolherAtaque()
        {
            Posicao[] qualquercoisa = new Posicao[10];
            bool valida = false;
            Random ataque = new Random();
            int linha = ataque.Next(10);
            int coluna = ataque.Next(10);


            return qualquercoisa ;
        }

        public bool ReceberAtaque(Posicao tiro)
        {
            bool acertou = true;

            return acertou;
        }

        public void ImprimirTabuleiroJogador()
        {

        }

        public void ImprimirTabuleiroAdversario()
        {

        }

        public bool AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posicao)
        {
            bool adicionar = true;

            return adicionar;
        }

        //-----PROPRIEDADES-----
        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }

        public int NumTirosDados
        {
            get { return numTirosDados; }
            set { numTirosDados = value; }
        }
    }
}
