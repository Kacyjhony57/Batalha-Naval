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
            int i = 0;
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
                    int posLinha = int.Parse(lerlinhas[1]);
                    int posColuna = int.Parse(lerlinhas[2]);
                    Posicao p = new Posicao(posLinha, posColuna);
                    Embarcacao[] barcos = new Embarcacao[9];
                    string barco = lerlinhas[0];
                    barcos[i] = new Embarcacao(barco , 1);
                    Console.WriteLine(lerlinhas[0]);
                    i++;
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
            Console.WriteLine($"Seu nickname é ${nick}.")
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
            int venceu;
            for(int i= 0 ; i < 100 || ganhou == false ; i++)
            {
                int pontoC = 0;
                int pontoH = 0;
                string campeao;
                bool acerto = true; 
                Console.WriteLine("Vez do "+ nick);
                while(acerto)
                {
                    c.ImprimirTabuleiroAdversario();
                    Posicao[] chanceH = h.EscolherAtaque();
                    Posicao tiro = chanceH[h.NumTirosDados];;
                    acerto = c.ReceberAtaque(tiro);
                    if(acerto == true)
                    {
                        c.tabuleiro[tiro.Linha,tiro.Coluna]='T';
                        Console.WriteLine("Tiro acertou uma embarcação!");
                        c.ImprimirTabuleiroAdversario();
                        pontoH++;
                        if(pontoH == 22)
                        {
                        venceu = 1;
                        campeao = $"Parabéns! ${nick} venceu!";
                        ganhou = true;
                        }
                    }
                    else
                    {
                        c.tabuleiro[tiro.Linha,tiro.Coluna]='X';
                        Console.WriteLine("Tiro acertou a água!");
                        c.ImprimirTabuleiroAdversario();
                        acerto = false;
                    }

                }
                acerto = true;
                Console.WriteLine("Vez do Computador!");
                while(acerto)
                {
                    h.ImprimirTabuleiroAdversario();
                    Posicao[] chanceC = c.EscolherAtaque();
                    Posicao tiro = chanceC[c.NumTirosDados];
                    acerto = h.ReceberAtaque(tiro);
                    if(acerto == true)
                    {
                        h.tabuleiro[tiro.Linha,tiro.Coluna]='T';
                        Console.WriteLine("Tiro acertou uma embarcação!");
                        h.ImprimirTabuleiroAdversario();
                        pontoC++;
                        if(pontoC == 22)
                        {
                        venceu = 2;
                        campeao = "Computador Ganhou!";
                        ganhou = true;
                        }
                        else
                        {
                        h.tabuleiro[tiro.Linha,tiro.Coluna]='X';
                        Console.WriteLine("Tiro acertou a água!");
                        h.ImprimirTabuleiroAdversario();
                        acerto = false;
                        }
                    }
                }
            }
            Console.WriteLine("\t\nFim de jogo!");
            Console.WriteLine(campeao);
            try
            {
               StreamWriter arq3 = new StreamWriter("C:\\Arq3.txt", true, Encoding.UTF8);
               if(venceu == 1)
               {
                 for (int x = 0; x <= h.NumTirosDados ; x++)
                 {
                   arq3.WriteLine($"Tiro ${x}: ${h.posTirosDados[x].Linha},${h.posTirosDados[x].Coluna}");
                 }
               }
               else
               {
                   for (int x = 0; x <= c.NumTirosDados ; x++)
                 {
                   arq3.WriteLine($"Tiro ${x}: ${c.posTirosDados[x].Linha},${c.posTirosDados[x].Coluna}");
                 }
               }
            }
            catch(Exception e)
            { 
              Console.WriteLine("Exception: " + e.Message);
            }
        

            Console.ReadLine();
        }
    }
}
