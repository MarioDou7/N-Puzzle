using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Node
    {
        int[,] board;
        int N;
        int movments = 0;
        int zero_x;
        int zero_y;
        public int manhatten;
        public int hamming;
        public int fn_ham;         // hamming + #movment
        public int fn_man;         // manhatten + #movment 

        public Node(int[,] board,int zero_x,int zero_y)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    this.board[i, j] = board[i, j];

            Manhatten();
            Hamming();
            
            this.N = (int)Math.Sqrt(board.Length);
            this.fn_ham    = this.hamming + this.movments;
            this.fn_man    = this.manhatten + this.movments;

            this.zero_x    = zero_x;
            this.zero_y    = zero_y;
        }

        public Node(Node node)
        {
            N = node.N;
            fn_ham = node.fn_ham;
            fn_man = node.fn_man;
            zero_x = node.zero_x;
            zero_y = node.zero_y;
            hamming = node.hamming;
            manhatten = node.manhatten;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    board[i, j] = node.board[i, j];
                
        }
        
        public Node MoveUp(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x - 1, zero_y];
            child.board[zero_x - 1, zero_y] = 0;

            child.zero_x = zero_x - 1 ;

            child.movments++;
            child.Manhatten();
            child.Hamming();

            return child;
        }
        public Node MoveDown(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x + 1, zero_y];
            child.board[zero_x + 1, zero_y] = 0;

            child.zero_x = zero_x + 1;

            child.movments++;
            child.Manhatten();
            child.Hamming();


            return child;
        }
        public Node MoveLeft(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y - 1];
            child.board[zero_x, zero_y - 1] = 0;

            child.zero_y = zero_y - 1;

            child.movments++;
            child.Manhatten();
            child.Hamming();

            return child;
        }
        public Node MoveRight(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y + 1];
            child.board[zero_x, zero_y + 1] = 0;

            child.zero_y = zero_y + 1;

            child.movments++;
            child.Manhatten();
            child.Hamming();

            return child;
        }

        private void Manhatten() // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
        {
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
            this.fn_man = this.manhatten + this.movments;

        }
        
        private void Hamming() // The number of blocks in the wrong position + the number of moves made so far to get to the state. 
        {            
            int number,row_goal,col_goal;
            int hamm = 0;
            
            for (int i = 0; i < board.Length; i++)
            {
                number = board[i / N, i % N];
                if (number == 0)
                    continue;
                row_goal = (number - 1) / N;                   //find the goal postion of the number (at which row)              
                col_goal = (number - 1) % N;                   //find the goal postion of the number (at which col)

                if (row_goal != i / N || col_goal != i % N)
                    hamm++;
            }

            this.hamming = hamm;
            this.fn_ham = this.hamming + this.movments;
        }

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
            else if (this.zero_x == 0 && this.zero_y == this.N - 1)
            {
                directions.Add("left");
                directions.Add("bottom");
            }
            // bottom left corner
            else if (this.zero_x == this.N - 1 && this.zero_y == 0)
            {
                directions.Add("top");
                directions.Add("right");
            }

            // bottom right corner
            else if (this.zero_x == this.N - 1 && this.zero_y == this.N - 1)
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
            else if (this.zero_x == this.N - 1)
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
            else if (this.zero_y == this.N - 1)
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


    }

}

