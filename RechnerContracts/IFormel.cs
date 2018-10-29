using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnerContracts
{    
    //2 Zahlen: 2342.324 Symbol 234234.34
    public interface IFormel
    {
       double Zahl1 { get; }
       double Zahl2  { get; }
       char Symbol { get; }
    }
}
