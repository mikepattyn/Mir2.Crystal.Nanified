// See https://aka.ms/new-console-template for more information

using Persistance.Domain;
using System.Reflection;

Console.WriteLine("Hello, World!");

Console.WriteLine(Headers(typeof(DomainAccount)));
Console.ReadLine();

string Headers(Type type)
{
    return type.GetFields().ToString();
}