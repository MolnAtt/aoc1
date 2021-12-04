using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace aoc1
{
    public static class KamuLinQ
    {
        public static int Count_pár<T>(this IEnumerable<T> collection, Func<T, T, bool> predikátum)
        {
            int db = 0;
            T előző = collection.First();
            foreach (T aktuális in collection.Skip(1))
            {
                if (predikátum(előző, aktuális))
                    db++;
                előző = aktuális;
            }
            return db;
        }
        public static int Count_négyes<T>(this IEnumerable<T> collection, Func<T, T, T, T, bool> predikátum)
        {
            int db = 0;
            T elso = collection.First();
            T masodik = collection.Skip(1).First();
            T harmadik = collection.Skip(2).First();
            foreach (T negyedik in collection.Skip(3))
            {
                if (predikátum(elso, masodik, harmadik, negyedik))
                    db++;
                elso = masodik;
                masodik = harmadik;
                harmadik = negyedik;
            }
            return db;
        }
        public static void Ki(this int x) => Console.WriteLine(x);

    }
    class Program
    {

        static void Main(string[] args)
        {
            File.ReadAllLines("teszt.txt").Select(int.Parse).Count_pár((x, y) => x < y).Ki();
            File.ReadAllLines("input.txt").Select(int.Parse).Count_pár((x, y) => x < y).Ki();
            File.ReadAllLines("teszt.txt").Select(int.Parse).Count_négyes((x, y, z, t) => x < t).Ki();
            File.ReadAllLines("input.txt").Select(int.Parse).Count_négyes((x, y, z, t) => x < t).Ki();
            Console.ReadKey();
        }
    }
}
