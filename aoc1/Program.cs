using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace aoc1
{
    public static class KamuLinQ
    {
        /// <summary>
        /// adott tulajdonságú és adott hosszúságú egymást követő részsorozatok számát adja meg.
        /// </summary>
        /// <typeparam name="T">elem típusa</typeparam>
        /// <param name="collection">tároló</param>
        /// <param name="intervallumhossz">milyen hosszan kell nézni a számsorozatokat</param>
        /// <param name="predikátum">a számsorozatra vonatkozó predikátum</param>
        /// <returns>az egymást követő adott tulajdonságú és adott hosszúságú részsorozatok száma.</returns>
        public static int Count_részintervallum<T>(this IEnumerable<T> collection, int intervallumhossz, Func<T[], bool> predikátum)
        {
            int db = 0;
            T[] futóintervallum = new T[intervallumhossz];
            for (int i = 1; i < intervallumhossz; i++)
                futóintervallum[i] = collection.ElementAt(i);

            foreach (T aktuális in collection.Skip(intervallumhossz-1))
            {
                for (int i = 1; i < intervallumhossz; i++)
                {
                    futóintervallum[i - 1] = futóintervallum[i];
                    futóintervallum[i] = aktuális;
                }
                if (predikátum(futóintervallum))
                    db++;
            }

            return db;
        }
        public static void Ki(this int x) => Console.WriteLine(x);

    }
    class Program
    {

        static void Main(string[] args)
        {
            File.ReadAllLines("teszt.txt").Select(int.Parse).Count_részintervallum(2, t => t[0] < t[1]).Ki();
            File.ReadAllLines("input.txt").Select(int.Parse).Count_részintervallum(2, t => t[0] < t[1]).Ki();
            File.ReadAllLines("teszt.txt").Select(int.Parse).Count_részintervallum(4, t => t[0] < t[3]).Ki();
            File.ReadAllLines("input.txt").Select(int.Parse).Count_részintervallum(4, t => t[0] < t[3]).Ki();
            Console.ReadKey();
        }
    }
}
