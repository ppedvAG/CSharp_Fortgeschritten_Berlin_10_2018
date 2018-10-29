using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAllgemein
{
    //Übung: ArrayList-Klasse nachbauen
    //Add, Remove
    //Danach: Indexer, IEnumerable
    public class MyList<InternArrayType> : IEnumerable
    {
        private InternArrayType[] _internesArray = new InternArrayType[0];
        private int size = 0;

        public void Add(InternArrayType newItem)
        {
            InternArrayType[] neuesArray = new InternArrayType[size + 1];
            if (size > 0)
                Array.Copy(_internesArray, neuesArray, size);

            neuesArray[size] = newItem;
            size++;
            _internesArray = neuesArray;
        }

        public IEnumerator GetEnumerator()
        {
            //foreach (var item in _internesArray)
            //{
            //    yield return item;
            //}

            //Kurzvariante
            return _internesArray.GetEnumerator();
        }

        public bool Remove(InternArrayType itemToRemove)
        {
            if (size <= 0)
                return false;

            InternArrayType[] neuesArray = new InternArrayType[size - 1];
            int j = 0;
            bool elementFound = false;
            for (int i = 0; i < _internesArray.Length; i++)
            {
                //== geht nicht, da wir durch object-Variablen auf Wertetypen schauen und dann
                //würde == nur die Speicheradressen vergleichen und nicht den Wert
                //if (!Equals(_internesArray[i], itemToRemove))
                if(_internesArray[i].Equals(itemToRemove))
                {
                    //3, 5, 7
                    //3,...7 
                    neuesArray[j] = _internesArray[i];
                    elementFound = true;
                    j++;
                }
            }
            if (elementFound)
            {
                _internesArray = neuesArray;
                return true;
            }

            return false;
        }

        //Indexer, Enumerator
        public InternArrayType this[int index]
        {
            get
            {
                if (index < size)
                    return _internesArray[index];
                throw new IndexOutOfRangeException("Ungültiger Index");
            }
            set {
                if (index < size)
                    _internesArray[index] = value;
                else
                    throw new IndexOutOfRangeException("Ungültiger Index");
            }
        }
    }
}
