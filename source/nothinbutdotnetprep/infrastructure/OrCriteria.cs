namespace nothinbutdotnetprep.infrastructure
{
  public class OrCriteria<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> left;
    IMatchAn<ItemToMatch> right;

    public OrCriteria(IMatchAn<ItemToMatch> left, IMatchAn<ItemToMatch> right)
    {
      this.left = left;
      this.right = right;
    }


    public bool matches(ItemToMatch item)
    {
      return left.matches(item) || right.matches(item);
    }
  }
}