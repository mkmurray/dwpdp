namespace nothinbutdotnetprep.infrastructure
{
  public class OrCriteria<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> left_side;
    IMatchAn<ItemToMatch> right_side;

    public OrCriteria(IMatchAn<ItemToMatch> left_side, IMatchAn<ItemToMatch> right_side)
    {
      this.left_side = left_side;
      this.right_side = right_side;
    }

    public bool matches(ItemToMatch item)
    {
      return left_side.matches(item) || right_side.matches(item);
    }
  }
}