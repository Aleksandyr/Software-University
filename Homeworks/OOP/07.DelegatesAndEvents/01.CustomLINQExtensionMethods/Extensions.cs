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
    }
}
