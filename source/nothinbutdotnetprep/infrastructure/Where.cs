namespace nothinbutdotnetprep.infrastructure
{
  public class Where<Item>
  {
    public static PropertyAccessor<Item,PropertyType> has_a<PropertyType>(PropertyAccessor<Item,PropertyType> accessor)
    {
      return accessor;
    }
  }
}