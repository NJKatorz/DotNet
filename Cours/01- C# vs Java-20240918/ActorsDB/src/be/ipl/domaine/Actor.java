package be.ipl.domaine;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Iterator;
import java.util.List;

public class Actor extends Person implements Serializable {

	private static final long serialVersionUID = 1L;
	private final int sizeInCentimeter;
	private List<Movie> movies;

	public int getSizeInCentimeter() {
		return sizeInCentimeter;
	}

	
	
	public Actor(String name, String firstname, Calendar birthDate, int sizeInCentimeter) {
		super(name, firstname, birthDate);
		this.sizeInCentimeter = sizeInCentimeter;
		movies = new ArrayList<Movie>();
	}


	@Override
	public String toString() {
		return "Actor [name = " + getName() + " firstname = " + getFirstname() + " sizeInCentimeter = " + sizeInCentimeter + " birthdate = " + getBirthDate() + "]";
	}
	
	/**
	 * 
	 * @return list of movies in which the actor has played
	 */
	public Iterator<Movie> Movies(){
		return movies.iterator();
	}
	
	/**
	 * add movie to the list of movies in which the actor has played
	 * @param movie
	 * @return false if the movie is null or already present
	 */
	public boolean addMovie(Movie movie){
		if ((movie == null) || movies.contains(movie))
			return false;
		
		if (!movie.containsActor(this))
			movie.addActor(this);

		movies.add(movie);

		return true;
	}

	public boolean containsMovie(Movie movie){
		return movies.contains(movie);
	}

	@Override
	public String getName(){
		return super.getName().toUpperCase();
	}
}
