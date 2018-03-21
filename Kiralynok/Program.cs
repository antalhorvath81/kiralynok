using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralynok
{
    // 1. feladat
    class Tábla
    {
        // 2. feladat
        private char[,] T;
        private char ÜresCella;

        // 3. feladat
        public Tábla(Char P)
        {
            T = new Char[8, 8];
            ÜresCella = P;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = ÜresCella;
                }

            }
        }

        // 5. feladat
        public void Elhelyez(int N)
        {
            Random r = new Random();
            int i,j;
            N = Math.Min(N, 64);

            while(N>0)
            {
                i = r.Next(0, 8);
                j = r.Next(0, 8);
                if (T[i,j] == ÜresCella)
                {
                    T[i, j] = 'K';
                    N--;
                }
            }
        }

        public void Fájlbaír(string filename)
        {
            StreamWriter sw = new StreamWriter(filename, true);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sw.Write(T[i, j]);
                }
                sw.WriteLine();
            }
            sw.WriteLine();
            sw.Close();
        }

        public void Megjelenít()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(T[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // 7. feladat
        public bool ÜresOszlop(int Oszlop)
        {
            if (Oszlop < 0 || Oszlop > 7) throw new IndexOutOfRangeException();

            for (int j = 0; j < 8; j++)
            {
                if (T[j, Oszlop] == 'K') return false;
            }
            return true;
        }

        public bool ÜresSor(int Sor)
        {
            if (Sor < 0 || Sor > 7) throw new IndexOutOfRangeException();

            for (int j = 0; j < 8; j++)
            {
                if (T[Sor, j] == 'K') return false;
            }
            return true;
        }

        // 8. feladat
        public int ÜresOszlopokSzáma
        {
            get
            {
                int c = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (ÜresOszlop(j) == true) c++;
                }

                return c;
            }
        }

        public int ÜresSorokSzáma
        {
            get
            {
                int c = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (ÜresSor(j) == true) c++;
                }

                return c;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            Console.WriteLine("4. feladat: Az üres tábla:");
            Tábla T = new Tábla('#');
            T.Megjelenít();

            // 6. feladat
            Console.WriteLine("6. feladat: A feltöltött tábla:");
            T.Elhelyez(8);
            T.Megjelenít();

            // 9. feladat
            Console.WriteLine("9. feladat: Üres oszlopok és sorok száma:");
            Console.WriteLine("Oszlopok: {0}", T.ÜresOszlopokSzáma);
            Console.WriteLine("Sorok: {0}", T.ÜresSorokSzáma);

            // 10. feladat
            string filename = "tablak64.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            for (int i = 0; i < 65; i++)
            {
                Tábla Z = new Tábla('*');
                Z.Elhelyez(i);
                Z.Fájlbaír(filename);
            }
            Console.ReadLine();
        }
    }
}
