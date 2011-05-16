using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Movie)
            {
                return Equals((Movie)obj);
            }

            return base.Equals(obj);
        }

        public bool Equals(Movie other)
        {
            return title == other.title;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}