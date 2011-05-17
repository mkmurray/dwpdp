using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public static class EnumerableExtensions
  {
    public static EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(this IEnumerable<ItemToMatch> movies,
      PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      return new EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType>(movies, 
        Where<ItemToMatch>.has_a(accessor));
    }

    public static SortCriteria<ItemToSort, PropertyType> sort_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
      PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new SortCriteria<ItemToSort, PropertyType>(items, accessor);
    }
  }
}