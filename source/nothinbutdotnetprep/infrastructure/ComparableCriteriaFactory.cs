using System;

namespace nothinbutdotnetprep.infrastructure
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : ICreateSpecifications<ItemToFilter, PropertyType>
    where PropertyType : IComparable<PropertyType>

  {
    ICreateSpecifications<ItemToFilter, PropertyType> original;

    public ComparableCriteriaFactory(ICreateSpecifications<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      return create_using(new IsGreaterThan<PropertyType>(value));
    }

    public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
    {
      return create_using(new IsBetween<PropertyType>(start, end));
    }

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return original.equal_to(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
    {
      return original.not_equal_to(value);
    }

    public IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria)
    {
      return original.create_using(criteria);
    }
  }
}