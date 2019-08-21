using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Generics.DictionarySample
{
    public class EmployeeIdException:Exception
    {
        public EmployeeIdException(string message):base(message)
        {
            
        }
    }

    public struct EmployeeId:IEquatable<EmployeeId>
    {
        private readonly char _prefix;
        private readonly int _number;

        public EmployeeId(string id)
        {
            Contract.Requires<ArgumentException>(id != null);
            _prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                _number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (Exception)
            {
                throw new EmployeeIdException("Invalid  EmployeeId format");
            }
        }

        public override string ToString() => _prefix + $"{_number,6:000000}";

        public override int GetHashCode() => (_number ^ _number << 16) * 0x15051505;
        public bool Equals(EmployeeId x) => (_prefix == x._prefix && _number == x._number);

        public override bool Equals(object obj) => obj != null && Equals((EmployeeId) obj);
        public static bool operator==(EmployeeId left,EmployeeId right)=>left.Equals(right);
        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);
    }
}
