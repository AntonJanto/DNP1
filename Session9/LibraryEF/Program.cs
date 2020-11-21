using System;

Console.WriteLine("Hello World!");
Name name1 = new ( "Anton", "Janto" );
Console.WriteLine(name1);

public record Name(string FirstName, string LastName)
{
    public string FullName { get => $"{ FirstName } { LastName }"; }
}
