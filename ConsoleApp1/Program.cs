using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

public class Program
{
    //    public static void Main()
    //    {
    //        var people = new List<Person>()
    //{
    //new Person("Bill", "Smith", 41),
    //new Person("Sarah", "Jones", 22),
    //new Person("Stacy","Baker", 21),
    //new Person("Vivianne","Dexter", 19 ),
    //new Person("Bob","Smith", 49 ),
    //new Person("Brett","Baker", 51 ),
    //new Person("Mark","Parker", 19),
    //new Person("Alice","Thompson", 18),
    //new Person("Evelyn","Thompson", 58 ),
    //new Person("Mort","Martin", 58),
    //new Person("Eugene","deLauter", 84 ),
    //new Person("Gail","Dawson", 19 ),

    //};

    //        //write linq statement for people with last name that starts with the letter D
    //        var people1 = people.Where(x => x.LastName.StartsWith("S")).ToList();
    //        //from c in people where c.LastName.StartsWith("D") select c;
    //        foreach (var pp in people1)
    //        {
    //            Console.WriteLine("isim soyisim: {0} {1}", pp.FirstName, pp.LastName);
    //        }
    //        Console.WriteLine("Number of people who's last name starts with the letter D = " + people1.Count());

    //        //Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
    //        var person2 = people.Where(x => x.Age > 40).OrderByDescending(x=>x.FirstName);
    //        //from c in people where c.Age>40 orderby c.FirstName descending select c;

    //        foreach (var pp in person2)
    //        {
    //            Console.WriteLine("isim soyisim: {0} {1}", pp.FirstName, pp.LastName);
    //        }

    //    }

    //    public class Person
    //    {
    //        public Person(string firstName, string lastName, int age)
    //        {
    //            FirstName = firstName;
    //            LastName = lastName;
    //            Age = age;
    //        }

    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public int Age { get; set; }

    //        //override ToString to return the person's FirstName LastName Age
    //    }





    static long totalNum = 0;
    static void Main(string[] args)
    {

        Dictionary<char, int> keyValues = new Dictionary<char, int>();
        keyValues.Add('H', 4);
        keyValues.Add('e', 8);
        keyValues.Add('l', 16);
        keyValues.Add('o', 32);
        keyValues.Add('W', 2);
        keyValues.Add('r', 1);
        keyValues.Add('d', 0);
        string keyString = "HelloWorld";
        var startIndex = 0;
        var endIndex = 999999;



        Stopwatch watch = new Stopwatch();
        watch.Start();
        Task task1 = Task.Factory.StartNew(() => Total(startIndex, endIndex - 666666, keyString, keyValues));
        Task task2 = Task.Factory.StartNew(() => Total(startIndex + 333334, endIndex - 333333, keyString, keyValues));
        Task task3 = Task.Factory.StartNew(() => Total(startIndex + 666664, endIndex, keyString, keyValues));
        Task.WaitAll(task1, task2,task3);
        watch.Stop();
        Console.WriteLine(totalNum);
        Console.WriteLine(watch.Elapsed.Seconds);
    }



    private static void Total(int startIndex, int endIndex, string keyString, Dictionary<char, int> keyValues)
    {
        long total = 0;

        for (var i = startIndex; i < endIndex; i++)
        {
            var random = DateTime.Now.Millisecond;
            for (var j = random; j > 0; j--)
            {
                var keyChar = keyString[i % 9];
                var keyValue = keyValues[keyChar];
                if (i % 2 == 0)
                {
                    total += (i * (i + 1)) / 2 * keyValue;
                }
                else
                {
                    total += (i * (i + 1)) * keyValue;
                }
            }
        }
        totalNum += total;
        //Parallel.For (startIndex, endIndex, startIndex =>
        //{
        //    var random = DateTime.Now.Millisecond;
        //    for (var j = random; j > 0; j--)
        //    {
        //        var keyChar = keyString[startIndex % 9];
        //        var keyValue = keyValues[keyChar];
        //        if (startIndex % 2 == 0)
        //        {
        //            total += (startIndex * (startIndex + 1)) / 2 * keyValue;
        //        }
        //        else
        //        {
        //            total += (startIndex * (startIndex + 1)) * keyValue;
        //        }
        //    }
        //}) ;
        //  totalNum += total;




    }

}
