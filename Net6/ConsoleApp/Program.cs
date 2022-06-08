


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