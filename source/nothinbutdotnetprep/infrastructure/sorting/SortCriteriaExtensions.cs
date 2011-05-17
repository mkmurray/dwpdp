using System;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
  public static class SortCriteriaExtensions
  {
    public static SortCriteria<ItemToSort, PropertyType> and<ItemToSort, PropertyType>(this SortCriteria<ItemToSort, PropertyType> original_criteria,
                                                                                       PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return original_criteria.add_criteria(accessor);
    }
  }
}