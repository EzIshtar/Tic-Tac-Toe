using System.Runtime.InteropServices;

namespace ProgressIsHere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[5,11] { { ' ', ' ', ' ', '|',  ' ',' ', ' ', '|', ' ', ' ', ' ' }, { '_', '_', '_', '+', '_', '_', '_', '+', '_', '_', '_' }, { ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ' }, { '_', '_', '_', '+', '_', '_', '_', '+', '_', '_', '_' }, { ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ' } };

            Tic tic = new Tic();
            grid = tic.CreateGrid(grid);
            int zero = 0, count = 0,dec = 0;

            while (zero != 1 && zero != 2 && count < 6)
            {
                while (tic.check != true)
                {
                    Console.Write("Player 1, which grid(1-9) would you put your circle? ");
                    dec = Convert.ToInt32(Console.ReadLine());
                    grid = tic.UpdateGrid(grid, dec, 0);
                }
                Console.Clear();
                grid = tic.CreateGrid(grid);
                zero = tic.CheckWin(grid);
                if (zero == 1) break;

                tic.check = false;

                while (tic.check != true)
                {
                    Console.Write("Player 2, which grid(1-9) would you put your cross? ");
                    dec = Convert.ToInt32(Console.ReadLine());
                    grid = tic.UpdateGrid(grid, dec, 1);
                }
                Console.Clear();

                grid = tic.CreateGrid(grid);

                zero = tic.CheckWin(grid);
                tic.check = false;
                count++;
            }

            Console.Beep();
            if (count == 9 && zero == 0) Console.WriteLine("Tie");
            else if (zero == 1) Console.WriteLine("Congrats Player 1, ya win :)");
            else if (zero == 2) Console.WriteLine("Congrats Player 2, ya win :)");

        }

        class Tic
        {
            public bool check;
            public char[,] CreateGrid(char[,] m)
            {
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    for(int j = 0; j < m.GetLength(1); j++)
                    {
                        Console.Write(m[i,j]);
                    }
                    Console.WriteLine();
                }
                return m;
            }

            public char[,] UpdateGrid(char[,] m, int n, int dec)
            {
                check = false;

                if (n == 1 && m[0, 1] == ' ' && dec == 0) { check = true; m[0, 1] = 'O'; }
                else if (n == 2 && m[0, 5] == ' ' && dec == 0) { check = true; m[0, 5] = 'O'; }
                else if (n == 3 && m[0, 9] == ' ' && dec == 0) { check = true; m[0, 9] = 'O'; }
                else if (n == 4 && m[2, 1] == ' ' && dec == 0) { check = true; m[2, 1] = 'O'; }
                else if (n == 5 && m[2, 5] == ' ' && dec == 0) { check = true; m[2, 5] = 'O'; }
                else if (n == 6 && m[2, 9] == ' ' && dec == 0) { check = true; m[2, 9] = 'O'; }
                else if (n == 7 && m[4, 1] == ' ' && dec == 0) { check = true; m[4, 1] = 'O'; }
                else if (n == 8 && m[4, 5] == ' ' && dec == 0) { check = true; m[4, 5] = 'O'; }
                else if (n == 9 && m[4, 9] == ' ' && dec == 0) { check = true; m[4, 9] = 'O'; }

                else if (n == 1 && m[0, 1] == ' ' && dec == 1) { check = true; m[0, 1] = 'X'; }
                else if (n == 2 && m[0, 5] == ' ' && dec == 1) { check = true; m[0, 5] = 'X'; }
                else if (n == 3 && m[0, 9] == ' ' && dec == 1) { check = true; m[0, 9] = 'X'; }
                else if (n == 4 && m[2, 1] == ' ' && dec == 1) { check = true; m[2, 1] = 'X'; }
                else if (n == 5 && m[2, 5] == ' ' && dec == 1) { check = true; m[2, 5] = 'X'; }
                else if (n == 6 && m[2, 9] == ' ' && dec == 1) { check = true; m[2, 9] = 'X'; }
                else if (n == 7 && m[4, 1] == ' ' && dec == 1) { check = true; m[4, 1] = 'X'; }
                else if (n == 8 && m[4, 5] == ' ' && dec == 1) { check = true; m[4, 5] = 'X'; }
                else if (n == 9 && m[4, 9] == ' ' && dec == 1) { check = true; m[4, 9] = 'X'; }

                else Console.WriteLine("Invalid! Please try again!");
                    
                return m;
            }

            public int CheckWin(char[,] m)
            {
                if (m[0, 1] == 'O' && m[0, 5] == 'O' && m[0, 9] == 'O') return 1;
                else if (m[2, 1] == 'O' && m[2, 5] == 'O' && m[2, 9] == 'O') return 1;
                else if (m[4, 1] == 'O' && m[4, 5] == 'O' && m[4, 9] == 'O') return 1;
                else if (m[0, 1] == 'O' && m[2, 1] == 'O' && m[4, 1] == 'O') return 1;
                else if (m[0, 5] == 'O' && m[2, 5] == 'O' && m[4, 5] == 'O') return 1;
                else if (m[0, 9] == 'O' && m[2, 9] == 'O' && m[4, 9] == 'O') return 1;
                else if (m[0, 1] == 'O' && m[2, 5] == 'O' && m[4, 9] == 'O') return 1;
                else if (m[0, 9] == 'O' && m[2, 5] == 'O' && m[4, 1] == 'O') return 1;

                else if (m[0, 1] == 'X' && m[0, 5] == 'X' && m[0, 9] == 'X') return 2;
                else if (m[2, 1] == 'X' && m[2, 5] == 'X' && m[2, 9] == 'X') return 2;
                else if (m[4, 1] == 'X' && m[4, 5] == 'X' && m[4, 9] == 'X') return 2;
                else if (m[0, 1] == 'X' && m[2, 1] == 'X' && m[4, 1] == 'X') return 2;
                else if (m[0, 5] == 'X' && m[2, 5] == 'X' && m[4, 5] == 'X') return 2;
                else if (m[0, 9] == 'X' && m[2, 9] == 'X' && m[4, 9] == 'X') return 2;
                else if (m[0, 1] == 'X' && m[2, 5] == 'X' && m[4, 9] == 'X') return 2;
                else if (m[0, 9] == 'X' && m[2, 5] == 'X' && m[4, 1] == 'X') return 2;

                return 0;
            }
        }
    }
}
