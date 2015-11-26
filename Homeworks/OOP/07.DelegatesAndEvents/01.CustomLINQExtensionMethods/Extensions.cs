namespace CustomLINQExtensionMethods
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(
            this IEnumerable<T> collection, Predicate<T> filterPredicate)
        {
            var matches = new List<T>();
            foreach (var element in collection)
            {
                if (!filterPredicate(element))
                {
                    matches.Add(element);
                }
            }

            return matches;
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection, Func<TSource, TSelector> predicate)
            where TSelector : IComparable
        {
            var max = default(TSelector);
            foreach (var element in collection)
	        {
                if (predicate(element).CompareTo(max) > 0)
                {
                    max = predicate(element);
                }
	        }

            return max;
        }
    }
}
