using System;

namespace Minesweeper
{
    class Program
    {
        class Field
        {
            private char[,] field;
            private int minesCount;
            public int height, width;

            public char this[int i, int j]
            { 
                get => field[i, j];
            }

            public Field()
            {
                generate(50,  50);
            }
            
            public Field(int fieldHeight, int fieldWidth)
            {
                generate(fieldHeight,  fieldWidth);
            }

            void generate(int fieldHeight, int fieldWidth)
            {
                field = new char[fieldHeight, fieldWidth];
                minesCount = (int)Math.Round(field.Length * 0.15);
                height = field.GetLength(0);
                width = field.GetLength(1);
                
                Random rnd = new Random();
                for (int i = 0; i < minesCount; i++)
                {
                    (int row, int col) pos;
                    do
                    {
                        pos = (rnd.Next(height), rnd.Next(width));
                    } while (field[pos.row, pos.col] != '\0');

                    field[pos.row, pos.col] = 'X';
                }
                
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (field[i, j] != 'X')
                        {
                            int temp = 0;

                            for (int k = -1; k < 2; k++)
                            {
                                if (i + k >= 0 && i + k < height)
                                {

                                    for (int l = -1; l < 2; l++)
                                    {
                                        if (j + l >= 0  && j + l < width)
                                        {
                                            if (field[i + k, j + l] == 'X')
                                            {
                                                temp++;
                                            }
                                        }
                                    }
                                }
                            }
                            
                            field[i, j] = temp == 0 ? '_' : temp.ToString()[0];
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Field field = new Field(30, 30);
            
            for (int i = 0; i < field.height; i++)
            {
                for (int j = 0; j < field.width; j++)
                {
                    Console.Write((field[i, j]).ToString().PadLeft(2).PadRight(2));
                }
                    
                Console.WriteLine();
            }
            Console.WriteLine("");
        }
    }
}