namespace nothinbutdotnetprep.infrastructure
{
  public class AnonymousCriteria<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    Matches<ItemToMatch> condition;

    public AnonymousCriteria(Matches<ItemToMatch> condition)
    {
      this.condition = condition;
    }

    public bool matches(ItemToMatch item)
    {
      return condition(item);
    }
  }
}