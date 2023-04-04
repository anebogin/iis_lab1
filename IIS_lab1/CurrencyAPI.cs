using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS_lab1
{
    public abstract class CurrencyAPI
    {
        public abstract string[] GetDollar();
        public abstract string[] GetEuro();
    }
}
