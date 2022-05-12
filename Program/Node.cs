using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Node
    {
        int[,] board;
        int movments = 0;
        int zero_x;
        int zero_y;
        public int manhatten;
        public int hamming;
        public int fn_ham;         // hamming + #movment
        public int fn_man;         // manhatten + #movment 
/*        Node leftnode;
        Node rightnode;*/

        public Node(int[,] board,int zero_x,int zero_y)
        {
            int N = (int)Math.Sqrt(board.Length);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    this.board[i, j] = board[i, j];

            Manhatten(board);
            this.hamming   = this.Hamming(board);
            this.fn_ham    = this.hamming + this.movments;
            this.fn_man    = this.manhatten + this.movments;
            /*this.leftnode  = null;
            this.rightnode = null;*/
            this.zero_x    = zero_x;
            this.zero_y    = zero_y;
        }
        private void Manhatten(int[,] board) // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
        {
            int N = (int)Math.Sqrt(board.Length);
            int row_goal;
            int col_goal;
            int number;
            int manhatten = 0;

            for (int i = 0; i < board.Length; i++)
            {
                number = board[i / N, i % N];
                if (number == 0)
                    continue;
                row_goal = (number - 1) / N;                   //find the goal postion of the number (at which row)              
                col_goal = (number - 1) % N;                   //find the goal postion of the number (at which col)

                manhatten += (Math.Abs(row_goal - i / N) + Math.Abs(col_goal - i % N));
            }

            this.manhatten = manhatten;

        }
        private int Hamming(int[,] board) // The number of blocks in the wrong position + the number of moves made so far to get to the state. 
        {
            
            char[,] goalState = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '0' } };
            int len = (board.Length);
            int N = (int)Math.Sqrt(len);
            int hamm = 0, res = 0;
            for (int i = 0; i < len; i++)
            {
                if (board[i / N, i % N] != goalState[i / N, i % N])
                {
                    if (board[i / N, i % N] == '0')
                        continue;
                    hamm++;
                }
            }

            return hamm; 
        }
            
    }

}

