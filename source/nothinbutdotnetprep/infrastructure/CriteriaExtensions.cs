namespace nothinbutdotnetprep.infrastructure
{
  public static class CriteriaExtensions
  {
    public static IMatchAn<ItemToMatch> or<ItemToMatch>(this IMatchAn<ItemToMatch> left_side,
                                                                 IMatchAn<ItemToMatch> right_side)
    {
      return new OrCriteria<ItemToMatch>(left_side, right_side);
    }

    public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
      this PropertyAccessor<ItemToMatch, PropertyType> accessor, PropertyType value)
    {
      return new AnonymousCriteria<ItemToMatch>(x => accessor(x).Equals(value));
    }
  }
}