#Rules for equality checking in .Net


#Is it a class?(Reference type)

  1. Does it implement IEquatable<T> for itself - use it
  2. Does it override Equals - use it
  3. Reference equality check


#Is it a struct?(Value type)

  1. Does it override Equals - use it
  2. Reflective field by field equality check
