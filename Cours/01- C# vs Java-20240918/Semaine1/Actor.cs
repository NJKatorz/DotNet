using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Semaine1
{
    [Serializable]
    internal class Actor:Person
    {
        private static readonly long _serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        private IList<Movie> _movies;

        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter): base(name, firstname, birthDate)
        {            
            _sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie>();
        }


        public int SizeInCentimeter
        {
            get { return _sizeInCentimeter; }
        }  
        
        public override string ToString()
        {
            return $"Actor [name = {Name} firstname = {FirstName} sizeInCentimeter = {_sizeInCentimeter} birthdate = {BirthDate}]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerator<Movie> Movies()
        {
            return _movies.GetEnumerator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool AddMovie(Movie movie)
        {
            if ((movie == null) || _movies.Contains(movie))
                return false;

            if (!movie.ContainsActor(this))
                movie.AddActor(this);
            _movies.Add(movie);

            return true;
        }

        public bool ContainsMovie(Movie movie)
        {
            return _movies.Contains(movie);
        }

        
        public override string Name
        {
           get { return base.Name.ToUpper(); }
        }

    }
}
