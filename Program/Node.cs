using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Node
    {
        int[,] board;
        int zero_x;
        int zero_y;
        public int N;
        public int movments = 0;
        public int manhatten;
        public int hamming;
        public int fn_ham;         // hamming + #movment
        public int fn_man;         // manhatten + #movment 
        public string last_move;
        public Node parent;

        public Node(int[,] board,int zero_x,int zero_y)
        {

            
            this.N = (int)Math.Sqrt(board.Length);

            this.zero_x    = zero_x;
            this.zero_y    = zero_y;
            this.last_move = "none";

            this.board = new int[N, N];
            this.parent = null;
            this.board = (int[,])board.Clone();
            Manhatten();
            Hamming();

        }

        public Node(Node node)
        {
            parent = node;
            N = node.N;
            fn_ham = node.fn_ham;
            fn_man = node.fn_man;
            zero_x = node.zero_x;
            zero_y = node.zero_y;
            hamming = node.hamming;
            manhatten = node.manhatten;
            last_move = node.last_move;
            movments = node.movments;
            board = new int[N, N];
            board = (int[,])node.board.Clone();
        }

        public Node MoveUp(Node node)   //O(N^2)
        {
            Node child = new Node(node); //O(N^2)
            int manhatten_node_number = node.New_Manhatten(zero_x-1, zero_y);
            int hamming_node_number = node.New_Hamming(zero_x - 1, zero_y);

            child.board[zero_x, zero_y] = child.board[zero_x - 1, zero_y];
            child.board[zero_x - 1, zero_y] = 0;

            int hamming_child_number = node.New_Hamming(zero_x, zero_y);
            int manhatten_child_number = child.New_Manhatten(zero_x, zero_y);

            child.zero_x = zero_x - 1 ;
            child.last_move = "up";

            child.movments++;
            if (hamming_node_number > hamming_child_number)
                child.hamming--;
            else if (hamming_node_number < hamming_child_number)
                child.hamming++;


            if (manhatten_node_number > manhatten_child_number)
                child.manhatten -= Math.Abs(manhatten_node_number - manhatten_child_number);
            else if (manhatten_node_number < manhatten_child_number)
                child.manhatten += Math.Abs(manhatten_node_number - manhatten_child_number);

            child.fn_ham = child.hamming + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        public Node MoveDown(Node node)
        {
            Node child = new Node(node);
            int manhatten_node_number = node.New_Manhatten(zero_x + 1, zero_y);
            int hamming_node_number = node.New_Hamming(zero_x + 1, zero_y);

            child.board[zero_x, zero_y] = child.board[zero_x + 1, zero_y];
            child.board[zero_x + 1, zero_y] = 0;

            int hamming_child_number = node.New_Hamming(zero_x, zero_y);
            int manhatten_child_number = child.New_Manhatten(zero_x, zero_y);

            child.zero_x = zero_x + 1;
            child.last_move = "down";

            child.movments++;
            
            if (hamming_node_number > hamming_child_number)
                child.hamming--;
            else if (hamming_node_number < hamming_child_number)
                child.hamming++;


            if (manhatten_node_number > manhatten_child_number)
                child.manhatten -= Math.Abs(manhatten_node_number - manhatten_child_number);
            else if (manhatten_node_number < manhatten_child_number)
                child.manhatten += Math.Abs(manhatten_node_number - manhatten_child_number);

            child.fn_ham = child.hamming + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        public Node MoveLeft(Node node)
        {
            Node child = new Node(node);
            int manhatten_node_number = node.New_Manhatten(zero_x, zero_y - 1);
            int hamming_node_number = node.New_Hamming(zero_x, zero_y - 1);

            child.board[zero_x, zero_y] = child.board[zero_x, zero_y - 1];
            child.board[zero_x, zero_y - 1] = 0;

            int hamming_child_number = node.New_Hamming(zero_x, zero_y);
            int manhatten_child_number = child.New_Manhatten(zero_x, zero_y);

            child.zero_y = zero_y - 1;
            child.last_move = "left";

            child.movments++;

            if (hamming_node_number > hamming_child_number)
                child.hamming--;
            else if (hamming_node_number < hamming_child_number)
                child.hamming++;


            if (manhatten_node_number > manhatten_child_number)
                child.manhatten -= Math.Abs(manhatten_node_number - manhatten_child_number);
            else if (manhatten_node_number < manhatten_child_number)
                child.manhatten += Math.Abs(manhatten_node_number - manhatten_child_number);


            child.fn_ham = child.hamming + child.movments;
            child.fn_man = child.manhatten + child.movments;


            return child;
        }
        public Node MoveRight(Node node)
        {
            Node child = new Node(node);
            int manhatten_node_number = node.New_Manhatten(zero_x, zero_y + 1);
            int hamming_node_number = node.New_Hamming(zero_x, zero_y + 1);
            
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y + 1];
            child.board[zero_x, zero_y + 1] = 0;
            
            int hamming_child_number = node.New_Hamming(zero_x, zero_y);
            int manhatten_child_number = child.New_Manhatten(zero_x, zero_y);

            child.zero_y = zero_y + 1;
            child.last_move = "right";

            child.movments++;
            if (hamming_node_number > hamming_child_number)
                child.hamming--;
            else if (hamming_node_number < hamming_child_number)
                child.hamming++;

            if (manhatten_node_number > manhatten_child_number)
                child.manhatten -= Math.Abs(manhatten_node_number - manhatten_child_number);
            else if (manhatten_node_number < manhatten_child_number)
                child.manhatten += Math.Abs(manhatten_node_number - manhatten_child_number);

            child.fn_ham = child.hamming + child.movments;
            child.fn_man = child.manhatten + child.movments;

            
            return child;
        }

        public List<string> getDirections()
        {
            List<string> directions = new List<string>();
            // top left corner
            if (this.zero_x == 0 && this.zero_y == 0)
            {
                directions.Add("right");
                directions.Add("down");
            }

            // top right corner
            else if (this.zero_x == 0 && this.zero_y == this.N - 1)
            {
                directions.Add("left");
                directions.Add("down");
            }
            // bottom left corner
            else if (this.zero_x == this.N - 1 && this.zero_y == 0)
            {
                directions.Add("up");
                directions.Add("right");
            }

            // bottom right corner
            else if (this.zero_x == this.N - 1 && this.zero_y == this.N - 1)
            {
                directions.Add("left");
                directions.Add("up");
            }
            // 3al 7arf top -> 3 possabilities
            else if (this.zero_x == 0)
            {
                directions.Add("right");
                directions.Add("left");
                directions.Add("down");
            }
            // 3al 7arf bottom -> 3 possabilities
            else if (this.zero_x == this.N - 1)
            {
                directions.Add("right");
                directions.Add("left");
                directions.Add("up");
            }
            // 3al 7arf left -> 3 possabilities
            else if (this.zero_y == 0)
            {
                directions.Add("up");
                directions.Add("down");
                directions.Add("right");
            }
            // 3al 7arf right -> 3 possabilities
            else if (this.zero_y == this.N - 1)
            {
                directions.Add("up");
                directions.Add("down");
                directions.Add("left");
            }
            // middle -> 4 possabilities
            else
            {
                directions.Add("up");
                directions.Add("down");
                directions.Add("left");
                directions.Add("right");
            }
            return directions;
        }
        public bool ISolved()
        {
            if (hamming == 0)
                return true;
            if (manhatten == 0)
                return true;

            return false;
        }
        public void OptimalSteps(Node node)
        {
            if (node.parent == null)
            {
                Display(node);
                return;
            }
            OptimalSteps(node.parent);
            Display(node);
        }

        public void Display(Node node)
        {
            Console.WriteLine("#" + node.movments);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(node.board[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(node.last_move);
            //Console.WriteLine("Hamming = {0} , Manhatten = {1}", node.hamming, node.manhatten);
            Console.WriteLine("---------------------------------------------");
                
        }
        private void Manhatten() // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
        {
            int row_goal;
            int col_goal;
            int number;
            int manhatten = 0;

            for (int i = 0; i < this.board.Length; i++)
            {
                number = this.board[i / N, i % N];
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


        private int New_Hamming(int x, int y) //O(1)
        {
            int number = board[x, y];
            int row_goal = (number - 1) / N;
            int col_goal = (number - 1) % N;

            if (row_goal != x || col_goal != y)
                return 1;
            
            return 0;
        }

        private int New_Manhatten(int x , int y)  //O(1)
        {
            int number = board[x, y];
            int row_goal = (number - 1) / N;
            int col_goal = (number - 1) % N;

            int manhatten_of_number = (Math.Abs(row_goal - x) + Math.Abs(col_goal - y));

            return manhatten_of_number;
        }
    }

}

