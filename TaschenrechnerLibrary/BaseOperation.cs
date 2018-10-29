using RechnerContracts;
using System;

namespace TaschenrechnerLibrary
{
    public abstract class BaseOperation : IRechenoperation
    {
        public abstract char Rechensymbol { get; }

        public abstract double Berechne(IFormel formel);
       
        public void CheckSymbol(IFormel formel)
        {
            if (formel.Symbol != Rechensymbol)
                throw new Exception("Symbol matcht nicht mit Rechensymbol");
        }
    }
}
