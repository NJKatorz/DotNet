package be.ipl.domaine;

import java.util.ArrayList;
import java.util.List;

public class Movie {

	private String title;
	private int releaseYear;
	private List<Actor> actors;
	private Director director;
	
	public Movie(String title, int releaseYear) {
		actors = new ArrayList<Actor>();
		this.title = title;
		this.releaseYear = releaseYear;
	}

	public Director getDirector() {
		return director;
	}
	public void setDirector(Director director) {
		if (director == null)
			return;
		this.director = director;
		director.addMovie(this);
	}

	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public int getReleaseYear() {
		return releaseYear;
	}
	public void setReleaseYear(int releaseYear) {
		this.releaseYear = releaseYear;
	}

	public boolean addActor(Actor actor){
		if (actors.contains(actor))
			return false;

		actors.add(actor);
		if (!actor.containsMovie(this))
			actor.addMovie(this);
		
		return true;
	}

	public boolean containsActor(Actor actor){
		return actors.contains(actor);
	}

	@Override
	public String toString() {
		return "Movie [title=" + title + ", releaseYear=" + releaseYear + "]";
	}
	
	
	
}
