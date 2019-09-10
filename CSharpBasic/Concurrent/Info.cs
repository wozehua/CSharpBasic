using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent
{
    public class Info
    {
        public string  Word { get; set; }

        public int Count { get; set; }

        public string Color { get; set; }
        public override string ToString() => $"{Count} times:{Word}";
    }

   
}
