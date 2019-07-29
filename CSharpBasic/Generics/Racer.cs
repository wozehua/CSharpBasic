using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Racer:IComparable<Racer>,IFormattable
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string  Country { get; set; }

        public int Wins { get; set; }

        public Racer(int id, string firstName, string lastName, string country) : this(id, firstName, lastName, country, wins: 0)
        {
            
        }

        public Racer(int id, string firstName, string lastName, string country,int wins)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }

        public override string ToString() => $"{FirstName}{LastName}";
        public string ToString(string format) => ToString(format, null);
        public int CompareTo(Racer other)
        {
            int compare = LastName?.CompareTo(other.LastName) ?? -1;
            if (compare == 0)
            {
                return FirstName?.CompareTo(other.FirstName) ?? -1;
            }

            return compare;

        }

        private Queue a = new Queue();
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return $"{ToString()},Wins:{Wins}";
                case "A":
                    return $"{ToString()},Country:{Country} Wins:{Wins}";
                default:
                    throw new FormatException(String.Format(formatProvider, $"Format{format}is not supported"));
            }
        }
    }
}
