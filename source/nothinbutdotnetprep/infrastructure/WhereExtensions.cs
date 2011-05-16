namespace nothinbutdotnetprep.infrastructure
{
  public static class WhereExtensions
  {
    public static IMatchAn<Item> equal_to<Item>(this Where<Item> value, object other)
    {
      return new AnonymousCriteria<Item>(x => value.property(x).Equals(other));
    }
  }
}