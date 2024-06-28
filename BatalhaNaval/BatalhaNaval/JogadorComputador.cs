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
            
            if (tabuleiro[tiro.Linha, tiro.Coluna] != 'A')
            {
                tabuleiro[tiro.Linha, tiro.Coluna] = 'T'; 
                return true;
            }
            else
            {
                tabuleiro[tiro.Linha, tiro.Coluna] = 'X'; 
                return false;
            }
        }

        public void ImprimirTabuleiroJogador()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; i < tabuleiro.GetLength(1); j++)
                {
                    Console.WriteLine(tabuleiro[i, j] + " ");
                }
            }
        }

        public void ImprimirTabuleiroAdversario()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (tabuleiro[i, j] == 'X' || tabuleiro[i, j] == 'T')
                    {
                        Console.Write(tabuleiro[i, j] + " ");
                    }
                    else
                    {
                        Console.Write('A' + " "); 
                    }
                }
                Console.WriteLine();
            }
        }

        public bool AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posicao)
        {
            if (posicao.Coluna + embarcacao.Tamanho > tabuleiro.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < embarcacao.Tamanho; i++)
            {
                if (tabuleiro[posicao.Linha, posicao.Coluna + i] != 'A')
                {
                    return false;
                }
            }
            char simbolo = embarcacao.Nome[0]; 
            for (int i = 0; i < embarcacao.Tamanho; i++)
            {
                tabuleiro[posicao.Linha, posicao.Coluna + i] = simbolo;
            }

            return true;
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
