using System;

namespace Lab01Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Ułamek u = new Ułamek(5, 7);
            Console.WriteLine(u);
            Ułamek ad = new Ułamek(36, 6);
            Console.WriteLine(ad);
            Ułamek half = new Ułamek(1, 2);
            Console.WriteLine(u.CompareTo(half));
            Console.WriteLine(u.FractionRound(u, 1));
            Console.WriteLine((double)half);
        }
    }
}
