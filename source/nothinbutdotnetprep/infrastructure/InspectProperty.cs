namespace nothinbutdotnetprep.infrastructure
{
  public class InspectProperty<Item, PropertyType>
  {
    private PropertyAccessor<Item, PropertyType> accessor;

    public InspectProperty(PropertyAccessor<Item, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<Item> equal_to<PropertyType>(PropertyType value)
    {
      return new AnonymousCriteria<Item>(x => accessor(x).Equals(value));
    }

    public IMatchAn<Item> equal_to_any<PropertyType>(params PropertyType[] values)
    {
      var criteriaList = new AnonymousCriteria<Item>[values.Length];
      for (int i=0; i < criteriaList.Length; i++)
      {
        PropertyType value1 = values[i];
        new AnonymousCriteria<Item>(x => accessor(x).Equals(value1));
        criteriaList[i] = new AnonymousCriteria<Item>(x => accessor(x).Equals(value1));
      }

      return new OrCriteria<Item>(criteriaList);
    }
  }
}