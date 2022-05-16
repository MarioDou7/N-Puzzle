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

            //int[,] board = { { 8, 1, 3 }, { 4, 0, 2 }, { 7, 6, 5 } };

            //int[,] board = { { 2, 1, 3, 4 }, { 5, 8, 7, 6 }, { 9, 10, 12, 11 }, { 15, 13, 14, 0 } };
            /*bool ok = NPuzzle.isFeasablie(board);
            if (ok)
                Console.WriteLine("Solvable");
            else
                Console.WriteLine("Not Solvable");*/
            //NPuzzle.Solve(board);

            Console.WriteLine("Welcome to N-Puzzle !");
            Console.WriteLine("What do you want to test");
            Console.WriteLine();

            Console.WriteLine("1- Sample Test");
            Console.WriteLine("2- Complete Test");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];

            switch (choice)
            {
                case '1':
                    Console.WriteLine("\nChoose a puzzle [1-6]: ");
                    Console.WriteLine("1- 8 Puzzle (1)");
                    Console.WriteLine("2- 8 Puzzle (2)");
                    Console.WriteLine("3- 8 Puzzle (3)");
                    Console.WriteLine("4- 15 Puzzle");
                    Console.WriteLine("5- 24 Puzzle (1)");
                    Console.WriteLine("6- 24 Puzzle (2)");
                    Console.Write("\nEnter your choice [1-6]: ");
                    char puzzleChoice = (char)Console.ReadLine()[0];

                    switch (puzzleChoice)
                    {
                        case '1':
                            readFile("8 Puzzle (1).txt",true);
                            break;
                        case '2':
                            readFile("8 Puzzle (2).txt", true);
                            break;
                        case '3':
                            readFile("8 Puzzle (3).txt", true);
                            break;
                        case '4':
                            readFile("15 Puzzle - 1.txt", true);
                            break;
                        case '5':
                            readFile("24 Puzzle 1.txt", true);
                            break;
                        case '6':
                            readFile("24 Puzzle 2.txt", true);
                            break;
                        default:
                            break;
                    }
                    break;
                case '2':
                    Console.WriteLine("\nChoose [1-3]: ");
                    Console.WriteLine("1- Manhattan & Hamming");
                    Console.WriteLine("2- Manhattan Only");
                    Console.WriteLine("3- Large Test Csses");
                    Console.Write("\nEnter your choice [1-3]: ");

                    char comletePuzzleChoice = (char)Console.ReadLine()[0];

                    switch (comletePuzzleChoice)
                    {
                        case '1':
                            Console.WriteLine("\nChoose a puzzle [1-4]: ");
                            Console.WriteLine("1- 50 Puzzle");
                            Console.WriteLine("2- 10 Puzzle (1)");
                            Console.WriteLine("3- 10 Puzzle (2)");
                            Console.WriteLine("4- 100 Puzzle");
                            Console.Write("\nEnter your choice [1-4]: ");
                            char c = (char)Console.ReadLine()[0];
                            switch (c)
                            {
                                case '1':
                                    readFile(@"Solvable puzzles\Manhattan & Hamming\50 Puzzle.txt", false);
                                    break;
                                case '2':
                                    readFile(@"Solvable puzzles\Manhattan & Hamming\99 Puzzle - 1.txt", false);
                                    break;
                                case '3':
                                    readFile(@"Solvable puzzles\Manhattan & Hamming\99 Puzzle - 2.txt", false);
                                    break;
                                case '4':
                                    readFile(@"Solvable puzzles\Manhattan & Hamming\9999 Puzzle.txt", false);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case '2':
                            Console.WriteLine("\nChoose a puzzle [1-4]: ");
                            Console.WriteLine("1- 15 Puzzle (1)");
                            Console.WriteLine("2- 15 Puzzle (2)");
                            Console.WriteLine("3- 15 Puzzle (3)");
                            Console.WriteLine("4- 15 Puzzle (4)");
                            Console.Write("\nEnter your choice [1-4]: ");
                            char cc = (char)Console.ReadLine()[0];
                            switch (cc)
                            {
                                case '1':
                                    readFile(@"Solvable puzzles\Manhattan Only\15 Puzzle 1.txt", false);
                                    break;
                                case '2':
                                    readFile(@"Solvable puzzles\Manhattan Only\15 Puzzle 3.txt", false);
                                    break;
                                case '3':
                                    readFile(@"Solvable puzzles\Manhattan Only\15 Puzzle 4.txt", false);
                                    break;
                                case '4':
                                    readFile(@"Solvable puzzles\Manhattan Only\15 Puzzle 5.txt", false);
                                    break;
                                default:
                                    break;

                            }
                            break;
                        case '3':
                            readFile(@"V. Large test case\TEST.txt", false);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;


            }
            
        }

        public static void readFile(string fileName,bool sampleTest)
        {
            //@"C:\Users\Ziad\source\repos\algorithm_project\Program\8 Puzzle (1).txt"
            string initialPath="";
            if (sampleTest)
            {
                initialPath = @"D:\computer science\third year\second term\Algorithm\Project\[3] N Puzzle\Testcases\Sample\Sample Test\Solvable Puzzles\";

            }
            else
            {
                initialPath = @"D:\computer science\third year\second term\Algorithm\Project\[3] N Puzzle\Testcases\Complete\Complete Test\";

            }
            FileStream fs = new FileStream(initialPath+fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int[,] board = new int[0,0];
            int zero_x = 0;
            int zero_y = 0;
            
            while (sr.Peek() != -1)
            {
                String s = sr.ReadLine();
                String[] fields;
                fields = s.Split(' ');
                int N;
                N = int.Parse(fields[0]);
                int val;
                board = new int[N, N];

                 s = sr.ReadLine();
                fields = s.Split(' ');
                for (int i = 0; i < N; i++)
                {
                  s = sr.ReadLine();
                    if(s!=null)
                        fields = s.Split(' ');
                    for (int j = 0; j < N; j++)
                    {
                        val = int.Parse(fields[j]);
                        if (val == 0) { zero_x = i; zero_y = j; }
                        board[i, j] = val;
                    }
                }
            }
            
            bool isSolvable = NPuzzle.isFeasablie(board);
            if (isSolvable)
            {
                Console.WriteLine("Solvable");

                int movment = NPuzzle.Solve(board, zero_x, zero_y, false);
                Console.WriteLine("Number of Movment {0}",movment);
            }
            else
            {
                Console.WriteLine("Not Solvable");
                throw new Exception();
            }



        }
    }
}
