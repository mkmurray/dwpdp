namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class NegatingFilteringExtensionPoint<ItemToFilter, PropertyType> :
    IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType>
  {
    IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> original;

    public NegatingFilteringExtensionPoint(IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> create_criteria_using(IMatchAn<PropertyType> criteria)
    {
      return new NegatingCriteria<ItemToFilter>(original.create_criteria_using(criteria));
    }
  }
}