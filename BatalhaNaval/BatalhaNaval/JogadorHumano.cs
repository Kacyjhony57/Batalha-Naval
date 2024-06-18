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
            int x;

            Console.WriteLine("Informe a linha do tiro: ");
            linha = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a coluna do tiro: ");
            coluna = int.Parse(Console.ReadLine());
            Posicao tiro = new Posicao(linha, coluna);

            for (int i = 0; i < posTirosDados.Length && (posTirosDados[i] != null || linha > 9 || linha < 0 || coluna > 9 || coluna < 0); i++)
            {

                Console.WriteLine("Informe a linha do tiro: ");
                linha = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a coluna do tiro: ");
                coluna = int.Parse(Console.ReadLine());
                out x = i;

            }

            posTirosDados[x] = tiro;
            

            return posTirosDados;
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
