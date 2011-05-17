using System;

namespace nothinbutdotnetprep.infrastructure
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;
    private CriteriaFactory<ItemToFilter, PropertyType> baseCriteriaFactory;

    public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
      baseCriteriaFactory = new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
    }

    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return baseCriteriaFactory.equal_to(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] values)
    {
      return baseCriteriaFactory.equal_to_any(values);
    }

    public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
    {
      return baseCriteriaFactory.not_equal_to(value);
    }
  }
}