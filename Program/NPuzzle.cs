using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    public static class NPuzzle
    {
        public static bool isFeasablie(int[,] boardPuzzle)  //should be bounded by O(S^2), S is the puzzle size
        {
            //2.	Determine whether a given state is solvable or not? 
            List<int> arr = new List<int>();
            double puzzleSize = boardPuzzle.Length;
            puzzleSize = Math.Sqrt(puzzleSize);
            for (int i = 0; i < puzzleSize; i++)
            {
                for (int j = 0; j < puzzleSize; j++)
                {
                    arr.Add(boardPuzzle[i, j]);
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
                blancIndex = blancIndex / Convert.ToInt32(puzzleSize);
                int blancPositionFromBottom = Convert.ToInt32(puzzleSize) - blancIndex;
                if (blancPositionFromBottom % 2 == 0 && invCount % 2 != 0)
                    return true;
                else if (blancPositionFromBottom % 2 != 0 && invCount % 2 == 0)
                    return true;
                else
                    return false;

            }
        }

        public static void Solve(int[,] boardPuzzle) // bounded by O(E log(V)), E is the total number of moves and V is the number of states till reaching to the solution 
        {
            //3.	IF SOLVABLE, apply A* search algorithm 
            Node parent = new Node(boardPuzzle,0,1);
            // call get direction function
            Node temp = parent;

            // choose to move which way ??
            //Node newChild = parent.moveUp(temp);

            // put the newChild in the piriority queue

            //4.	Print a STEP by STEP movements occur in the A* algorithms till you reach the final solvable board.
            //throw new NotImplementedException();
            
        }

    }
}
