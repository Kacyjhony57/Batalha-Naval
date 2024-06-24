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
            
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    tabuleiro[i, j] = 'A';
                }
                Console.WriteLine();
            }

            this.posicao = new Posicao[linhas * colunas];

        }

        
        

        public int Pontuacao
        {
            get { return pontuacao;}
            set { pontuacao = value;}
        }

        
        public int NumTirosDados
        {
            get { return numTirosDados;}
            set { numTirosDados = value;}
        }


        public Posicao[] EscolherAtaque()
        {
            int linha;
            int coluna;
            bool valida = false;

            Randon r = new Random();
            
            linha = r.Next(10)
            coluna = r.Next(10);
            
            Posicao tiro = new Posicao(linha, coluna);
            
            



            return posTirosDados;
        }

        public bool ReceberAtaque(Posicao posicao)
        {
            bool acertou = true;                 


            return acertou;
        }

        public void ImprimirTabuleiroJogador()
        {

        string[,] frotas = new string[9,3];
        string[] dados;
        string linha;
        StreamReader arq = new StreamReader("frotaComputador.txt", Encoding.UTF8);
        linha = arq.ReadLine();

        while (linha != null)
        {
            dados = linha.Split(';');





        }

        public void ImprimirTabuleiroAdversario()
        {

        }
        public void AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posicao)
        {
            bool adicionar = true;


            return adicionar;
        }










        

    }
}
