using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.HelperClasses {
    public static class CharExtensions {

        public static string GetString(this char[] charArray) {

            StringBuilder sb = new StringBuilder();

            foreach (var c in charArray)
                sb.Append(c);

            return sb.ToString();
        }
    }
}
