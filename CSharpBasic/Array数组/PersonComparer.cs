using System;
using System.Collections.Generic;

namespace Array数组
{
    public class PersonComparer:IComparer<Person>
    {
        private readonly PersonCompareType _personCompareType;

        public PersonComparer(PersonCompareType personCompareType)
        {
            _personCompareType = personCompareType;
        }
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            switch (_personCompareType)
            {
                case PersonCompareType.FirstName:
                    return string.CompareOrdinal(x.FirstName, y.FirstName);
                    
                case PersonCompareType.LastName:
                    return string.CompareOrdinal(x.LastName, y.LastName);
                default:
                    throw new ArgumentException("unexpercted compare type");
            }

        }
    }

    public enum PersonCompareType
    {
        FirstName,
        LastName
    }
}
