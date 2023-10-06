/** -----The Sorts-----
 * bubble, selection, insertion, quick, merge
 * @braydenHanna
 * @11/15/22
 */
using System;
using System.Diagnostics;
using System.IO;

namespace TheSorts
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Calibration
            Console.BufferWidth = 1000;
            Console.BufferHeight = 1000;
            Console.WriteLine("Calibrating...");
            int[] calibrate = randomIntArray(10000);
            runAllSorts(calibrate, 0, 2, "12345", 1);
            StreamReader cReader = new StreamReader("words.txt");
            string[] calibrateWords = new string[1000];
            for (int i = 0; i < calibrateWords.Length; i++)
            {
                calibrateWords[i] = cReader.ReadLine();
            }
            cReader.Close();
            runAllSorts(calibrateWords, 0, 2, "12345", 1);
            Console.Clear();
            #endregion Calibration

            char again = 'Y';
            while (again.Equals('Y')){
                Console.Clear();

                Console.WriteLine("----Info----\nThis program modularly times and compares sorting algorithms\n");

                Console.WriteLine("----Configuration----");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(#1)");
                Console.ResetColor();
                Console.Write(" Which algorithm(s) you would like to test? (Ex. Quick and Merge | 45 OR 54 OR 4,5 OR 4 5)\n1: Bubble 2: Insertion 3: Selection 4: Quick 5: Merge\nEnter: ");
                string sortCode = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(#2)");
                Console.ResetColor();
                Console.Write(" What unit you would like to use?\n1: Ticks 2: Nanoseconds 3: Milliseconds 4: Seconds\nEnter: ");
                double unit = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(#3)");
                Console.ResetColor();
                Console.Write(" What would you like to sort? 1: Ints 2: Strings \nEnter: ");
                string data = Console.ReadLine();
                int numArrs = 0;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(#4)");
                Console.ResetColor();
                Console.Write(" How many tests do you want to do?: ");
                numArrs = Convert.ToInt32(Console.ReadLine());

                Console.SetCursorPosition(0, numArrs + 17);
                int h = 0;

                if (sortCode.ToString().Contains("1"))
                {
                    Console.SetCursorPosition(0, numArrs + 18 + h++);
                    Console.Write("Bubble\n");
                }
                if (sortCode.ToString().Contains("2"))
                {
                    Console.SetCursorPosition(0, numArrs + 18 + h++);
                    Console.Write("Insertion\n");
                }
                if (sortCode.ToString().Contains("3"))
                {
                    Console.SetCursorPosition(0, numArrs + 18 + h++);
                    Console.Write("Selection\n");
                }
                if (sortCode.ToString().Contains("4"))
                {
                    Console.SetCursorPosition(0, numArrs + 18 + h++);
                    Console.Write("Quick\n");
                }
                if (sortCode.ToString().Contains("5"))
                {
                    Console.SetCursorPosition(0, numArrs + 18 + h++);
                    Console.Write("Merge\n");
                }

                if (data == "2")
                {
                    for (int i = 1; i <= numArrs; i++)
                    {
                        Console.SetCursorPosition(0, i + 14);
                        Console.Write("# of strings in array #{0} (MAX: 1500000): ", i);
                        int numWords = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(i * 16, numArrs + 17);
                        Console.Write(numWords);
                        string[] arr = new string[numWords];
                        StreamReader reader = new StreamReader("words.txt");
                        for (int f = 0; f < numWords; f++)
                        {
                            arr[f] = reader.ReadLine();
                        }
                        reader.Close();
                        runAllSorts(arr, i * 16, numArrs + 18, sortCode, unit);
                    }
                }
                else
                {
                    for (int i = 1; i <= numArrs; i++)
                    {

                        Console.SetCursorPosition(0, i + 14);
                        Console.Write("# of ints in array #{0}: ", i);
                        int numInts = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(i * 16, numArrs + 17);
                        Console.Write(numInts);
                        int[] arr = new int[numInts];
                        arr = randomIntArray(numInts);
                        runAllSorts(arr, i * 16, numArrs + 18, sortCode, unit);
                    }
                }

                Console.ResetColor();
                Console.SetCursorPosition(0, numArrs +h+ 19);
                Console.Write("Would you like to continue sorting (Y/N): ");
                again = Convert.ToChar(Console.ReadLine().ToUpper());
            }
        }
        static int[] randomIntArray(int num)
        {
            Random r = new Random();
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                arr[i] = r.Next(999);
            }
            return arr;
        }
        public static void runAllSorts(int[] arr, int x, int y, string sortCode, double unit)
        {
            int[] times = new int[sortCode.Length];
            int time;
            int count = 0;

            int sortCount = 0;

            string unitText = "";
            switch (unit)
            {
                case 1:
                    unitText = " ticks";
                    break;
                case 2:
                    unitText = " ns";
                    unit = 0.01;
                    break;
                case 3:
                    unitText = " ms";
                    unit = 10000;
                    break;
                case 4:
                    unitText = " s";
                    unit = 10000000;
                    break;
                default:
                    unitText = " ticks";
                    break;
            }


            Sort s = new Sort();

            if (sortCode.ToString().Contains("1"))
            {
                Console.SetCursorPosition(x, y);
                time = s.Bubble(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("2"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.Insertion(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("3"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.Selection(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("4"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.QuickTimed(arr, 0, arr.Length - 1);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("5"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.MergeTimed(arr, 0, arr.Length - 1);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            for (int k = 0; k < times.Length; k++)
            {
                int lowest = int.MaxValue;
                int lowestY = 0;
                for (int i = 0; i < times.Length; i++)
                {
                    if (times[i] < lowest)
                    {
                        lowest = times[i];
                        lowestY = i + y;
                    }
                }
                Console.BackgroundColor = colorSpectrum(k);
                Console.SetCursorPosition(x, lowestY);
                Console.Write(lowest / unit + unitText);
                Console.ResetColor();
                times[lowestY - y] = int.MaxValue;
            }
        }
        public static void runAllSorts(string[] arr, int x, int y, string sortCode, double unit)
        {
            int[] times = new int[sortCode.Length];
            int time;
            int count = 0;

            int sortCount = 0;

            string unitText = "";
            switch (unit)
            {
                case 1:
                    unitText = " ticks";
                    break;
                case 2:
                    unitText = " ns";
                    unit = 0.01;
                    break;
                case 3:
                    unitText = " ms";
                    unit = 10000;
                    break;
                case 4:
                    unitText = " s";
                    unit = 10000000;
                    break;
                default:
                    unitText = " ticks";
                    break;
            }


            Sort s = new Sort();

            if (sortCode.ToString().Contains("1"))
            {
                Console.SetCursorPosition(x, y);
                time = s.Bubble(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("2"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.Insertion(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("3"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.Selection(arr);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("4"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.QuickTimed(arr, 0, arr.Length - 1);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            if (sortCode.ToString().Contains("5"))
            {
                Console.SetCursorPosition(x, y + sortCount++);
                time = s.MergeTimed(arr, 0, arr.Length - 1);
                Console.Write(time / unit + unitText);
                times[count++] = time;
            }

            for (int k = 0; k < times.Length; k++)
            {
                int lowest = int.MaxValue;
                int lowestY = 0;
                for (int i = 0; i < times.Length; i++)
                {
                    if (times[i] < lowest)
                    {
                        lowest = times[i];
                        lowestY = i + y;
                    }
                }
                Console.BackgroundColor = colorSpectrum(k);
                Console.SetCursorPosition(x, lowestY);
                Console.Write(lowest / unit + unitText);
                Console.ResetColor();
                times[lowestY - y] = int.MaxValue;
            }
        }
        public static ConsoleColor colorSpectrum(int i)
        {
            if (i == 0) return ConsoleColor.DarkGreen;
            else if (i == 1) return ConsoleColor.Green;
            else if (i == 2) return ConsoleColor.DarkYellow;
            else if (i == 3) return ConsoleColor.Red;
            else return ConsoleColor.DarkRed;
        }
    }
}
