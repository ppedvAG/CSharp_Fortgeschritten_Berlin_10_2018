using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public class Rechner : IRechner
    {
        //Addition und Subtraktion
        public virtual double Berechne(IFormel formel)
        {
            switch (formel.Symbol)
            {
                case '+':
                    return formel.Zahl1 + formel.Zahl2;
                case '-':
                    return formel.Zahl1 - formel.Zahl2;
            }
            throw new Exception("Kein bekanntes Rechensymbol");
        }
    }
}
