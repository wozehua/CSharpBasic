using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class BitArraySample
    {
        public static void DisplayBits(BitArray bits)
        {
            foreach (bool bit in bits)
            {
                Console.Write(bit?1:0);
            }
        }
    }
}
