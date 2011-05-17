using System;

namespace nothinbutdotnetprep.infrastructure
{
  public class IsBetween<T> : IMatchAn<T> where T : IComparable<T>
  {
    T end;
    T start;

    public IsBetween(T start, T end)
    {
      this.start = start;
      this.end = end;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }
}