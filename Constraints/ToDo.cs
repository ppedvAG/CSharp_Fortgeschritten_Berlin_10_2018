using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{
    public class ToDo : ISyncronizable, IHasChildren<ToDo>, INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private TimeSpan _dauer;
        [SyncProperty]
        public TimeSpan Dauer
        {
            get
            {
                return _dauer;
            }
            set
            {
                _dauer = value;
                RaisePropertyChanged();
            }
        }
        
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected TimeSpan _startDauer;

        public ToDo(string name, TimeSpan dauer = default)
        {
            Name = name;
            Dauer = dauer;
            _startDauer = dauer == default ? TimeSpan.FromDays(1) : dauer;
            Unteraufgaben = new List<ToDo>();
        }

        public List<ToDo> Unteraufgaben { get; set; }

        public List<ToDo> Children => Unteraufgaben;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Synchronize()
        {
            //Neue Dauer ergibt sich aus der Dauer der Unteraufgaben
            if (Unteraufgaben.Count <= 0)
            {
                Dauer = _startDauer;
                return;
            }

            TimeSpan gesamtdauer = TimeSpan.Zero;
            foreach (var item in Unteraufgaben)
            {
                gesamtdauer += item.Dauer;
            }
            Dauer = gesamtdauer;
        }

        public override string ToString()
        {
            return $"{Name}: {Dauer}";
        }
    }

    public class SpecialToDo : ToDo
    {
        public SpecialToDo(string name, TimeSpan dauer = default) : base(name, dauer)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} Dringend: {Dringend}";
        }

        public bool Dringend { get; set; } = false;
    }

    public class CrazyTodo : SpecialToDo
    {
        public CrazyTodo(string name, TimeSpan dauer = default) : base(name, dauer)
        {
        }

        //Verletzt liskov-Prinzip
        public override void Synchronize()
        {
            Dauer =  base._startDauer;
        }
    }

    public class ToDoComparer : IComparer<ToDo>
    {
        public int Compare(ToDo x, ToDo y)
        {
            if (x.Dauer > y.Dauer) return 2;
            if (x.Dauer < y.Dauer) return -2;
            return 0;
        }
    }
}