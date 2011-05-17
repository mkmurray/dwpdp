using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
  public class SortCriteria<ItemToSort, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    private List<ItemToSort> items;
    private List<PropertyAccessor<ItemToSort, PropertyType>> accessor_list;
    
    public SortCriteria(IEnumerable<ItemToSort> items, PropertyAccessor<ItemToSort, PropertyType> accessor)
    {
      this.items = new List<ItemToSort>(items);
      accessor_list = new List<PropertyAccessor<ItemToSort, PropertyType>>();
      accessor_list.Add(accessor);
    }

    public SortCriteria<ItemToSort, PropertyType> add_criteria(PropertyAccessor<ItemToSort, PropertyType> accessor)
    {
      accessor_list.Add(accessor);
      return this;
    }

    public IEnumerable<ItemToSort> ascending
    {
      get
      {
        items.Sort((x, y) =>
        {
          int compare_value = 0;
          foreach(var accessor in accessor_list)
          {
            compare_value = accessor(x).CompareTo(accessor(y));

            if (compare_value != 0) return compare_value;
          }

          return compare_value;
        });

        foreach (var item in items) { yield return item; }
      }
    }

    public IEnumerable<ItemToSort> descending
    {
      get
      {
        items.Sort((x, y) =>
        {
          int compare_value = 0;
          foreach(var accessor in accessor_list)
          {
            compare_value = accessor(y).CompareTo(accessor(x));

            if (compare_value != 0) return compare_value;
          }

          return compare_value;
        });

        foreach (var item in items) { yield return item; }
      }
    }
  }
}