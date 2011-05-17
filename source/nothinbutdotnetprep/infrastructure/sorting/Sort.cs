using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
  public class Sort<ItemToSort>
  {
    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
      params PropertyType[] fixed_order)
    {
      return new ComparerBuilder<ItemToSort>(new NulloComparer<ItemToSort>())
        .then_by(accessor,fixed_order);
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new NulloComparer<ItemToSort>())
        .then_by(accessor);
    }

    public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new NulloComparer<ItemToSort>())
        .then_by_descending(accessor);
    }
  }

  public class NulloComparer<T> : IComparer<T>
  {
    public int Compare(T x, T y)
    {
      return 0;
    }
  }
}