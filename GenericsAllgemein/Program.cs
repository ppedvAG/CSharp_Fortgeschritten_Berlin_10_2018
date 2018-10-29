using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAllgemein
{
    class Program
    {
        static void Main(string[] args)
        {
            BeispieleFürGenerischeDatentypen();
            EvolutionDerGenerics();
            MyListTests();
            DictionaryListManagerTests();
            Console.ReadKey();
        }

        #region DictionaryListManager
        private static void DictionaryListManagerTests()
        {
            DictionaryListManager<string, string> StädtePersonenTabelle = new DictionaryListManager<string, string>();
            StädtePersonenTabelle.Add("Berlin", "Regina");
            StädtePersonenTabelle.Add("Berlin", "Robert");
            StädtePersonenTabelle.Add("Berlin", "Marcel");
            StädtePersonenTabelle.Add("Berlin", "Stefan");

            Console.WriteLine($"Anzahl Personen in Berlin: {StädtePersonenTabelle["Berlin"].Count}");

            Console.WriteLine("Personen in Berlin:\n");
            foreach (var item in StädtePersonenTabelle["Berlin"])
            {
                Console.WriteLine(item);
            }
            int zahl = 4231;
            Console.WriteLine($"Quersumme von {zahl}: {zahl.Quersumme(true)}");
            

            Dictionary<string, List<string>> StädteTabelle2 = new Dictionary<string, List<string>>();
            StädteTabelle2.AddItemToList("Berlin", "Regina");
            
            //Mit Linq
            //StädtePersonenTabelle["Berlin"].ForEach(person => Console.WriteLine(person));
        }
        #endregion

        #region MyList-Klasse testen
        private static void MyListTests()
        {
            Console.WriteLine("\nMyList Testen-----");

            MyList<int> meineListe = new MyList<int>();
            //Liste befüllen
            meineListe.Add(5);
            meineListe.Add(10);
            //Element aus der Liste entfernen
            meineListe.Remove(5);

            //Durchlaufen der Liste
            foreach (var item in meineListe)
            {
                Console.WriteLine(item);
            }
            //Element in der Liste bearbeiten
            meineListe[0] = 5;

            meineListe[0]++;

            Console.WriteLine(meineListe[0]);
        }
        #endregion

        #region EvolutionDerGenerics
        private static void EvolutionDerGenerics()
        {
            //Goldene Regel: Generics bringen uns Casting-Optimierung (Performanz), Bessere Benutzbarkeit/Wiederverwendbarkeit

            int[] zahlen = new int[10];
            int[] zahlen2 = new int[] { 2, 5, 4, 3 };

            int[] zahlenExt = new int[5];
            Array.Copy(zahlen2, zahlenExt, zahlen2.Length);
            zahlenExt[4] = 10;
            zahlen2 = zahlenExt;

            ArrayList zahlenListe = new ArrayList() { 2, 5, 4 };
            zahlenListe.Add(10);
            zahlenListe.Remove(5);

            int summe = 0;
            foreach (var item in zahlenListe)
            {
                summe += (int)item;
            }

            //Boxing/Unboxing: Von einem Referenztypen in Wertetypen konvertieren
            //Wertetypen: double, float, char, int, (Pseudo-Wertetyp: string),bool
            //Wertetypen sind immer Structs
            double kommazahl1 = 5.4;
            double kommazahl2 = kommazahl1; //Der Wert wird kopiert
            kommazahl1 = 3;
            Console.WriteLine(kommazahl2); // ergibt 5.4
            TimeSpan zeitdauer = TimeSpan.FromDays(2);
            DateTime timestamp;

            ValueType wertetyp = kommazahl1;
            //ValueType wertetyp2 = "dfasd";

            //Referenztyp: Speicheradresse werden zugewiesen
            //Dabei handelt es sich immer um Klassen
            double[] kommazahlen = new double[] { 3.5, 4 };
            double[] kommazahlenCopy = kommazahlen;
            kommazahlenCopy[0] = 2;
            Console.WriteLine(kommazahlen[0]); //ergibt 2 und nicht 3.5
            object referenztyp = kommazahlen;
            object referenztyp2 = "dasdsad";

            //Zuweisung von Werttypen geht trotzdem
            //Boxing: Wertetyp zu Referenztyp: kostet viel Performance
            object referenttyp3 = zeitdauer;
            //Unboxing: sehr teuer
            Console.WriteLine((TimeSpan)referenttyp3);


            //Lösung: Generische Listen
        }
        #endregion

        #region Beispiele Für Generische Datentypen
        private static void BeispieleFürGenerischeDatentypen()
        {
            //Aufzählungstypen
            List<string> NamensListe = new List<string>();
            Stack<int> ZahlenStack = new Stack<int>();
            Queue<string> Warteschlag = new Queue<string>();

            Dictionary<string, List<string>> StädteTabelle = new Dictionary<string, List<string>>();

            StädteTabelle.Add("Berlin", new List<string>() { "Marcel", "Stefan", "Robert" });
            StädteTabelle.Add("Leipzig", new List<string>() { "Vadzim", "Andreas" });

            List<string> berliner = StädteTabelle["Berlin"];
            berliner.Add("Regina");

            //StädteTabelle.Add("Berlin", "Regina");

            Hashtable hashTable = new Hashtable();

            //Generische Delegates
            Func<int, bool> methodeMitRückgabewertBoolUndEinenParameterInteger;

            //Deserialisierung: Json -> .NET-Objekt
            //JsonConvert.DeserializeObject("...");
            //JsonConvert.DeserializeObject<string>("...");

            //"alte" Tuple, benutzt man nur bei Hilfsmethoden mit sehr unkomplexen Rückgabewerten
            Tuple<string, string, int> Person = new Tuple<string, string, int>("Alex", "Berlin", 32);
            Console.WriteLine(Person.Item1);

            //Entity Framework
            //DbSet<int>
        }
        #endregion

    }
}
