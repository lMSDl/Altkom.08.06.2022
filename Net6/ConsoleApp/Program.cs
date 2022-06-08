


//public class Program {

//    public static void Main(string[] args)
//    {
global using Newtonsoft.Json.Converters;
using ConsoleApp;

//using Newtonsoft.Json;
using System;

ShowText();

Class? myClass = CreateClass();

if (myClass != null)
{
    myClass.Name = "name";
    //myClass.Name = null;

    myClass.Value = 1;
    //myClass.Value = null;
}

Console.WriteLine(myClass!.Name); // ! - biorę odpowiedzialność, że zmienna nie jest null


//myClass = null;

Console.WriteLine(myClass.Name);




var person1 = new Person("Ewa") { LastName = "Ewowska" };
//person1.FirstName = "Ewa";
//person1.LastName = "Ewowska";
person1.SomeClass = new Class();

//var person2 = new Person("Ewa") { LastName = "Ewowska" };
//person2.FirstName = "Ewa";
//person2.LastName = "Ewowska";
var person2 = person1 with { }; 
//person2.SomeClass = new Class();

//var person3 = new Person("Monika") { LastName = "Ewowska" };
var person3 = person1 with { FirstName = "Monika" };
//person3.FirstName = "Monika";
//person3.LastName = "Ewowska";

Console.WriteLine($"{person1} vs {person2} = {person1 == person2}");
Console.WriteLine($"reference {person1} vs {person2} = {ReferenceEquals(person1, person2)}");
Console.WriteLine($"{person1} vs {person3} = {person1 == person3}");


void ShowText()
{
    JsonConvert.SerializeObject(new Class());
    var binaryConverter = new BinaryConverter();


    Console.WriteLine("Hello, World!");
}

static Class? CreateClass()
{
    return new();
}

//    }    
//}