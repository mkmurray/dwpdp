using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
{
  public static class DateFilteringExtensions
  {
    public static IMatchAn<ItemToFilter> greater_than<ItemToFilter>(this IProvideAccessToFilteringBehaviour<ItemToFilter,DateTime> extension_point,int year) 
    {
      return extension_point.create_using(new DateIsGreaterThanYear(year));
    }
  }
  public static class FilteringExtensions
  {
    public static IMatchAn<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
      this IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> extension_point, PropertyType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
      this IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> extension_point, params PropertyType[] values)
    {
      return create_using(extension_point, new EqualToAny<PropertyType>(values));
    }

    public static IMatchAn<ItemToFilter> create_using<ItemToFilter, PropertyType>(
      this IProvideAccessToFilteringBehaviour<ItemToFilter, PropertyType> extension_point, IMatchAn<PropertyType> criteria)
    {
      return extension_point.create_criteria_using(criteria);
    }

    public static IMatchAn<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this IProvideAccessToFilteringBehaviour<ItemToFilter,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point,new FallsInRange<PropertyType>(new ExclusiveRangeWithNoUpperBound<PropertyType>(value)));
    }

    public static IMatchAn<ItemToFilter> between<ItemToFilter,PropertyType>(this IProvideAccessToFilteringBehaviour<ItemToFilter,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point,new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
    }
  }
}