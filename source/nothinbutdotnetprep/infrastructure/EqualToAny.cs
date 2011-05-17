using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
  public class EqualToAny<T> : IMatchAn<T>
  {
    IList<T> possible_values;

    public EqualToAny(params T[] values)
    {
      this.possible_values = new List<T>(values);
    }

    public bool matches(T item)
    {
      return possible_values.Contains(item);
    }
  }
}