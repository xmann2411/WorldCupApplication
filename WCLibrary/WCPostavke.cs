using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCLibrary
{
    public static class WCPostavke
    {
        private static string PostavkeFile = "../../../WindowsFormsApp/bin/debug/postavke.txt";

        public static bool DatotekaPostoji()
        {
            return File.Exists(PostavkeFile);
        }

        public static bool DatotekaPostoji(string datoteka)
        {
            return File.Exists(datoteka);
        }

        public static List<string> UcitajPostavke()
        {
            using (StreamReader citac = new StreamReader(PostavkeFile))
            {
                List<string> postavke = new List<string>();
                while (!citac.EndOfStream)
                {
                    postavke.Add(citac.ReadLine());

                }
                return postavke;
            }
        }

        public static void SpremiPostavke(List<string> postavke)
        {
            using (StreamWriter writer = new StreamWriter(PostavkeFile))
            {
                foreach (var item in postavke)
                {
                    writer.WriteLine(item);
                }
            }
        }


    }
}
