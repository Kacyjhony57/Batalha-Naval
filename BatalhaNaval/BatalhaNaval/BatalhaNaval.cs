using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BatalhaNaval
{

    internal class BatalhaNaval
    {
        static void TabuleiroComputador()
        {
            string linha;
            string[] lerlinhas;

            try
            {
                JogadorComputador c = new JogadorComputador(10, 10);

                StreamReader arq = new StreamReader("frotaComputador.txt", Encoding.UTF8);
                linha = arq.ReadLine();

                while (linha != null)
                {
                    lerlinhas = linha.Split(';');



                    linha = arq.ReadLine();
                }
                arq.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }



        }


        static void Main(string[] args)
        {
            Console.WriteLine("\tJOGO BATALHA NAVAL");
            string nomeJ;
            Console.Write("Digite o nome do jogador: ");
            nomeJ = Console.ReadLine();
            JogadorHumano h = new JogadorHumano(10, 10, nomeJ);
            string nick = h.GerarNickname(nomeJ);
            JogadorComputador c = new JogadorComputador(10, 10);
            h.ImprimirTabuleiroJogador();
            Embarcacao[] barcos = new Embarcacao[9];
            barcos[0] = new Embarcacao("Submarino-1", 1);
            barcos[1] = new Embarcacao("Submarino-2", 1);
            barcos[2] = new Embarcacao("Submarino-3", 1);
            barcos[3] = new Embarcacao("Hidroavião-1", 2);
            barcos[4] = new Embarcacao("Hidroavião-2", 2);
            barcos[5] = new Embarcacao("Cruzador-1", 3);
            barcos[6] = new Embarcacao("Cruzador-2", 3);
            barcos[7] = new Embarcacao("Encouraçado", 4);
            barcos[8] = new Embarcacao("Porta-aviões", 5);
            
            for (int i = 0; i < barcos.Length; i++)
            {
                bool done = false;
                while (done == false)
                {
                    int linha, coluna;
                    Console.WriteLine("Informe onde deseja posicionar o " + barcos[i].Nome + "  de tamanho: " + barcos[i].Tamanho);
                    Console.WriteLine("Informe a linha: ");
                    linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna: ");
                    coluna = int.Parse(Console.ReadLine());
                    Posicao jogada = new Posicao(linha, coluna);
                    done = h.AdicionarEmbarcacao(barcos[i],jogada);
                }
            }
            //mostrar o tabuleiro do computador//
            //                                 //
            //                                 //
            /////////////////////////////////////
            bool ganhou = false;
            for(int i= 0 ; i < 100 || ganhou == false ; i++)
            {
                int pontoC = 0;
                int pontoH = 0;
                string campeao;
                bool acerto = true; 
                while(acerto)
                {
                    Posicao[] chanceH = h.EscolherAtaque();
                    Posicao tiro = chanceH[h.NumTirosDados];;
                    acerto = c.ReceberAtaque(tiro);
                    if(acerto == true)
                    {
                        pontoH++;
                        if(pontoH == 22)
                        {
                        campeao = $"Parabéns! ${nick} venceu!";
                        ganhou = true;
                        }
                    }

                }
                acerto = true;
                while(acerto)
                {
                    Posicao[] chanceC = c.EscolherAtaque();
                    Posicao tiro = chanceC[c.NumTirosDados];
                    acerto = h.ReceberAtaque(tiro);
                    if(acerto == true)
                    {
                        pontoC++;
                        if(pontoC == 22)
                        {
                        campeao = "Computador Ganhou!";
                        ganhou = true;
                        }
                    }
                }
            }












            Console.ReadLine();
        }
    }
}
