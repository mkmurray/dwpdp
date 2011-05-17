using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public class DateIsGreaterThanYear : IMatchAn<DateTime>
  {
    int year;

    public DateIsGreaterThanYear(int year)
    {
      this.year = year;
    }

    public bool matches(DateTime item)
    {
      return item.Year > year;
    }
  }
}