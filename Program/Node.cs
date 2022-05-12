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
        public int puzzleSize;
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
            puzzleSize = N;
        }
        public Node(Node parent)
        {
            this.hamming = parent.hamming;
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
            throw new NotImplementedException();
        }

        /* private Node moveUp(int[,] board,int rowNumber,int columnNumber)
         {
             Node node = new Node(board,rowNumber-1,columnNumber);
             return node;
         }*/

        //Node initialNode;
        public List<string> getDirections()
        {
            List<string> directions = new List<string>();
            // top left corner
            if (this.zero_x == 0 && this.zero_y == 0)
            {
                directions.Add("right");
                directions.Add("bottom");
            }

            // top right corner
            else if (this.zero_x == 0 && this.zero_y == this.puzzleSize - 1)
            {
                directions.Add("left");
                directions.Add("bottom");
            }
            // bottom left corner
            else if (this.zero_x == this.puzzleSize - 1 && this.zero_y == 0)
            {
                directions.Add("top");
                directions.Add("right");
            }

            // bottom right corner
            else if (this.zero_x == this.puzzleSize - 1 && this.zero_y == this.puzzleSize - 1)
            {
                directions.Add("left");
                directions.Add("top");
            }
            // 3al 7arf top -> 3 possabilities
            else if (this.zero_x == 0)
            {
                directions.Add("right");
                directions.Add("left");
                directions.Add("bottom");
            }
            // 3al 7arf bottom -> 3 possabilities
            else if (this.zero_x == this.puzzleSize - 1)
            {
                directions.Add("right");
                directions.Add("left");
                directions.Add("top");
            }
            // 3al 7arf left -> 3 possabilities
            else if (this.zero_y == 0)
            {
                directions.Add("top");
                directions.Add("bottom");
                directions.Add("right");
            }
            // 3al 7arf right -> 3 possabilities
            else if (this.zero_y == this.puzzleSize - 1)
            {
                directions.Add("top");
                directions.Add("bottom");
                directions.Add("left");
            }
            // middle -> 4 possabilities
            else
            {
                directions.Add("top");
                directions.Add("bottom");
                directions.Add("left");
                directions.Add("right");
            }
            return directions;
        }
        public Node moveup()
        {
            throw new NotImplementedException();
        }
        public Node movedown()
        {
            throw new NotImplementedException();
        }
        public Node moveright()
        {
            throw new NotImplementedException();
        }
        public Node moveleft()
        {
            throw new NotImplementedException();
        }

    }
}
