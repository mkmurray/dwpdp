namespace nothinbutdotnetprep.infrastructure
{
  public class OrCriteria<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    private readonly IMatchAn<ItemToMatch>[] _conditions;

    public OrCriteria(params IMatchAn<ItemToMatch>[] conditions)
    {
      _conditions = conditions;
    }

    public bool matches(ItemToMatch item)
    {
      foreach (IMatchAn<ItemToMatch> condition in _conditions)
      {
        if (condition.matches(item)) return true;
      }
      return false;
    }
  }
}