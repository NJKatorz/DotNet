package be.ipl.client;
import java.io.PrintStream;
import java.io.UnsupportedEncodingException;
import java.util.GregorianCalendar;
import java.util.Iterator;

import be.ipl.domaine.*;
public class Test {


    public static void main(String[] args) {

        Actor [] myActors =  {
                new Actor( "Assange", "Julian", new GregorianCalendar(1961, 6, 3), 187),
                new Actor( "Paul", "Newmann", new GregorianCalendar(1925, 0, 26), 187),
                new Actor( "Becker", "Norma Jean", new GregorianCalendar(1926, 5, 1), 187)
        };

        Director [] myDirectors = {
                // month start 0
                new Director("Spielberg", "Steven", new GregorianCalendar(1946, 11, 18)),
                new Director("Coen", "Ettan", new GregorianCalendar(1957, 8, 21)),
                new Director("Coppolla", "Francis Ford", new GregorianCalendar(1939, 3, 7))
        };
        

        Movie bigLebow = new Movie("The Big Lebowski", 1996);
        Movie eT = new Movie("E.T.", 1982);

        eT.addActor(myActors[0]);
        eT.addActor(myActors[2]);
        eT.setDirector(myDirectors[0]);

        bigLebow.addActor(myActors[1]);
        bigLebow.addActor(myActors[2]);
        bigLebow.setDirector(myDirectors[1]);

        PersonList myPersons = PersonList.getInstance();

        for( Actor act : myActors){
            myPersons.addPerson(act);
        }

        for (Director director : myDirectors){
            myPersons.addPerson(director);
        }

        Iterator<Person> ActorIt = myPersons.personList();
        while( ActorIt.hasNext()){
            Person person = ActorIt.next();
            System.out.println(person);

            Iterator<Movie> MoviesIt;
            if (person instanceof Actor) {
                System.out.println("a jouÃ© dans les films suivants ");
                MoviesIt = ((Actor)person).Movies();
            }
            else {
                if (person instanceof Director) {
                    System.out.println("a dirigÃ© les films suivants :");
                    MoviesIt = ((Director)person).Movies();
                }
                else {
                    System.out.println("est inconnu et n'a rien Ã  faire ici !!! ");
                    continue;
                }
            }
            while (MoviesIt.hasNext()){
                Movie Movie = MoviesIt.next();
                System.out.println(Movie);
            }

        }
    }



}
