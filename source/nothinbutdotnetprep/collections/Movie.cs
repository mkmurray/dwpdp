using System;

namespace nothinbutdotnetprep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public override int GetHashCode()
    {
      return title.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("{0} - {1}", title, nameOfProductionStudio());
    }

    string nameOfProductionStudio()
    {
      if (production_studio == ProductionStudio.MGM)
      {
        return "MGM";
      }
      if (production_studio == ProductionStudio.Disney)
      {
        return "Disney";
      }
      if (production_studio == ProductionStudio.Dreamworks)
      {
        return "Dreamworks";
      }
      if (production_studio == ProductionStudio.Paramount)
      {
        return "Paramount";
      }
      if (production_studio == ProductionStudio.Pixar)
      {
        return "Pixar";
      }
      if (production_studio == ProductionStudio.Universal)
      {
        return "Universal";
      }
      return "Unknown";
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public bool Equals(Movie other)
    {
      if (other == null) return false;

      return ReferenceEquals(null, other) || is_equal_to_non_null_instance_of(other);
    }

    bool is_equal_to_non_null_instance_of(Movie other)
    {
      return Equals(other.title, title);
    }
  }
}