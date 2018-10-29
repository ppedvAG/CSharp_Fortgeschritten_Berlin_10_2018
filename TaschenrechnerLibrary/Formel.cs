using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public class Formel : IFormel
    {
        public double Zahl1 { get; private set; }

        public double Zahl2 { get; private set; }

        public char Symbol { get; private set; }

        public Formel(double zahl1, double zahl2, char symbol)
        {
            Zahl1 = zahl1;
            Zahl2 = zahl2;
            Symbol = symbol;
        }
    }
}
