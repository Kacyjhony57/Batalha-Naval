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

        public JogadorHumano (int linhas,int colunas,string nome)
        {
            tabuleiro = new char[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    tabuleiro[i,j] = 'A';
                }
                Console.WriteLine();
            }

            pontuacao = 0;
            numTirosDados = 0;
         

            
        }

        public string GerarNickname(string nome)
        {
            string[] nome2 = nome.Split(' ');

            


            return nickname;
        }


    }
}
