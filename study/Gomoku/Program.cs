using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[9,9];

            arr[0, 0] = 1;
            arr[0, 1] = 2;

            draw(arr);

            
        }

        static void draw(int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        Console.Write(" ○ ");
                    }
                    else if (arr[i, j] == 2)
                    {
                        Console.Write(" ● ");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                Console.Write(" ┌─");
                            }
                            else if (j == 8)
                            {
                                Console.Write("─┐ ");
                            }
                            else
                            {
                                Console.Write("─┬─");
                            }
                        }
                        else if (i == 8)
                        {
                            if (j == 0)
                            {
                                Console.Write(" └─");
                            }
                            else if (j == 8)
                            {
                                Console.Write("─┘ ");
                            }
                            else
                            {
                                Console.Write("─┴─");
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                Console.Write(" ├─");
                            }
                            else if (j == 8)
                            {
                                Console.Write("─┤ ");
                            }
                            else
                            {
                                Console.Write("─┼─");
                            }
                        }
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
