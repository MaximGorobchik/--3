using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Person
{
    public string name;
    public int age;
    public Person()
    {
        name = "No name";
        age = 1;
    }
    public Person(int x)
    {
        name = "No name";
        age = x;
    }
    public Person(string x, int y)
    {
        name = x;
        age = y;
    }
    public void print()
    {
        Console.WriteLine("Your name is: " + name);
        Console.WriteLine("Your age is: " + age);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("Maxim", 18);
        person.print();
    }
}
