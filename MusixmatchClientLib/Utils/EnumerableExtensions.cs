using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusixmatchClientLib.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.Shuffle(new Random());

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        public static T Random<T>(this IEnumerable<T> source) => source.Random(new Random());

        public static T Random<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            return buffer[rng.Next(0, buffer.Count)];
        }
    }
}
