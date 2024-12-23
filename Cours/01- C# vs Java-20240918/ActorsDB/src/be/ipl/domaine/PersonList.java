package be.ipl.domaine;

import java.security.InvalidParameterException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class PersonList {

	private static PersonList instance;
	private Map<String, Person> personMap;

	private PersonList(){
		personMap = new HashMap<String, Person>();
	}

	public static PersonList getInstance(){
		
		if (instance == null)
			instance = new PersonList();
		
		return instance;
	}

	public void addPerson(Person person){
		if (person == null)
			throw new InvalidParameterException();
		personMap.put(person.getName(), person);
	}
	
	public Iterator<Person> personList(){
		return personMap.values().iterator();
	}
	
}
