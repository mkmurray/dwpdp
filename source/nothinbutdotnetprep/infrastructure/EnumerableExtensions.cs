using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<ItemToSort> order_by<ItemToSort,PropertyType>(this IEnumerable<ItemToSort> items, PropertyAccessor<ItemToSort,PropertyType> accessor,params PropertyType[] order)
    {
      return items.sort_using(Sort<ItemToSort>.by(accessor,order));
    }

    public static IEnumerable<ItemToSort> order_by<ItemToSort,PropertyType>(this IEnumerable<ItemToSort> items, PropertyAccessor<ItemToSort,PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return items.sort_using(Sort<ItemToSort>.by(accessor));
    }

    public static IEnumerable<ItemToSort> order_by_descending<ItemToSort,PropertyType>(this IEnumerable<ItemToSort> items, PropertyAccessor<ItemToSort,PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return items.sort_using(Sort<ItemToSort>.by_descending(accessor));
    }

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer);
      return sorted;
    }

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