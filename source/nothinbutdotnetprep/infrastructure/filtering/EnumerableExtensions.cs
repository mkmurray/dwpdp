using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public static class EnumerableExtensions
  {
    public static EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(this IEnumerable<ItemToMatch> movies,
      PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      return new EnumerableFilteringExtensionPoint<ItemToMatch, PropertyType>(movies, 
        Where<ItemToMatch>.has_a(accessor));
    }
  }
}