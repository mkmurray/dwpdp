using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
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
      return create_using(new FallsInRange<PropertyType>(new ExclusiveRangeWithNoUpperBound<PropertyType>(value)));
    }

    public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
    {
      return create_using(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
    }

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return original.equal_to(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria)
    {
      return original.create_using(criteria);
    }

    public ICreateSpecifications<ItemToFilter, PropertyType> not
    {
      get { return new NegatedCriteriaFactory<ItemToFilter, PropertyType>(this); }
    }
  }
}