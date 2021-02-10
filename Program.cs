using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace l.r._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] directiry = Directory.GetFiles(@"C:\textLaba4");
            List<int> num = new List<int>();
            int p = 0;
            for (int i = 10; i < 30; i++)
            {
                string filename = i + ".txt"; 
                string path = @"C:\textLaba4\" + i + ".txt";
                FileInfo fileinfo = new FileInfo(path);
                string[] array = fileinfo.Name.Split(".");
                string prob = array[0];
                try
                {
                    int[] arr = ReadAllInfo(path);
                    int e = (TryFindProduct(arr, path));
                    if(e!=0)
                    {
                        p += 1;
                    }
                    num.Add(e);
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\textLaba4\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        sw.Write(i + ".txt" + "\n");
                        continue;
                    }
                }
            }
            int sum = 0;
            foreach (int n in num)
            {
                try
                {
                    sum = checked(sum + n);
                }
                catch (Exception ex)
                {
                    sum = (int)sum;
                }
            }
            Console.WriteLine("Сума всiх добуткiв - {0}", sum);
            Console.WriteLine("Середнє арифметичне - {0}", sum / p);
            /*
             * Завдання 2
            */
            Task_2.Task(@"C:\textlaba3", @"C:\");
        }
        public static int[] ReadAllInfo(string directiry)
        {
            string[] inform = File.ReadAllLines(directiry);
            int[] array = new int[2];

            int len = inform.Length;
            if (inform.Length > 2) // если в файле больше 2-х чисел
            {
                using (StreamWriter sw = new StreamWriter(@"C:\textLaba4\bad_data.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                    return array;
                } 
            }
            try
            {
                array[0] = int.Parse(inform[0]);
                array[1] = int.Parse(inform[1]);
            }
            catch (Exception exp) // не удалось прочитать
            {
                using (StreamWriter sw = new StreamWriter(@"C:\textLaba4\bad_data.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                }
            }
            return array;
        } //чтение файлов тхт
        public static int TryFindProduct(int[] array, string directiry)
        {
            int result = 0;
            try
            {
                result = checked((int)(array[0] * array[1]));
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\textLaba4\overflow.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                    return 0;
                }
            }

            return (array[0]) * array[1];
        } // добутки чисел


    }
}

