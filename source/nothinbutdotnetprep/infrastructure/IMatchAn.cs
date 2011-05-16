namespace nothinbutdotnetprep.infrastructure
{
  public interface IMatchAn<in ItemToMatch>
  {
    bool matches(ItemToMatch item);
  }
}