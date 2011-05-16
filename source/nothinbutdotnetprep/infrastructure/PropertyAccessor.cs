namespace nothinbutdotnetprep.infrastructure
{
  public delegate PropertyType PropertyAccessor<in ItemToTarget, out PropertyType>(ItemToTarget item);
}