using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
  public class FixedOrderComparer<PropertyToSortBy> : IComparer<PropertyToSortBy>
  {
    IList<PropertyToSortBy> order;

    public FixedOrderComparer(params PropertyToSortBy[] order)
    {
      this.order = new List<PropertyToSortBy>(order);
    }

    public int Compare(PropertyToSortBy x, PropertyToSortBy y)
    {
      return order.IndexOf(x).CompareTo(order.IndexOf(y));
    }
  }
}