using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAllgemein
{
    public static class Erweiterungsmethoden
    {
        public static int Quersumme(this int zahl, bool multipliziert = false)
        {
            string zahlAlsString = zahl.ToString();
            int summe =  multipliziert ? 1 : 0;
            foreach (var item in zahlAlsString)
            {
                if(multipliziert)
                    summe *= int.Parse(item.ToString());
                else
                    summe +=  int.Parse(item.ToString());
            }
            return summe;
        }

        //Generische Methode
        public static void AddItemToList<TKey, TValue, TObjectValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TObjectValue value) where TValue : class, ICollection<TObjectValue>,new()
                                                                                                                                             
        {

            if (!dictionary.Keys.Contains(key))
            {
                dictionary.Add(key, new TValue() { value });
            }
            else
            {
                dictionary[key].Add(value);
            }
        }
    }
}
