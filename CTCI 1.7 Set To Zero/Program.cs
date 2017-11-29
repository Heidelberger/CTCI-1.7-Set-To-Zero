using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_1._7_Set_To_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(1, 7, "Set to Zero");

            int[,] array2D_6 = new int[6, 6] { { 3, 0, 67, 4, 28, 5 }, { 10, 8, 12, 13, 14, 15 }, { 20, 21, 22, 23, 0, 25 }, { 30, 31, 32, 33, 34, 35 }, { 40, 6, 42, 43, 44, 45 }, { 50, 51, 52, 53, 54, 55 } };

            Console.WriteLine("Original:");
            PrintArray(array2D_6);

            SetToZero(array2D_6);

            Console.WriteLine("Modified:");
            PrintArray(array2D_6);

            Console.ReadLine();
        }

        //////////////////////////////////////////////////////////////
        //        
        // Work in 2 passes.  All modifications are in-place.
        //
        // Complexity: Algorithm runs in O(N) time
        //             Every element is touched once to check for zero. Column-0 and Row-0
        //             are checked twice. If zeros are found, then the elements in that 
        //             column and row are set to zero.
        //
        //             Algorithm requires O(N) space
        //             All elements are stored in memory once. Edits are in-place.
        //
        private static void SetToZero(int[,] array2D_6)
        {
            // if any element in the array is zero, set the entire row and column of that element to zero


            // PASS 1:
            // check column 0 and row 0 for any zeroes
            bool Y_ToZero = false;
            bool X_ToZero = false;
            for (int i = 0; i < array2D_6.GetLength(0); ++i)
            {
                if (array2D_6[i,0] == 0)
                {
                    X_ToZero = true;

                    if (Y_ToZero == true)
                        break;
                }
                if (array2D_6[0,i] == 0)
                {
                    Y_ToZero = true;

                    if (X_ToZero == true)
                        break;
                }
            }

            // PASS 2:
            // skip column 0 and row 0
            // if any other element is zero, set column 0 and row 0 to zero
            for(int Y_index = 1; Y_index < array2D_6.GetLength(0) - 1; ++Y_index)
            {
                for (int X_index = 1; X_index < array2D_6.GetLength(0) - 1; ++X_index)
                {
                    if (array2D_6[X_index, Y_index] == 0)
                    {
                        array2D_6[X_index, 0] = 0;
                        array2D_6[0, Y_index] = 0;
                    }
                }
            }

            // PASS 3:
            // check column 0 and row 0 for zeroes
            // if found, set the row or column to zero
            for (int index = array2D_6.GetLength(0) - 1; index >= 0; --index)
            {
                if (array2D_6[index, 0] == 0)
                {
                    for (int i = 1; i < array2D_6.GetLength(0); ++i)
                    {
                        array2D_6[index, i] = 0;
                    }
                }

                if (array2D_6[0,index] == 0)
                {
                    for (int i = 1; i < array2D_6.GetLength(0); ++i)
                    {
                        array2D_6[i,index] = 0;
                    }
                }
            }

            // PASS 4:
            // if column 0 or row 0 had a zero, set it to zero
            if (X_ToZero == true)
            {
                for (int i = 0; i < array2D_6.GetLength(0); ++i)
                {
                    array2D_6[i, 0] = 0;
                }
            }
            if (Y_ToZero == true)
            {
                for (int i = 0; i < array2D_6.GetLength(0); ++i)
                {
                    array2D_6[0, i] = 0;
                }
            }
        }

        private static void PrintArray(int[,] array2D)
        {
            for (int y = array2D.GetLength(0) - 1; y >= 0; --y)
            {
                for (int x = 0; x < array2D.GetLength(0); ++x)
                {
                    if (array2D[x, y] < 10)
                        Console.Write("0");

                    Console.Write(array2D[x, y]);
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }
}
