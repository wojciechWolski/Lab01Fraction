using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Fraction
{
    public class Ułamek : IEquatable<Ułamek>, IComparable<Ułamek>
    {
        //pola
        private int licznik;
        private int mianownik;

        //konstruktory
        public Ułamek()
        {
            Licznik = 1;
            Mianownik = 1;
        }

        public Ułamek(int licznik, int mianownik)
        {
            int dzielnik = gcd(licznik, mianownik);
            Licznik = licznik / dzielnik;
            Mianownik = mianownik / dzielnik;
        }

        public Ułamek(int licznik)
        {
            Licznik = licznik;
            Mianownik = 1;
        }

        //właściwości
        public int Mianownik { get; }
        public int Licznik { get; }


        //metody
        public override string ToString()
        {
            return $"{Licznik}/{Mianownik}";
        }
        
        public static int gcd (int licznik, int mianownik)
        {
            while (licznik != mianownik)
            {
                if (licznik > mianownik)
                {
                    licznik -= mianownik;
                }
                else
                {
                    mianownik -= licznik;
                }
            }
            return licznik;
            
        }

        public bool Equals(Ułamek other)
        {

            if (Licznik == 0 && Mianownik == 0 || other.Licznik == 0 && other.Mianownik == 0)
                return false;
            if (Licznik == other.Licznik && Mianownik == other.Mianownik)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Licznik, Mianownik);
        }

        public int CompareTo(Ułamek other)
        {
            if (Licznik / Mianownik == other.Licznik / other.Mianownik)
                return 0;
            else if (Licznik / Mianownik > other.Licznik / other.Mianownik)
                return 1;
            else
                return -1;
        }

        public double FractionRound(Ułamek ułamek, int x)
        {
            double toRound = (double)ułamek;
            double result = Math.Round(toRound, x);
            return result;
        }





        //przeciążanie operatorów
        public static Ułamek operator +(Ułamek lewy, Ułamek prawy)
        {
            return new Ułamek(lewy.Licznik * prawy.Mianownik + prawy.Licznik * lewy.Mianownik, lewy.Mianownik * prawy.Mianownik);
        }

        public static Ułamek operator -(Ułamek lewy, Ułamek prawy)
        {
            return new Ułamek(lewy.Licznik * prawy.Mianownik - lewy.Mianownik * prawy.Licznik, lewy.Mianownik * prawy.Mianownik);
        }

        public static Ułamek operator *(Ułamek lewy, Ułamek prawy)
        {
            return new Ułamek(lewy.Licznik * prawy.Licznik, lewy.Mianownik * prawy.Mianownik);
        }

        public static Ułamek operator /(Ułamek lewy, Ułamek prawy)
        {
            if (prawy.licznik == 0)
            {
                throw new DivideByZeroException();
            }
            return new Ułamek(lewy.Licznik * prawy.Mianownik, lewy.Mianownik * prawy.Licznik);
        }
        
        //konwersja na double
        static public explicit operator double(Ułamek ułamek)
        {
            double wynik = (double)ułamek.Licznik / (double)ułamek.Mianownik;
            return wynik;
        }

    }
}
