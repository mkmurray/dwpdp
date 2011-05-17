namespace nothinbutdotnetprep.infrastructure.filtering
{
  public delegate PropertyType PropertyAccessor<in ItemToTarget, out PropertyType>(ItemToTarget item);
}