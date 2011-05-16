namespace nothinbutdotnetprep.infrastructure
{
  public class Where<Item>
  {
    private Where()
    {
    }

    public static InspectProperty<Item, PropertyType> has_a<PropertyType>(PropertyAccessor<Item,PropertyType> accessor)
    {
      return new InspectProperty<Item, PropertyType>(accessor);
    }
  }
}