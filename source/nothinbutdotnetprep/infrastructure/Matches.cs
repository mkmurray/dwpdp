namespace nothinbutdotnetprep.infrastructure
{
  public delegate bool Matches<in ItemToFilter>(ItemToFilter item); 
}