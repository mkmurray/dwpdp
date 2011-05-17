namespace nothinbutdotnetprep.infrastructure.filtering
{
  public delegate bool Matches<in ItemToFilter>(ItemToFilter item); 
}