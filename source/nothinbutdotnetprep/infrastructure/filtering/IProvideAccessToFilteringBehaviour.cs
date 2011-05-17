namespace nothinbutdotnetprep.infrastructure.filtering
{
  public interface IProvideAccessToFilteringBehaviour<in ItemToFilter, out PropertyType>
  {
    IMatchAn<ItemToFilter> create_criteria_using(IMatchAn<PropertyType> criteria);
  }
}