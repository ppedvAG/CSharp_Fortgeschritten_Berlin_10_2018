using RechnerContracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{

    public class Addition : BaseOperation
    {
        public static char symbol = '+';

        public override char Rechensymbol => symbol;

        public override double Berechne(IFormel formel)
        {
            CheckSymbol(formel);
            return formel.Zahl1 + formel.Zahl2;
        }
    }
}
