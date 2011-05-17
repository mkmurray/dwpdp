namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class PropertyCriteria<ItemToMatch, PropertyType> : IMatchAn<ItemToMatch>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;
    IMatchAn<PropertyType> value_criteria;

    public PropertyCriteria(PropertyAccessor<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> value_criteria)
    {
      this.accessor = accessor;
      this.value_criteria = value_criteria;
    }

    public bool matches(ItemToMatch item)
    {
      return value_criteria.matches(accessor(item));
    }
  }
}