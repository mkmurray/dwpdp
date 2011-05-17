using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class IsGreaterThan<T> : IMatchAn<T> where T : IComparable<T>
  {
    T start;

    public IsGreaterThan(T start)
    {
      this.start = start;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) > 0; 
    }
  }
}