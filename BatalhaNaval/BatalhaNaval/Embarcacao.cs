using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    internal class Embarcacao
    {
        private string nome;
        private int tamanho;

        public Embarcacao(string nome, int tamanho)
        {
            this.nome = nome;
            this.tamanho = tamanho;
        }

        
        public string Nome(){
            get { return nome;}
            set { nome = value; }
        }
        public int tamanho(){
            get { return tamanho;}
            set { tamanho = value; }
        }

    }
}
