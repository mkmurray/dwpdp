namespace nothinbutdotnetprep.infrastructure
{
  public class Where<Item>
  {
    public HasA<Item> property { get; private set; }

    public Where(HasA<Item> property)
    {
      this.property = property;
    }

    public static Where<Item> has_a(HasA<Item> property)
    {
      return new Where<Item>(property);
    }
  }
}