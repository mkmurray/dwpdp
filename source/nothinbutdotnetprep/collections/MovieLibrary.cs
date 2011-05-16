using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
  public class MovieLibrary
  {
    readonly IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      foreach (var movie in movies)
      {
        if (movie.production_studio != ProductionStudio.Pixar)
        {
          yield return movie;
        }
      }
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      foreach (var movie in movies)
      {
        if (movie.date_published.Year.CompareTo(year) > 0)
        {
          yield return movie;
        }
      }
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      foreach (var movie in movies)
      {
        if (movie.date_published.Year.CompareTo(startingYear) >= 0 &&
          movie.date_published.Year.CompareTo(endingYear) <= 0)
        {
          yield return movie;
        }
      }
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      foreach (var movie in movies)
      {
        if (movie.genre == Genre.kids)
        {
          yield return movie;
        }
      }
    }

    public IEnumerable<Movie> all_action_movies()
    {
      foreach (var movie in movies)
      {
        if (movie.genre == Genre.action)
        {
          yield return movie;
        }
      }
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      return sortBy((x, y) => x.date_published.CompareTo(y.date_published)*-1);
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      return sortBy((x, y) => x.date_published.CompareTo(y.date_published));
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending
    {
      get { return sortBy((x, y) => x.title.CompareTo(y.title)*-1); }
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending
    {
      get { return sortBy((x, y) => x.title.CompareTo(y.title)); }
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      var rankings =
        new[]
        {
          ProductionStudio.MGM,
          ProductionStudio.Pixar,
          ProductionStudio.Dreamworks,
          ProductionStudio.Universal,
          ProductionStudio.Disney,
          ProductionStudio.Paramount,
        };

      Func<ProductionStudio, int> indexOf = x =>
      {
        for (var i = 0; i < rankings.Length; i++)
        {
          if (rankings[i] == x)
          {
            return i;
          }
        }
        return -1;
      };

      Comparison<ProductionStudio> studioRankings = (x, y) => { return indexOf(x).CompareTo(indexOf(y)); };

      return sortBy(
        (x, y) => studioRankings(x.production_studio, y.production_studio),
        (x, y) => x.date_published.Year.CompareTo(y.date_published.Year)
        );
    }

    IEnumerable<Movie> sortBy(params Comparison<Movie>[] comparison)
    {
      var list = new List<Movie>(movies);

      Comparison<Movie> comparer = (x, y) =>
      {
        for (var i = 0; i < comparison.Length; i++)
        {
          var result = comparison[i](x, y);
          if (result != 0)
          {
            return result;
          }
        }
        return 0;
      };

      list.Sort(comparer);

      foreach (var movie in list)
      {
        yield return movie;
      }
    }
  }
}