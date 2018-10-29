using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MyTimer
{
    //Übung: Timer nachbauen
    //In einem vorgegebenen Interval soll immer wieder der gleiche
    //Anweisungsblock ausgeführt werden.
    //Intervall und Anweisungsblock sollen vom Benutzer der Klasse festgelegt werden können

    //Bonus: Timer soll abbrechenbar sein
    //Maximale Anzahl an Durchläufen (Ticks)
    //Vordergrund/Hintergrund konfigurierbar
    //Händisches oder automatisiertes Invoking
    //Pausierung des Timers

    public class MyTimer
    {
        public int Interval { get; private set; }
        Action _method;
        public int MaxTicks { get; private set; }
        Thread _thread;
        CancellationTokenSource _cts;
        public bool InvokeAll { get; set; } = true;
        ManualResetEvent _pauseTimer;

        public MyTimer(int interval, Action method, int maxTicks = 0, bool invokeAll = true)
        {
            Interval = interval;
            _method = method;
            MaxTicks = maxTicks == 0 ? 100000 : maxTicks;
            InvokeAll = true;
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            _pauseTimer = new ManualResetEvent(true);
            Dispatcher _currentDispatcher = Dispatcher.CurrentDispatcher;
            _thread = new Thread(() =>
            {
                for (int i = 0; i < MaxTicks; i++)
                {
                    _pauseTimer.WaitOne(Timeout.Infinite);
                    Thread.Sleep(Interval);
                    _pauseTimer.WaitOne(Timeout.Infinite);
                    if (_cts.Token.IsCancellationRequested)
                        return;
                    //Mitgegebene Code ausgeführt
                    //Erfordert WindowsBase.dll
                    if (InvokeAll)
                        _currentDispatcher.Invoke(_method);
                    else
                        _method();
                }
            });
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Stop()
        {
            //Harter Stopp
            _thread?.Abort();
            _cts?.Cancel();

        }

        public void Pause()
        {
            //_thread.Suspend();
            _pauseTimer?.Reset();
        }

        public void Resume()
        {
            //_thread.Resume();
            _pauseTimer?.Set();
        }
    }
}
