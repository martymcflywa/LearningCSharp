using System;
using System.Collections.Generic;

namespace ExtensionFunctions
{
    public static class MyEnumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            for (int i = start; i < (start + count); i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            using (var enumerator = source.GetEnumerator())
            {
                var i = 0;
                while (enumerator.MoveNext() && i++ < count)
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach(var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }

		public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, TResult> selector)
        {
            foreach(var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TCollection>> collectionSelector, 
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach(var outerItem in source)
            {
                foreach(var innerItem in collectionSelector(outerItem))
                {
                    yield return resultSelector(outerItem, innerItem);
                }
            }
        }

        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            var list = new List<TSource>(source);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
    }
}
