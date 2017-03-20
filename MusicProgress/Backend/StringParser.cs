using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public static class StringParser
    {
        public static bool TwoNumbers(string sSource, out int i1, out int i2)
        {
            int start = sSource.IndexOf("=") + 1;
            int end = sSource.LastIndexOf("/");
            int length = end - start;
            i1 = int.Parse(sSource.Substring(start, length));
            i2 = int.Parse(sSource.Substring(end + 1));
            return true;
        }

        public static bool ThreeNumbers(string sSource, out int i1, out int i2, out int i3)
        {
            int start = sSource.IndexOf("=") + 1;
            int end = sSource.LastIndexOf("/");
            int middle = sSource.LastIndexOf("/", end-1);
            int firstInterval = middle - start;
            int secondInterval = end - middle - 1;
            i1 = int.Parse(sSource.Substring(start, firstInterval));
            i2 = int.Parse(sSource.Substring(middle + 1, secondInterval));
            i3 = int.Parse(sSource.Substring(end + 1));
            return true;
        }

    }
}