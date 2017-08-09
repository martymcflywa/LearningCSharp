using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqExercises
{
    public static class LinqFunctions
    {
        public static IEnumerable<T> Generate<T>(T seed, Func<T, T> increment)
        {
            var i = seed;
            while (true)
            {
                yield return i;
                i = increment(i);
            }
        }

        public static IEnumerable<TSource> TTake<TSource>(this IEnumerable<TSource> source, int count)
        {
            int i = 0;
            foreach (var elem in source)
            {
                if (i < count)
                    yield return elem;
                else
                    yield break;

                i++;
            }
        }

        public static IEnumerable<int> TRange(int start, int count)
        {
            for (int i = 0; i < count; i++)
                yield return start + i;
        }

        public static IEnumerable<TSource> TWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var elem in source)
            {
                if (predicate(elem))
                    yield return elem;
            }
        }

        public static IEnumerable<TSource> TWhere<TSource>(this IEnumerable<TSource> source, 
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach (var elem in source)
            {
                if (predicate(elem, index))
                    yield return elem;

                index++;
            }
        }

        public static IEnumerable<TSource> TReverse<TSource>(this IEnumerable<TSource> source)
        {
            var temp = new List<TSource>();

            foreach (var elem in source)
                temp.Add(elem);

            for (int i = temp.Count(); i > 0; i--)
                yield return temp[i - 1];
        }

        public static IEnumerable<TResult> TSelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var elem in source)
            {
                var temp = selector(elem);
                foreach (var otherElem in temp)
                    yield return otherElem;
            }
        }

        public static IEnumerable<TResult> TSelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var elem in source)
            {
                var temp = collectionSelector(elem);
                foreach (var otherElem in temp)
                    yield return resultSelector(elem, otherElem);
            }
        }
    }
}
