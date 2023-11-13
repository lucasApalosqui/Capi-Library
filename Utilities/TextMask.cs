using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities
{
    public static class TextMask
    {
        public static string CpfMask(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static string NumberMask(string number)
        {
            return string.Format("{0:(##) #####-####}", long.Parse(number));
        }
    }
}
