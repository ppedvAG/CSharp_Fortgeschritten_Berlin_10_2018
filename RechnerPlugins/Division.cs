using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnerPlugins
{
    public class Division : IRechenoperation
    {
        public char Rechensymbol => '/';

        public double Berechne(IFormel formel)
        {
            if (formel.Symbol != Rechensymbol)
                throw new Exception("Rechensymbol ist falsch!");

            return formel.Zahl1 / formel.Zahl2;
        }
    }
}
