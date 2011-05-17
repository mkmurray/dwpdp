namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class FilteringExtensionPoint<ItemToFilter, PropertyType> :
    IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> not
    {
      get
      {
        return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this);
      }
    }

    public IMatchAn<ItemToFilter> create_criteria_using(IMatchAn<PropertyType> criteria)
    {
      return new PropertyCriteria<ItemToFilter, PropertyType>(accessor, criteria);
    }

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}