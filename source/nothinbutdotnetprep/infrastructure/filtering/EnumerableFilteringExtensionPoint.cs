using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class EnumerableFilteringExtensionPoint<ItemToFilter, PropertyType>
  {
    private readonly IEnumerable<ItemToFilter> _items;
    FilteringExtensionPoint<ItemToFilter, PropertyType> criteria_factory;

    public EnumerableFilteringExtensionPoint(IEnumerable<ItemToFilter> items, FilteringExtensionPoint<ItemToFilter, PropertyType> criteriaMaker)
    {
      _items = items;
      criteria_factory = criteriaMaker;
    }

    public IEnumerable<ItemToFilter> equal_to(PropertyType value)
    {
      var criteria = criteria_factory.equal_to(value);
      return _items.all_matching(criteria);
    }
  }
}