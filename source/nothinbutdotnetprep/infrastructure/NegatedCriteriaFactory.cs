using System;

namespace nothinbutdotnetprep.infrastructure
{
  public class NegatedCriteriaFactory<ItemToFilter, PropertyType> : ICreateSpecifications<ItemToFilter, PropertyType>
  {
    private readonly ICreateSpecifications<ItemToFilter, PropertyType> original;

    public NegatedCriteriaFactory(ICreateSpecifications<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return new NegatingCriteria<ItemToFilter>(original.equal_to(value));
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] values)
    {
      return new NegatingCriteria<ItemToFilter>(original.equal_to_any(values));
    }

    public IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria)
    {
      return new NegatingCriteria<ItemToFilter>(original.create_using(criteria));
    }

    public NegatedCriteriaFactory<ItemToFilter, PropertyType> not
    {
      get { throw new NotImplementedException(); }
    }
  }
}