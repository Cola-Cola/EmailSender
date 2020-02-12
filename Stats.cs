using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    static class  Stats
    {
        public static int good { get; set; }
        public static int bad { get; set; }

        public static List<string> Errors = new List<string>();
        public static int count { get; set; }
        public static int rows { get; set; }
        public static int cols { get; set; }

    }
}
