using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    class NPuzzle
    {
        static bool isFeasablie(char[,] boardPuzzle)  //should be bounded by O(S^2), S is the puzzle size
        {
            //2.	Determine whether a given state is solvable or not? 
            throw new NotImplementedException();
        }

        static void Solve(char[,] boardPuzzle) // bounded by O(E log(V)), E is the total number of moves and V is the number of states till reaching to the solution 
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
        private int Manhatten(char[,] currentState, char[,] goalState) // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
        {
            throw new NotImplementedException();
        }
        private int Hamming(char[,] currentState, char[,] goalState) // The number of blocks in the wrong position + the number of moves made so far to get to the state. 
        {
            throw new NotImplementedException();
        }
    }
}
