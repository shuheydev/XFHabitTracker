using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace XFHabitTracker.Extensions
{
    //https://gist.github.com/mayuki/a6ccf1931e3fe35f14bc47287517cd3c

    public static class NullableReferenceTypeEnumerableExtension
    {
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
            => Enumerable.ElementAtOrDefault(source, index);

        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
            => Enumerable.FirstOrDefault(source);
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault(source, predicate);

        [return: MaybeNull]
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
            => Enumerable.LastOrDefault(source);
        [return: MaybeNull]
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.LastOrDefault(source, predicate);

        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
            => Enumerable.SingleOrDefault(source);
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault(source, predicate);

        [return: MaybeNull]
        public static TSource Min<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Min(source);
        [return: MaybeNull]
        public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => Enumerable.Min(source, selector);

        [return: MaybeNull]
        public static TSource Max<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Max(source);
        [return: MaybeNull]
        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => Enumerable.Max(source, selector);
    }
}
