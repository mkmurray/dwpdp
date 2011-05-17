namespace nothinbutdotnetprep.infrastructure.filtering
{
  public interface IMatchAn<in ItemToMatch>
  {
    bool matches(ItemToMatch item);
  }
}