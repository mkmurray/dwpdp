using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class EnumerableFilteringExtensionPoint<ItemToFilter, PropertyType>
  {
    IEnumerable<ItemToFilter> items;
    IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> criteria_factory;

    public EnumerableFilteringExtensionPoint(IEnumerable<ItemToFilter> items, IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> filtering_extension_point)
    {
      this.items = items;
      criteria_factory = filtering_extension_point;
    }

    public IEnumerable<ItemToFilter> filter_list_by_criteria(IMatchAn<PropertyType> criteria)
    {
      return items.all_matching(criteria_factory.create_criteria_using(criteria));
    }
  }
}