using RechnerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaschenrechnerLibrary;

namespace TaschenrechnerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BerechnungsAblauf ablauf = new BerechnungsAblauf(new ErweiterbarerRechner(), new Parser(),
            () =>
            {
                Console.Write("Bitte Geben Sie eine Aufgabe ein: ");
                return Console.ReadLine();
            },
            output => Console.WriteLine(output));

            do
            {
                ablauf.StarteRechnerVorgang();
                Console.WriteLine("Für Beenden Esc drücken");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
    #region Mock-Klassen
    public class MockParser : IParser
    {
        public IFormel Parse(string eingabe)
        {
            return new MockFormel();
        }
    }
    public class MockFormel : IFormel
    {
        public double Zahl1 => 20;

        public double Zahl2 => 22;

        public char Symbol => '+';
    }
    public class MockRechner : IRechner
    {
        public double Berechne(IFormel formel)
        {
            return 42;
        }
    }
    #endregion
}
