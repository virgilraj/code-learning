using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Matrix
    {
        public void Print_SpiralOrder()
        {
            int[,] mat = {
                            { 1,  2,  3,  4, 5},
                            {16, 17, 18, 19, 6},
                            {15, 24, 25, 20, 7},
                            {14, 23, 22, 21, 8},
                            {13, 12, 11, 10, 9}
                        };

            //Need 4 edge poiter and one direction pointer
            //dir = 0 -- moving left to right
            //dir =1  -- moving top to bottom
            //dir =2  -- moving right to left
            //dir =3  -- moving left to top

            //T - top - first element -- L -> first column
            //B  -- bottom - Lfet - last element
            //R - right bottom 

            Console.WriteLine("Matrix :: Spiral order\n");

            int T =0, B, L=0, R, dir = 0;
            B = mat.GetUpperBound(0);
            R = mat.GetUpperBound(1);

            while(T<=B && L <= R)
            {
                //Top to right
                if (dir == 0)
                {
                    for (int i = 0; i <= R; i++)
                    {
                        Console.Write("{0} ", mat[T, i]);
                    }
                    T++;
                }
                else if (dir == 1)
                {
                    for (int i = T; i <= R; i++)
                    {
                        Console.Write("{0} ", mat[i, R]);
                    }
                    R--;
                }
                else if (dir == 2)
                {
                    for (int i = R; i >= L; i--)
                    {
                        Console.Write("{0} ", mat[B, i]);
                    }
                    B--;
                }
                else if (dir == 3)
                {
                    for (int i = B; i >= T; i--)
                    {
                        Console.Write("{0} ", mat[i, L]);
                    }
                    L++;
                }

                dir = (dir+1) % 4;
            }
        }
        // In-place rotate it by 90 degrees in clockwise direction
        //1. Transpose the matrix
        //2. Flip horizontally
        public void Rotation_90()
        {
            int[,] mat = {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 },
                    { 13, 14, 15, 16 }
                };

            int R = mat.GetUpperBound(0);
            int C = mat.GetUpperBound(1);

            // Transpose the matrix
            for (int i = 0; i <= R; i++)
                for (int j = 0; j <= i; j++)
                {
                    int tmp = mat[i,j];
                    mat[i,j] = mat[j,i];
                    mat[j, i] =tmp;
                }

            //Flip horizontally

            for (int i = 0; i <= R; i++)
                for (int j = 0; j <= R/2; j++)
                {
                    int tmp = mat[i, j];
                    mat[i, j] = mat[i, R-j];
                    mat[i, R -j] = tmp;
                }

            Console.WriteLine("\nMatrix 90 degree rotation");

            for (int i = 0; i <= R; i++)
            {
                for (int j = 0; j <= R; j++)
                    Console.Write(mat[i,j] +" ");

                Console.WriteLine();
            }
        }

        //Flood fill algorithm
        //DFS 
        public void FloodFill()
        {
            int[,] mat = { { 1, 2, 1, 1 },
                            { 2, 1, 1, 2 },
                            { 1, 0, 1, 0 }
                        };

            int sr = 1, sc = 2, newClor = 3;

            if(newClor == mat[sr, sc])
            {
                Console.WriteLine("No change");
            }

            int R = mat.GetUpperBound(0);
            int C = mat.GetUpperBound(1);
            int source = mat[sr, sc];

            dfs(mat, sr, sc, newClor, R, C, source);

            Console.WriteLine("\nFlood fill algorith");

            for (int i = 0; i <= R; i++)
            {
                for (int j = 0; j <= C; j++)
                    Console.Write(mat[i, j] + " ");

                Console.WriteLine();
            }
        }

        public void dfs(int[,] image, int sr, int sc, int newColor, int rows, int cols, int source)
        {
            if (sr < 0 || sr > rows || sc < 0 || sc > cols)
                return;
            else if (image[sr,sc] != source)
                return;

            image[sr,sc] = newColor;

            dfs(image, sr - 1, sc, newColor, rows, cols, source);   //TOP
            dfs(image, sr + 1, sc, newColor, rows, cols, source);   //DOWN
            dfs(image, sr, sc - 1, newColor, rows, cols, source);   //LEFT
            dfs(image, sr, sc + 1, newColor, rows, cols, source);   //RIGHT
        }
    }
}
