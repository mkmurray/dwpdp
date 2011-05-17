using System;

namespace nothinbutdotnetprep.infrastructure
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>

  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
    }
  }
}