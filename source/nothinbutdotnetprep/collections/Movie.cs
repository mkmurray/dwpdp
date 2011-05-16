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
            return obj is Movie && Equals((Movie) obj);
        }

        public bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            return Equals(other.title, title) && Equals(other.production_studio, production_studio) && Equals(other.genre, genre) && other.rating == rating && other.date_published.Equals(date_published);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (title != null ? title.GetHashCode() : 0);
                result = (result*397) ^ (production_studio != null ? production_studio.GetHashCode() : 0);
                result = (result*397) ^ (genre != null ? genre.GetHashCode() : 0);
                result = (result*397) ^ rating;
                result = (result*397) ^ date_published.GetHashCode();
                return result;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", title, nameOfProductionStudio());
        }

        private string nameOfProductionStudio()
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
    }
}