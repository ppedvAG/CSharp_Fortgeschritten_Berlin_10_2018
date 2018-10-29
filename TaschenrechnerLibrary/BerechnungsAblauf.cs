using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public class BerechnungsAblauf
    {
        public BerechnungsAblauf(IRechner rechner, IParser parser, Func<string> input, Action<double> output)
        {
            Rechner = rechner;
            Parser = parser;
            Input = input;
            Output = output;
        }

        public IRechner Rechner { get; private set; }
        public IParser Parser { get; private set; }
        public Func<string> Input { get; private set; }
        public Action<double> Output { get; private set; }

        public void StarteRechnerVorgang()
        {
            //Eingabe der Daten
            string aufgabe = Input();

            //Parsing
            IFormel formel = Parser.Parse(aufgabe);

            //Berechnung
            double ergebnis = Rechner.Berechne(formel);

            //Ausgabe des Ergebnisses
            Output(ergebnis);
        }
    }
}
