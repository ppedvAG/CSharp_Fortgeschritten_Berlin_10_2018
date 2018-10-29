using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAllgemein
{
    public class DictionaryListManager<TIndex, TValue> : Dictionary<TIndex, List<TValue>>
    {

        public bool AllowDoubleEntries { get; set; }

        public void Add(TIndex key, TValue value)
        {
            if (!base.Keys.Contains(key))
            {
                base.Add(key, new List<TValue>() { value });
            }
            else
            {
                List<TValue> liste = base[key];
                //Optional prüfen, ob Eintrag schon vorhanden, wenn doppelte Einträge unerwünscht ist
                liste.Add(value);
            }
        }

        public bool Remove(TIndex key, TValue value)
        {
            if (!base.Keys.Contains(key))
            {
                List<TValue> liste = base[key];
                liste.Remove(value);
                //Optional kompletten Eintrag in Tabelle entfernen, wenn Liste leer ist
                if (liste.Count <= 0)
                {
                    base.Remove(key);
                }
                return true;
            }
            return false;
        }
    }
}
