using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public static class Formulal
    {
        private static List<Racer> _racers;
        private static List<ChampionShip> championShips;

        public static IList<Racer> GetChampions()
        {
            return _racers ?? (_racers = new List<Racer>(40)
            {
                new Racer("Nino", "Farina", "Italy", 33, 5, new[] {1950}, new[] {"Alf Romeo"}),
                new Racer("Alberto", "Ascari", "Italy", 32, 10, new[] {1952,1953}, new[] {"Ferrari"}),
                new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new[] {1951,1954,1955,1956,1957}, new[] {"Alf Romeo","Maserati","Ferrari"}),
                new Racer("Mike", "Hawthorn", "UK", 45, 3, new[] {1958}, new[] {"Ferrari"}),
                new Racer("Phil", "Hill", "USA", 48, 3, new[] {1961}, new[] {"Ferrari"}),
                new Racer("John", "Surtees", "UK", 111, 6, new[] {1964}, new[] {"Ferrari"}),
                new Racer("Jim", "Clark", "UK", 72, 25, new[] {1963,1965}, new[] {"Lotus"}),
                new Racer("Jack", "Brabham", "Australia", 125, 14, new[] {1959,1960,1966}, new[] {"Cooper","Brabham"}),
                new Racer("Denny", "Hulme", "New Zealand", 122, 8, new[] {1967}, new[] {"Brabham"})
            });
        }

        private static List<Team> _teams;

        public static IList<Team> GetContructorChampions()
        {
            return _teams ?? (_teams = new List<Team>
            {
                new Team("Vanwall", 1958),
                new Team("Cooper", 1959, 1960),
                new Team("Ferrari", 1961, 1964, 1975, 1977, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2001, 2002, 2003,
                    2004, 2007, 2008),
                new Team("BRM", 1962),
                new Team("Lotus", 1963, 1965, 1968, 1970, 1972, 1973, 1978),
                new Team("Brabham", 1966, 1967),
                new Team("Matra", 1969),
                new Team("Tyrreall", 1971),
                new Team("Mclaren", 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998),
                new Team("Willams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996, 1997),
                new Team("Benetton", 1995),
                new Team("Renault", 2005, 2006),
                new Team("Brawn GP", 2009),
                new Team("Red Bull Racing", 2010, 2011, 2012, 2013),
                new Team("Mercedes", 2014, 2015)
            });
        }

        public static IEnumerable<ChampionShip> GetChampionShips()
        {
            return championShips ?? (championShips = new List<ChampionShip>
            {
                new ChampionShip
                {
                    Year = 1950,
                    First = "Nino Farina",
                    Second = "Juan Manuel Fangio",
                    Third = "Luigi Fagioli"
                },
                new ChampionShip
                {
                    Year = 1951,
                    First = "Juan Manuel Fangio",
                    Second = "Nino Farina",
                    Third = "Forilan Fagioli"
                }
            });
        }


    }
}
