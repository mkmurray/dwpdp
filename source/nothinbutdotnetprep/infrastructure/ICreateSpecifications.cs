﻿namespace nothinbutdotnetprep.infrastructure
{
  public interface ICreateSpecifications<in Item, in PropertyType>
  {
    IMatchAn<Item> equal_to(PropertyType value);
    IMatchAn<Item> equal_to_any(params PropertyType[] values);
    IMatchAn<Item> not_equal_to(PropertyType value);
  }
}