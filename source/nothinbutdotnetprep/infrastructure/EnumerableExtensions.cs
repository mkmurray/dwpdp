using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
  public delegate bool Matches<in T>(T item) where T : class;

  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (T item in items)
      {
        yield return item;
      }
    }

    public static IEnumerable<T> filter<T>(this IEnumerable<T> items, Matches<T> filter) where T : class
    {
      foreach (T item in items)
      {
        if (filter(item))
        {
          yield return item;
        }
      }
    }
  }
}