package be.ipl.domaine;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Calendar;

public class Person implements Serializable {

	private static final long serialVersionUID = 1L;

	private final String name;
	private final String firstname;
	private final Calendar birthDate;
	
	public String getName() {
		return name;
	}
	
	public String getFirstname() {
		return firstname;
	}

	public String getBirthDate() {
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
		dateFormat.setTimeZone(birthDate.getTimeZone());
		return dateFormat.format(birthDate.getTime());
	}

	
	public Person(String name, String firstname, Calendar birthDate) {
		this.name = name;
		this.firstname = firstname;
		this.birthDate = birthDate;
	}

	@Override
	public String toString() {
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
		dateFormat.setTimeZone(birthDate.getTimeZone());
		return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + getBirthDate() + "]";
	}
	
	
}
