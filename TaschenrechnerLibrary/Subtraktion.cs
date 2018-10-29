using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public class Subtraktion : BaseOperation
    {
        public override char Rechensymbol => '-';

        public override double Berechne(IFormel formel)
        {
            CheckSymbol(formel);
            return formel.Zahl1 - formel.Zahl2;
        }
    }
}
