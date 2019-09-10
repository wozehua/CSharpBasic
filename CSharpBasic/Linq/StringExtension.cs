namespace Linq
{
    public static class StringExtension
    {
        public static string FirstName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(0, ix);
        }

        public static string LastName(this string name)
        {
            return name.Substring(name.LastIndexOf(' ') + 1);
        }
    }
}
