using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    internal class JogadorHumano
    {
        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        private string nickname;
        

        ////------METODO CONSTRUTOR-----
        public JogadorHumano(int linhas, int colunas, string nome)
        {
            tabuleiro = new char[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    tabuleiro[i, j] = 'A';
                }
                Console.WriteLine();
            }
            posTirosDados = new Posicao[100];
            pontuacao = 0;
            numTirosDados = 0;
            GerarNickname(nome);
        }

        //-------- METODOS ------------
        public string GerarNickname(string nome)
        {
            string resto;

            string[] nome2 = nome.Split(' ');
            string nickname = nome2[0];
            for (int i = 1; i < nome2.Length; i++)
            {
                resto = nome2[i];
                nickname += resto[0];
            }
            return nickname;
        }
        
       public Posicao[] EscolherAtaque()
        {

            int linha;
            int coluna;
            bool valida = false;

            Console.Write("Informe a linha do tiro: ");
            linha = int.Parse(Console.ReadLine());
            Console.Write("Informe a coluna do tiro: ");
            coluna = int.Parse(Console.ReadLine());
            Posicao tiro = new Posicao(linha, coluna);
            int i;
            /// se dentro do tabuleiro
            while (linha > 9 || linha < 0 || coluna > 9 || coluna < 0)
            {
                Console.WriteLine("Posição fora do tabuleiro! Informe novamente as posições!");
                Console.Write("Informe a linha do tiro: ");
                linha = int.Parse(Console.ReadLine());
                Console.Write("Informe a coluna do tiro: ");
                coluna = int.Parse(Console.ReadLine());

            }

            // se tiro valido
            for (i = 0; i < posTirosDados.Length && (valida == false); i++)
            {
                //se atirou aqui
                if (posTirosDados[i].Linha == linha && posTirosDados[i].Coluna == coluna)
                    valida = false;
                else
                    valida = true;

                if (valida = true && (posTirosDados[i] == null))
                {
                    posTirosDados[i] = tiro;
                    return posTirosDados;
                }
                else
                    valida = false;

                Console.WriteLine("\nPosição de tiro ja utilizda!");
                Console.WriteLine("Informe a linha do tiro: ");
                linha = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a coluna do tiro: ");
                coluna = int.Parse(Console.ReadLine());
            }
            return posTirosDados;
        }

        
        public void ImprimirTabuleiroJogador()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; i < tabuleiro.GetLength(1); j++)
                {
                    Console.Write(tabuleiro[i, j] + " ");
                }
                Console.WriteLine();
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
            if (posicao.Linha + embarcacao.Tamanho > tabuleiro.GetLength(0))
            {
                Console.WriteLine("Posição excede tabuleiro!");
                return false;
            }

            for (int i = 0; i < embarcacao.Tamanho; i++)
            {
                if (tabuleiro[posicao.Linha, posicao.Coluna + i] != 'A')
                {
                    Console.WriteLine("Posição com embarcação");
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


        ////-----PROPRIEDADES--
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
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }



    }
}
