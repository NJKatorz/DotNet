using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Semaine1
{
    internal class Movie
    {
        private string title;
        private int releaseYear;
        private IList<Actor> actors;
        private Director director;

        public Movie(string title, int releaseYear)
        {
            actors = new List<Actor>();
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Director Director
        {
            get {  return director; }
            set { 
                if (value == null)
                    return;
                director = value;
                director.AddMovie(this);
            }
        }
        

        public string Title
        {
            get{ return title; }
            set { title = value; }
        }
        
        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }


        public bool AddActor(Actor actor)
        {
            if (actors.Contains(actor))
                return false;

            actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        {
            return actors.Contains(actor);
        }

        
        public override string ToString()
        {
            return $"Movie [title= {title}, releaseYear= {releaseYear}]";
        }


    }
}
