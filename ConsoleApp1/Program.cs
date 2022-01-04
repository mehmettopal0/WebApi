using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var people = new List<Person>()
{
new Person("Bill", "Smith", 41),
new Person("Sarah", "Jones", 22),
new Person("Stacy","Baker", 21),
new Person("Vivianne","Dexter", 19 ),
new Person("Bob","Smith", 49 ),
new Person("Brett","Baker", 51 ),
new Person("Mark","Parker", 19),
new Person("Alice","Thompson", 18),
new Person("Evelyn","Thompson", 58 ),
new Person("Mort","Martin", 58),
new Person("Eugene","deLauter", 84 ),
new Person("Gail","Dawson", 19 ),

};

        //write linq statement for people with last name that starts with the letter D
        var people1 = people.Where(x => x.LastName.StartsWith("S")).ToList();
        //from c in people where c.LastName.StartsWith("D") select c;
        foreach (var pp in people1)
        {
            Console.WriteLine("isim soyisim: {0} {1}", pp.FirstName, pp.LastName);
        }
        Console.WriteLine("Number of people who's last name starts with the letter D = " + people1.Count());

        //Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
        var person2 = people.Where(x => x.Age > 40).OrderByDescending(x=>x.FirstName);
        //from c in people where c.Age>40 orderby c.FirstName descending select c;

        foreach (var pp in person2)
        {
            Console.WriteLine("isim soyisim: {0} {1}", pp.FirstName, pp.LastName);
        }

    }

    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //override ToString to return the person's FirstName LastName Age
    }
}
