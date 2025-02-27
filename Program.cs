using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamf2025_02_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladatok();
            Console.ReadLine();
        }

        static void Feladatok()
        {
            List<List<int>> matrix = new List<List<int>>();
            int megoldasA = 0;
            using (StreamReader sr = new StreamReader("terkep.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    List<int> szamsor = new List<int>();
                    for (global::System.Int32 i = 0; i < line.Length - 1; i++)
                    {

                        szamsor.Add(int.Parse(line[i]));
                    }
                    matrix.Add(szamsor);
                }
            }
            //Első feladat
            for (int i = 0; i < matrix[0].Count; i++)
            {
                for (int j = 0; j < matrix[1].Count; j++)
                {
                    if (matrix[i][j] == 21)
                    {
                        megoldasA++;
                    }
                    Console.Write(matrix[i][j] + " \t ");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("Első megoldás: " + megoldasA);


            //Máasodik, Harmadik feladat

            
            Vizfolyas(matrix);
            

        }

        static void Vizfolyas(List<List<int>> matrix)
        {
            int megoldasB = 7;
            int megoldasC = 0;
            int sorok = matrix.Count;
            int oszlopok = matrix[0].Count;
            bool[,] voltemar = new bool[sorok, oszlopok];

            void Folyas(int sor, int oszlop)
            {
                if (voltemar[sor, oszlop] == true) return;
                voltemar[sor, oszlop] = true;

                

                int[] sorirany = { -1, 1, 0, 0 };//fel le
                int[] oszlopirany = { 0, 0, -1, 1 };//balra jobbra

                for (int i = 0; i < 4; i++)
                {
                    int ujsor = sor + sorirany[i];
                    int ujoszlop = oszlop + oszlopirany[i];

                    if (ujsor >=0 && ujsor<sorok && ujoszlop >=0 && ujoszlop < oszlopok)
                    {
                        if (!voltemar[ujsor,ujoszlop] && matrix[ujsor][ujoszlop] < matrix[sor][oszlop])
                        {
                            Console.WriteLine(matrix[sor][oszlop] + " a " + sor + " sor " + oszlop + " oszlopnál nagyobb mint " + matrix[ujsor][ujoszlop] + " a " + ujsor + " sor " + ujoszlop + " oszlopnál");
                            if (matrix[ujsor][ujoszlop] < 10)
                            {
                                megoldasC++;
                            }
                            megoldasB++;
                            Folyas(ujsor, ujoszlop);
                        }
                    }
                }
            }

            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {

                    if (matrix[i][j] == 21)
                    {
                        Folyas(i, j);
                    }
                }
                Console.WriteLine("Megoldás B: "+ megoldasB + " Megoldás C:" + megoldasC);
            }
            
        }

    }
}
