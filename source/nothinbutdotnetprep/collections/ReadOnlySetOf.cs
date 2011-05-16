using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
  public class ReadOnlySetOf<T> : IEnumerable<T>
  {
    IList<T> items;

    public ReadOnlySetOf(IList<T> items)
    {
      this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}