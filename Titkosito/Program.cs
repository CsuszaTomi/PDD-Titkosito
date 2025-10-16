using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Titkosito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //feladat
            /*
             Közös ötleteléssel oldjátok meg a következő feladatot!
             Egy titkosító algoritmus a következőképp működik: 
                  -adott egy négyjegyű egész szám (kódszám)
                  -A kódszám jegyeit sorban felírjuk a titkosítani kívánt szöveg karakterei fölé. Minden negyedik után újrakezdjük.
                  -Minden karaktert eltolunk az abc vége felé a felette álló jeggyel.
                  -Ha az abc-ben nincs hátrébb elég jegy, akkor az abc elején folytatjuk.
                  -Írjunk függvényt, ami egy szöveget és egy számot kap és a fenti algoritmussal titkosítja a szöveget.
            */
            string abc = "aábcdeéfghiíjklmnoóöőpqrstuúüűvwxyz";
            string kulcs = "2573";
            Console.Write("Add meg a szöveget amit titkosítani szeretnél: ");
            string szoveg = Console.ReadLine();
            szoveg = szoveg.ToLower();
            List<string> szavak = new List<string>();
            szavak = szoveg.Split(' ').ToList();
            Console.WriteLine(string.Join(",", szavak));
            string titkositott = "";
            int szamvalto = 0;
            for (int i = 0; i < szavak.Count; i++)
            {
                string mostaniszo = szavak[i];
                string atirtszo = "";
                for (int j = 0; j < mostaniszo.Length; j++)
                {
                    int eltol = kulcs[szamvalto] - 48;
                    int eltoltbetu = abc.IndexOf(mostaniszo[j]) + eltol;
                    Console.WriteLine($"Betű: {mostaniszo[j]}, Kulcs: {eltol}, Eltolt: {abc[eltoltbetu % abc.Length]}");
                    szamvalto++;
                    if (szamvalto == kulcs.Length)
                    {
                        szamvalto = 0;
                    }
                    atirtszo += abc[eltoltbetu % abc.Length];
                }
                szavak[i] = atirtszo;
            }
            titkositott += szavak[0];
            for(int i = 1; i < szavak.Count; i++)
            {
                titkositott += " " + szavak[i];
            }
            Console.WriteLine(titkositott);
        }
    }
}
