using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{
    //Snippet: Attribute

    [System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class SyncPropertyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236

        // This is a positional argument
        public SyncPropertyAttribute()
        {
          
        }
    }
}
