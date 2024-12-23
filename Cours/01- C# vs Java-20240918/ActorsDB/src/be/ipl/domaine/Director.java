package be.ipl.domaine;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Iterator;
import java.util.List;

public class Director extends Person implements Serializable {

	private static final long serialVersionUID = 5952964360274024205L;
	private List<Movie> directedMovies;
	
	public Director(String name, String firstname, Calendar birthDate) {
		super(name, firstname, birthDate);
		directedMovies = new ArrayList<Movie>();
	}

	public boolean addMovie(Movie movie){
		
		if (directedMovies.contains(movie))
			return false;
		
		if (movie.getDirector() == null)
			movie.setDirector(this);
		
		directedMovies.add(movie);

		return true;
		
	}
	
	public Iterator<Movie> Movies(){
		return directedMovies.iterator();
	}
	
	
}
