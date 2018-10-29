using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    
    public class ErweiterbarerRechner : Rechner
    {
        public Dictionary<char, IRechenoperation> Rechenoperationen { get; set; }

        public ErweiterbarerRechner()
        {
            Rechenoperationen = new Dictionary<char, IRechenoperation>();
            Rechenoperationen.Add('+', new Addition());
            Rechenoperationen.Add('-', new Subtraktion());
        }

        public override double Berechne(IFormel formel)
        {
            if (!Rechenoperationen.ContainsKey(formel.Symbol))
                throw new Exception("Unbekanntes Rechensymbol");

            return Rechenoperationen[formel.Symbol].Berechne(formel);
        }
    }
}
