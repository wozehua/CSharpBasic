using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Person
    {
        private Person()
        {
            
        }

        public static Person CreateInstance()
        {
            return new Person();
        }
    }
}
