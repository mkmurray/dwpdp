namespace nothinbutdotnetprep.infrastructure.filtering
{
  public static class CriteriaExtensions
  {
    public static IMatchAn<ItemToMatch> not<ItemToMatch>(this IMatchAn<ItemToMatch> to_negate)
    {
      return new NegatingCriteria<ItemToMatch>(to_negate);
    }

    public static IMatchAn<ItemToMatch> or<ItemToMatch>(this IMatchAn<ItemToMatch> left_side,
                                                                 IMatchAn<ItemToMatch> right_side)
    {
      return new OrCriteria<ItemToMatch>(left_side, right_side);
    }
  }
}