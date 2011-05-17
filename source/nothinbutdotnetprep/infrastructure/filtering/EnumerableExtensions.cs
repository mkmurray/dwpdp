using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public static class EnumerableExtensions
  {
    public static EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(this IEnumerable<ItemToMatch> movies,
      PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      var original = new FilteringExtensionPoint<ItemToMatch, PropertyType>(accessor);
      return new EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType>(movies, original);
    }
  }
}