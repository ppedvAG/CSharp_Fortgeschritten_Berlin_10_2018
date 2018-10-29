using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public class Parser : IParser
    {
        public IFormel Parse(string eingabe)
        {
            //Suche nach dem Rechensymbol

            char rechensymbol = default;
            foreach (char zeichen in eingabe)
            {
                if (char.IsNumber(zeichen) || zeichen == ',' || zeichen == '.')
                    continue;
                rechensymbol = zeichen;
                break;
            }
            if (rechensymbol == default)
                throw new FormatException("Kein Rechensymbol gefunden");

            string[] zahlenAlsString = eingabe.Split(rechensymbol);
            double zahl1 = double.Parse(zahlenAlsString[0]);
            double zahl2 = double.Parse(zahlenAlsString[1]);

            return new Formel(zahl1, zahl2, rechensymbol);
        }
    }
}
