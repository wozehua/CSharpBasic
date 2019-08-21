using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SpecialGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");
            Console.WriteLine("Hello World!");
        }

        public static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"action:{e.Action.ToString()}");
            if (e.OldItems != null)
            {
                Console.WriteLine($"starting index for old items:{e.OldStartingIndex}");
                Console.WriteLine("old items:");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }

            if (e.NewItems != null)
            {
                Console.WriteLine($"starting index for new items:{e.NewStartingIndex}");
                Console.WriteLine("new items:");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine();
        }
    }
}
