using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (T item in items)
      {
        yield return item;
      }
    }

    public static IEnumerable<T> all_matching<T>(this IEnumerable<T> items, IMatchAn<T> condition) 
    {
      return all_matching(items, condition.matches);
    }

    static IEnumerable<T> all_matching<T>(this IEnumerable<T> items, Matches<T> condition) 
    {
      foreach (T item in items) if (condition(item)) yield return item;
    }
  }
}