using System;

class Program
{
    public static void Main(string[] args)
    {
      Controller system = new Controller(new View(), new Repository());  
      system.Start();  
    }
}