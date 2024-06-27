using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    internal class BatalhaNaval
    {
        static void Main(string[] args)
        {
            JogadorHumano h = new JogadorHumano(10, 10, "Kelvin Lemos");
            JogadorComputador c = new JogadorComputador(10,10);
        }
    }
}
