using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int toInsert = 0;
            bool fromStart = true;
            int insertIndex = -1;
            bool insertFlag = false;
            int compCount = 0;

            Random rnd = new Random();
            int[] arr = { 29, 72, 98, 13, 87, 66, 52, 51, 36 };

            //int[] arr = new int[100];
            //for (int x = 0; x < arr.Length; x++)
            //    arr[x] = rnd.Next(100);

            // for display purposes
            Console.WriteLine("This is the unsorted array...");
            for (int x = 0; x < arr.Length; x++)
            {
                Console.Write(arr[x] + "\t");
                if (x > 0 && (x + 1) % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();

            for (int x = 1; x < arr.Length; x++)
            /*
             * We start from 1 because 0 has nothing to its left
             * it is assumed that 0 is already sorted
             */
            {
                // for display purposes
                #region Code Narration
                Console.ResetColor();
                Console.WriteLine("Checking if value at index {0} is in its correct location...", x);

                for (int y = 0; y < arr.Length; y++)
                {
                    if (y == x)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else
                        Console.ResetColor();
                    Console.Write(arr[y] + "\t");
                    if ((y + 1) % 10 == 0)
                        Console.WriteLine();
                }
                Console.WriteLine("\n");
                Console.ReadKey();
                Console.Clear();
                #endregion

                insertIndex = -1;
                insertFlag = false;

                // the algorithm that begins its search from the 0 index
                if(fromStart) 
                {
                    for(int y = 0; y < x; y++)
                    {
                        #region Code Narration
                        Console.ResetColor();
                        // for display purposes
                        Console.WriteLine("Comparing {0} and {1}", arr[x], arr[y]);

                        for (int z = 0; z < arr.Length; z++)
                        {
                            if (z == x)
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            else if (z < y)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else if (z == y)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else
                                Console.ResetColor();
                            Console.Write(arr[z] + "\t");
                            if ((z + 1) % 10 == 0)
                                Console.WriteLine();
                        }
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        //Console.Clear();
                        #endregion
                        compCount++;
                        if (arr[x] < arr[y])
                        {
                            insertFlag = true;
                            insertIndex = y;
                            break;
                        }
                    }
                }
                else
                {
                    for(int y = x - 1; y >= 0; y--)
                    {
                        #region Code Narration
                        // for display purposes
                        Console.ResetColor();
                        Console.WriteLine("Comparing {0} and {1}", arr[x], arr[y]);

                        for (int z = 0; z < arr.Length; z++)
                        {
                            if (z == x)
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            else if (z > y && z < x)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else if (z == y)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else
                                Console.ResetColor();
                            Console.Write(arr[z] + "\t");
                            if ((z + 1) % 10 == 0)
                                Console.WriteLine();
                        }
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        //Console.Clear();
                        #endregion
                        compCount++;
                        if (arr[x] < arr[y])
                        {
                            insertFlag = true;
                            insertIndex = y;
                        }
                        else
                            break;
                    }
                }

                if(insertFlag)
                {
                    Console.WriteLine("Preparing to move...");

                    toInsert = arr[x];
                    arr[x] = -1;

                    #region Code Narration
                    // for display purposes
                    Console.ResetColor();
                    Console.WriteLine("Removing value {0} from index {1}", toInsert, x);

                    for (int y = 0; y < arr.Length; y++)
                    {
                        if (arr[y] == -1)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.ResetColor();
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.ResetColor();
                            Console.Write(arr[y] + "\t");
                        }
                        if ((y + 1) % 10 == 0)
                            Console.WriteLine();
                    }
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    //Console.Clear();
                    #endregion

                    // this is the logic that moves values around
                    for (int y = x - 1; y >= insertIndex; y--)
                    {
                        arr[y + 1] = arr[y];
                        arr[y] = -1;
                        #region Code Narration
                        // for display purposes
                        Console.ResetColor();
                        Console.WriteLine("Moving value {0} to index {1}", arr[y+1], y + 1);

                        for (int z = 0; z < arr.Length; z++)
                        {
                            if (arr[z] == -1)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.ResetColor();
                                Console.Write("\t");
                            }
                            else if(z == y+ 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(arr[z] + "\t");
                            }
                            else
                            {
                                Console.ResetColor();
                                Console.Write(arr[z] + "\t");
                            }
                            if ((z + 1) % 10 == 0)
                                Console.WriteLine();
                        }
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        #endregion
                    }

                    arr[insertIndex] = toInsert;
                    #region Code Narration
                    // for display purposes
                    Console.ResetColor();
                    Console.WriteLine("Inserting value {0} to index {1}", toInsert, insertIndex);

                    for (int y = 0; y < arr.Length; y++)
                    {
                        if(y == insertIndex)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else
                            Console.ResetColor();
                        Console.Write(arr[y] + "\t");
                        if ((y + 1) % 10 == 0)
                            Console.WriteLine();
                    }
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    Console.Clear();
                    #endregion

                }
                else if(insertIndex == -1)
                {
                    #region Code Narration
                    // for display purposes
                    Console.ResetColor();
                    Console.WriteLine("Value at index {0} is in the correct location", x);

                    for (int z = 0; z < arr.Length; z++)
                    {
                        if (z == x)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.ResetColor();
                        Console.Write(arr[z] + "\t");
                        if ((z + 1) % 10 == 0)
                            Console.WriteLine();
                    }
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    Console.Clear();
                    #endregion
                }

                //foreach (int a in arr)
                //    Console.Write(a + "\t");
                //Console.WriteLine();
            }
            Console.WriteLine("Done! {0} Comparisons made", compCount);
            Console.ReadKey();
        }
    }
}
