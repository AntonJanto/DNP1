using System;

namespace Exercise3
{
	public class Person
	{
		public string Name { get; set; }
		
		public void Introduce()
		{
			Console.WriteLine($"Hi, I am {Name} ");
		}
	}
}