using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cars;

namespace C__with_coffee
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char[,] map = ReadMap("map.txt");
            ConsoleKeyInfo track = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                PaintScreen(map);
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("@");

                Console.ForegroundColor= ConsoleColor.Red;
                Console.SetCursorPosition(37, 0);
                Console.WriteLine(track.KeyChar);

                track = Console.ReadKey();
                                                
            }
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLength(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = file[y][x];
            
            return map;
        }

        private static int GetMaxLength(string[] lines) 
        {
            int maxLength = lines[0].Length;

            foreach (string line in lines)
                if(line.Length > maxLength)
                    maxLength = line.Length;
            return maxLength;
        }

        private static void PaintScreen(char[,] map)
        {
            for (int y = 0; y<map.GetLength(1); y++)
            {
                for (int x = 0; x<map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
            Console.WriteLine();
            }
        }
    }
}
