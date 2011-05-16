using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
            {
                movies.Add(movie);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { return movies_sort(x => x.title, (x, y) => y.CompareTo(x)); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return movies_filtered(x => x.production_studio, (filterList, item) => filterList.Contains(item), new List<ProductionStudio> {ProductionStudio.Pixar});
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return movies_filtered(x => x.production_studio, (filterList, item) => filterList.Contains(item), new List<ProductionStudio> {ProductionStudio.Pixar, ProductionStudio.Disney});
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { return movies_sort(x => x.title, (x, y) => x.CompareTo(y)); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var movieList = (List<Movie>) movies;
            movieList.Sort((x, y) =>
            {
                var studios_compare = x.production_studio.GetRank().CompareTo(y.production_studio.GetRank());

                if (studios_compare == 0)
                {
                    return x.date_published.Year.CompareTo(y.date_published.Year);
                }

                return studios_compare;
            });

            foreach (var movie in movieList)
            {
                yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return movies_filtered(x => x.production_studio, (filterList, item) => !filterList.Contains(item), new List<ProductionStudio> {ProductionStudio.Pixar});
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (startingYear <= movie.date_published.Year && movie.date_published.Year <= endingYear)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return movies_filtered(x => x.genre, (filterList, item) => filterList.Contains(item), new List<Genre> {Genre.kids});
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return movies_filtered(x => x.genre, (filterList, item) => filterList.Contains(item), new List<Genre> {Genre.action});
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return movies_sort(x => x.date_published, (x, y) => y.CompareTo(x));
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return movies_sort(x => x.date_published, (x, y) => x.CompareTo(y));
        }

        private IEnumerable<Movie> movies_filtered<T>(Func<Movie, T> selector, Func<IList<T>, T, bool> test, IList<T> filter)
        {
            foreach (var movie in movies)
            {
                if (test(filter, selector(movie)))
                {
                    yield return movie;
                }
            }
        }

        private IEnumerable<Movie> movies_sort<T>(Func<Movie, T> selector, Func<T, T, int> test)
        {
            var movieList = (List<Movie>) movies;
            movieList.Sort((x, y) => test(selector(x), selector(y)));

            foreach (var movie in movieList)
            {
                yield return movie;
            }
        }
    }
}