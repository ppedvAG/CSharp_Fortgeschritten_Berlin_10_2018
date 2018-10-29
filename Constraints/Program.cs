using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDo wohnung = new ToDo("Wohnung aufräumen", TimeSpan.FromHours(2));
            SyncTree<ToDo> Todos = new SyncTree<ToDo>(wohnung);

            ToDo küche = new ToDo("Küche", TimeSpan.FromHours(1));
            ToDo bad = new ToDo("Bad", TimeSpan.FromMinutes(30));

            Todos.Add(küche, wohnung);

            Console.WriteLine($"Dauer nach Hinzufügen von Küche: {wohnung.Dauer}");

            küche.Dauer = TimeSpan.FromHours(3);

            Todos.Add(bad, wohnung);

            Console.WriteLine($"Dauer nach Hinzufügen des Bades: {wohnung.Dauer}");

            Console.WriteLine($"Dauer nach Änderung der Küchendauer: {wohnung.Dauer}");


            Console.WriteLine();

            Console.WriteLine("\nAlle Aufgaben die kürzer als 1 Stunde benötigen: ");
            Todos.FindeKnoten(todo => todo.Dauer < TimeSpan.FromHours(1)).ForEach(todo => Console.WriteLine(todo));

            Console.WriteLine("\nAlle Aufgaben die mindestens 1 Unteraufgabe haben: ");
            Todos.FindeKnoten(todo => todo.Unteraufgaben.Count > 0).ForEach(todo => Console.WriteLine(todo));

            Console.WriteLine("\nAlle Objekte die mindestens 10 Zeichen Selbstbeschreibung haben: ");
            Todos.FindeKnoten(AllgemeinesSuchkriteriumFürSyncTreeKnoten).ForEach(todo => Console.WriteLine(todo));

            Console.WriteLine("Name von Bad-Aufgabe geändert");
            bad.Name = "Bad lassen wa doch";
            

            //Kontravarianz: Für den geforderten generischen Datentypen darf auch ein allgemeiner Datentyp benutzt werden (in-Parameter)
            //Kovarianz: Für den geforderten generischen Datentypen darf auch ein abgeleiteter Datentyp benutzt werden (out-Parameter)

            IEnumerable<ToDo> iTodo = new List<ToDo>();
            iTodo = new List<SpecialToDo>();

            foreach (var item in iTodo)
            {
                Console.WriteLine(item.ToString());
                if (item is SpecialToDo specialTodo)
                    Console.WriteLine(specialTodo.Dringend);
            }

            //IEnumerable<SpecialToDo> iSpecialTodos = iTodo; geht nicht!
            //foreach (var item in iSpecialTodos)
            //{
            //    Console.WriteLine(item.Dringend);
            //}

            IComparer<ToDo> iTodoComparer = new ToDoComparer();
            IComparer<SpecialToDo> iSpecialTodoComparer = new ToDoComparer();
            //iTodoComparer = iSpecialTodoComparer;
            //iTodoComparer.Compare(new ToDo("..."), new ToDo("..."));
            iSpecialTodoComparer.Compare(new SpecialToDo("Auf"), new SpecialToDo("Auf"));

            Func<ToDo, bool> sortierDel = t => true;
            Func<ToDo, bool> sortierDiel2 = AllgemeinesSuchkriteriumFürSyncTreeKnoten;

            Func<ToDo, ToDo> iregndeineMeth = t => t;
            iregndeineMeth = Bla;
            iregndeineMeth(new ToDo("adsd"));


            //UnitTest
            TesteToDo(new ToDo(".."));
            TesteToDo(new SpecialToDo(".."));
            TesteToDo(new CrazyTodo("..", TimeSpan.FromDays(4)));
            Console.ReadKey();
        }

        public static void TesteToDo(ToDo todo)
        {
            todo.Children.Add(new ToDo("..", TimeSpan.FromDays(1)));
            todo.Synchronize();
            if (todo.Dauer == TimeSpan.FromDays(1));
        }

        public static SpecialToDo Bla(ToDo todo)
        {
            return new SpecialToDo("das");
        }

        public static bool AllgemeinesSuchkriteriumFürSyncTreeKnoten(object item)
        {
            //return item.Dringend == true;
            return item.ToString().Length >= 10;
        }
    }
}