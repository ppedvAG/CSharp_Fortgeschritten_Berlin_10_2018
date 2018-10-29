using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTasksAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //EinenThreadStarten();
            //EinenThreadKillen();
            //ThreadWettrennen();
            //ThreadsCanceln();
            //SonderTestAbort();
            //TaskMitRückgabewert();
            //WarteAufMehrereThreadsMitTasks();
            //ParalleleAusführungenMitTasks();
            AsyncAwait();

            Console.WriteLine("Drücke Taste zum Beenden");
            Console.ReadKey();
            Console.WriteLine("Main-Thread fertig");
        }

        #region Async Await

        private static void AsyncAwait()
        {
            Console.WriteLine("Syncrone Variante: ");

            //int längeTOnline =  RufeWebsiteAuf("http://www.t-online.de").Length;
            //int längeZeit = RufeWebsiteAuf("http://www.zeit.de").Length;

            //Console.WriteLine("T-Online: " + längeTOnline);
            //Console.WriteLine("Zeit: " + längeZeit);

            Task<string> taskTOnline = RufeWebsiteAufAsync("http://www.t-online.de");
            Task<string> taskZeit = RufeWebsiteAufAsync("http://www.google.de");

            var t1 = taskTOnline.ContinueWith(t => Console.WriteLine("T-Online: " + t.Result.Length));
            var t2 = taskZeit.ContinueWith(t => Console.WriteLine("Google: " + t.Result.Length));

            //Däumchen drehen
            string sieger = Task.WaitAny(t1, t2) == 0 ? "T-Online" : "Google";
            Console.WriteLine($"Schneller war: {sieger}");
        }

        private static string RufeWebsiteAuf(string url)
        {
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(url).Result;
            return result;
        }

        private static async Task<string> RufeWebsiteAufAsync(string url)
        {
            if (url.Length == 0)
                return "";
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            //await Task.Delay(1000);
            return result;
        }
        #endregion

        #region ParalleleAusführungenMitTasks

        private static void ParalleleAusführungenMitTasks()
        {
            List<string> namen = new List<string>() { "Alex", "Hans", "Olaf", "Anja", "Ute", "Kerstin" };

            foreach (var item in namen)
            {
                Console.WriteLine(item.ToUpper());
            }

            Task.Run(() =>
            {
                Console.WriteLine("Mit Parallel:");
                Task.Run(() =>
                {
                    Console.WriteLine("For Schleife");
                    Parallel.For(0, namen.Count, index => { Console.WriteLine("B: " + namen[index].ToUpper()); });
                });
                try
                {
                    Parallel.ForEach<string>(namen, s => Console.WriteLine("A: " + s.ToUpper()));
                }
                catch (AggregateException exp)
                {

                    throw;
                }
            });

            Console.WriteLine("Ende..");
        }
        #endregion

        #region WarteAufMehrereThreadsMitTasks
        private static void WarteAufMehrereThreadsMitTasks()
        {
            _cts = new CancellationTokenSource();
            Task schuhmacher = new Task(() => MacheIrgendwasAufwändiges("Schuhmacher"));
            Task vettel = new Task(() => MacheIrgendwasAufwändiges("Vettel"), _cts.Token);
            vettel.ContinueWith(t =>
            {
                if (t.IsCompleted)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Hole Kinder vom Kindergarten ab!");
                }
            }, _cts.Token);

            schuhmacher.Start();
            vettel.Start();
            string sieger = Task.WaitAny(schuhmacher, vettel) == 0 ? "Schuhmacher" : "Vettel";
            _cts.Cancel();

            Console.WriteLine($"Sieger: {sieger}");
        }
        #endregion

        #region Task mit Rückgabewert


        private static void TaskMitRückgabewert()
        {

            Task<long> task1 = new Task<long>(() =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                MacheIrgendwasAufwändiges("Schuhmacher");
                watch.Stop();
                return watch.ElapsedMilliseconds;
            });

            task1.Start();

            long dauer = task1.Result;
            Console.WriteLine($"Dauer: {dauer}");
        }
        #endregion

        #region  Tests mit Exceptions

        private static void SonderTestAbort()
        {
            Thread schuhmacher = new Thread(() =>
            {
                Console.WriteLine("Start");
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("1. Schritt fertig");
                    try
                    {
                        try
                        {
                            Thread.Sleep(3000);
                            for (int i = 0; i < 100000000; i++)
                            {
                                Console.WriteLine("---");
                            }
                            Console.WriteLine("3. Schritt fertig");
                        }
                        catch (Exception exp)
                        {

                            Console.WriteLine("3. Try" + exp.Message);
                            return;
                        }
                        Thread.Sleep(2000);

                        Console.WriteLine("2. Schritt fertig");
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("2. try" + exp.Message);
                        return;
                    }
                }
                catch (Exception exp)
                {

                    Console.WriteLine("1. try" + exp.Message);
                    return;
                }
                Console.WriteLine("Komplett fertig");
            });
            schuhmacher.Start();
            Thread.Sleep(3000);
            schuhmacher.Abort();
            //schuhmacher.Interrupt();
        }
        #endregion

        #region Thread höflich canceln


        private static void ThreadsCanceln()
        {
            Thread schuhmacher = new Thread(() => MacheIrgendwasAufwändiges("Schuhmacher"));
            _cts = new CancellationTokenSource();
            schuhmacher.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Lass gut sein Schuhmacher!");
            _cts.Cancel();
        }
        #endregion

        #region Thread Wettrennen

        private static void ThreadWettrennen()
        {
            Thread schuhmacher = new Thread(() => MacheIrgendwasAufwändiges("Schuhmacher"));
            Thread vettel = new Thread(() => { Thread.Sleep(1); MacheIrgendwasAufwändiges("Vettel"); });

            //Prioritäten
            //schuhmacher.Priority = ThreadPriority.Lowest;
            //vettel.Priority = ThreadPriority.Highest;

            vettel.Start();
            schuhmacher.Start();

            //Warten
            sieger = string.Empty;
            vettel.Join();
            //if(schuhmacher.ThreadState == ThreadState.Stopped) {
            //    sieger = "schuhmacher";
            //}

            schuhmacher.Join();


            Console.WriteLine($"Sieger ist {sieger}");
        }
        #endregion


        #region Einen Thread hart killen

        private static void EinenThreadKillen()
        {
            Thread t1 = new Thread(() => MacheIrgendwasAufwändiges("Thread 1"));
            t1.IsBackground = true;
            //Werden standardmäßig im Vordergrund gestartet, außer IsBackground 
            t1.Start();
            Thread.Sleep(1000);
            t1.Abort();
            Console.ReadKey();
        }
        #endregion

        #region Einen Thread starten

        private static void EinenThreadStarten()
        {
            Thread t1 = new Thread(() => MacheIrgendwasAufwändiges("Thread 1"));
            t1.IsBackground = true;
            //Werden standardmäßig im Vordergrund gestartet, außer IsBackground 
            t1.Start();
        }
        #endregion

        #region Hilfsmethoden/Variablen

        private static CancellationTokenSource _cts;

        public static void MacheIrgendwasAufwändiges(string name, int schritte = 50, int wartezeit = 100)
        {
            try
            {
                for (int i = 0; i < schritte; i++)
                {
                    _cts?.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(wartezeit);
                    _cts?.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{name}: {i}. Schritt fertig");
                }
                _cts?.Token.ThrowIfCancellationRequested();
                Console.WriteLine($"{name} ist fertig!");
                _cts?.Token.ThrowIfCancellationRequested();
                BinFertig(name);
            }
            //Wird nur bei Abort() geworfen, nicht wenn es über den Prozess gekillt wird
            catch (OperationCanceledException)
            {
                Console.WriteLine("Wurde abgebrochen");
                return;
            }
            catch (ThreadAbortException exp)
            {
                Console.ReadKey();
            }
        }

        private static string sieger = string.Empty;
        private static object locker = true;

        private static void BinFertig(string name)
        {
            //Verhindert, dass ein anderer Thread zur gleichen Zeit den Anweisungsblock ausführt
            lock (locker)
            {
                if (sieger == string.Empty)
                    sieger = name;
            }
        }
        #endregion
    }
}
