using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
/*using static Program.NPuzzle;
*/
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.	Read in a file containing an N board with (N – 1) numbered tiles and one blank space – representing an initial state. 
            string[] sampleSolveableTests_Files = { "8 Puzzle (1)", "8 Puzzle (2)", "8 Puzzle (3)", "15 Puzzle - 1", "24 Puzzle 1", "24 Puzzle 2" };
            string[] sampleSolution_Files = { "8 Puzzle (1) - Sol", "8 Puzzle (2) - Sol", "8 Puzzle (3) - Sol", "15 Puzzle (1) - Sol", "24 Puzzle 1 (Sol)", "24 Puzzle 2 (Sol)" };
            string[] sampleUnSolvable_Files = { "8 Puzzle - Case 1", "8 Puzzle(2) - Case 1", "8 Puzzle(3) - Case 1", "15 Puzzle - Case 2", "15 Puzzle - Case 3" };

            /*int[,] board = { {0,  1,   3 },
                            { 4,   2,   5 },
                            { 7,   8,   6 }};*/

            int[,] board = { { 8, 1, 3 }, { 4, 0, 2 }, { 7, 6, 5 } };
            int movment = 0;
            //int[,] board = { { 2, 1, 3, 4 }, { 5, 8, 7, 6 }, { 9, 10, 12, 11 }, { 15, 13, 14, 0 } };
            bool ok = NPuzzle.isFeasablie(board);
            if (ok)
                movment = NPuzzle.Solve(board, 1, 1, true);
            else
                Console.WriteLine("Not Solvable");
            //NPuzzle.Solve(board);

            Console.WriteLine(movment);
        }
    }
}
