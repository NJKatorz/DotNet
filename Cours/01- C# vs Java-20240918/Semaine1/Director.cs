using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Semaine1
{
    [Serializable]
    internal class Director:Person
    {
        private static readonly long serialVersionUID = 5952964360274024205L;
        private IList<Movie> directedMovies;

        public Director(string name, string firstname, DateTime birthDate): base(name, firstname, birthDate)
        {
            directedMovies = new List<Movie>();
        }

        public bool AddMovie(Movie movie)
        {
            if (directedMovies.Contains(movie))
                return false;

            if (movie.Director == null)
                movie.Director = this;

            directedMovies.Add(movie);

            return true;
        }

        public IEnumerator<Movie> Movies()
        {
            return directedMovies.GetEnumerator();
        }

    }
}
