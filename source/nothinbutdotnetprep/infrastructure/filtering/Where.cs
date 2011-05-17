namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class Where<ItemToMatch>
  {
    public static FilteringExtensionPoint<ItemToMatch, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      return new FilteringExtensionPoint<ItemToMatch, PropertyType>(accessor);
    }
  }
}