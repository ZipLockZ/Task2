using System;
using System.IO;

namespace FileManager2
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterAdress();
            double fileWeight = 0;
            fileWeight = FileWeight(Datas.Adress, ref fileWeight);
            Console.WriteLine("Размер запрашиваемой директории {0} МБ", fileWeight);
        }

        static void EnterAdress()
        {
            Console.WriteLine("Введите директорию, размер которой вы хотите узнать");
            Datas.Adress = Console.ReadLine();
            if (AdressCheck(Datas.Adress))
            {
                Console.WriteLine("Адресс указан корректно, ваша папка: " + Datas.Adress);
            }
            else EnterAdress();
        }

        static bool AdressCheck(string adress)
        {
            if (Directory.Exists(adress))
                return true;
            else return false;
        }

        static double FileWeight(string adress, ref double weight)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(adress);
                DirectoryInfo[] dIinfoAdress = dInfo.GetDirectories();
                FileInfo[] fInfo = dInfo.GetFiles();

                foreach (FileInfo f in fInfo)
                    weight += f.Length;

                foreach (DirectoryInfo df in dIinfoAdress)
                    FileWeight(df.FullName, ref weight);

                return Math.Round((double)(weight / 1024 / 1024), 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
    public class Datas
    {
        private static string adress;

        public static string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
    }
}
