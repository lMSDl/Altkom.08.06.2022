// See https://aka.ms/new-console-template for more information
using Database;
using Services;

Console.WriteLine("Hello, World!");


IService service = new Service(new Repository());

 void Calculate()
{
    CalculateOrbit();
    CalculateCentralPoint();
}

static void CalculateOrbit()
{
    //xxxx
    //xxxxx
    Console.WriteLine();
}

static void CalculateCentralPoint()
{
    //yyyyy
    //yyyyyy
    ///yyyyy
    Console.WriteLine();
}