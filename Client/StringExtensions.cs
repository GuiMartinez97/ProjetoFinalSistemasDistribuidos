using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class StringExtensions
    {

        public static bool IsNumeric(this string str)

        {

            double output;

            return double.TryParse(str, out output);

        }

    }
}

