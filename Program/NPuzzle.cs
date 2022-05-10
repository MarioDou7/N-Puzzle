using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    public static class NPuzzle
    {
        public static bool isFeasablie(int puzzleSize,char[,] boardPuzzle)  //should be bounded by O(S^2), S is the puzzle size

        {
            //2.	Determine whether a given state is solvable or not? 
            List<int> arr = new List<int>();
            for (int i = 0; i < puzzleSize; i++)
            {
                var values = (Console.ReadLine().Split(' '));
                for (int j = 0; j < puzzleSize; j++)
                {
                    arr.Add(int.Parse(values[j]));
                }
            }

            int invCount = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] == 0 || arr[j] == 0)
                        continue;
                    if (arr[i] > arr[j])
                        invCount++;
                }

            }
            if (puzzleSize % 2 != 0)
            {
                if (invCount % 2 == 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int blancIndex = arr.IndexOf(0);
                blancIndex = blancIndex / puzzleSize;
                int blancPositionFromBottom = puzzleSize - blancIndex;
                if (blancPositionFromBottom % 2 == 0 && invCount % 2 != 0)
                    return true;
                else if (blancPositionFromBottom % 2 != 0 && invCount % 2 == 0)
                    return true;
                else
                    return false;

            }
        }

        public static void Solve(char[,] boardPuzzle) // bounded by O(E log(V)), E is the total number of moves and V is the number of states till reaching to the solution 
        {
            //3.	IF SOLVABLE, apply A* search algorithm 

            //4.	Print a STEP by STEP movements occur in the A* algorithms till you reach the final solvable board.
            throw new NotImplementedException();
            
        }

/*        private void PrepareTree()
        {
            // 3.a	Convert the given puzzle into tree while applying the A* search algorithm
            //Where each node in the search tree represents an arrangement of tiles (one board state)

            throw new NotImplementedException();
        }*/
        static int Manhatten(char[,] currentState) // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
        {
            int N = (int)Math.Sqrt(currentState.Length);
            int row_goal;
            int col_goal;
            int number;
            int manhatten = 0;

            for (int i = 0; i < currentState.Length; i++)
            {
                number = Int32.Parse(currentState[i / N, i % N].ToString());
                if (number == 0)
                    continue;
                row_goal = (number-1) / N;                   //find the goal postion of the number (at which row)              
                col_goal = (number-1) % N;                   //find the goal postion of the number (at which col)

                manhatten += (Math.Abs(row_goal - i / N) + Math.Abs(col_goal - i % N));
            }

            return manhatten;

        }
        static int Hamming(char[,] currentState, char[,] goalState) // The number of blocks in the wrong position + the number of moves made so far to get to the state. 
        {
            throw new NotImplementedException();
        }
    }
}
