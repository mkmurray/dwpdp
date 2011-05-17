using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class EnumerableFilteringExtensionPoint<ItemToFilter, PropertyType>
  {
    private readonly IEnumerable<ItemToFilter> items;
    IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> criteria_factory;

    public EnumerableFilteringExtensionPoint(IEnumerable<ItemToFilter> items, IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> filtering_extension_point)
    {
      this.items = items;
      criteria_factory = filtering_extension_point;
    }

    public IEnumerable<ItemToFilter> equal_to(PropertyType value)
    {
      return items.all_matching(criteria_factory.equal_to(value));
    }
  }
}