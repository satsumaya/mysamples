// See https://aka.ms/new-console-template for more information
using Hoge;

//using System.Net.Security;

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
    }
}
else
{
    Console.WriteLine("No arguments");
}

Console.WriteLine("Hello, World!");

Console.WriteLine(new Hello().SayHello());

//Console.ReadLine();

namespace Hoge
{
    internal class Hello
    {
        internal string SayHello()
        {
            return "Hello!";
        }
    }
}
