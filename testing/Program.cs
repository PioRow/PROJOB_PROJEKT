using System;

namespace testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abcd";
            s=s.Insert(0, "\n");
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
