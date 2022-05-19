using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Node
    {
        int zero_x;
        int zero_y;
     //   public string id;
        public int[,] board;
        public int N;
        public int movments = 0;
        public int manhatten;
        public int hamming;
        public int fn_ham;         // hamming + #movment
        public int fn_man;         // manhatten + #movment 
        public string last_move;
        public Node parent;

        public Node(int[,] board,int zero_x,int zero_y,bool hamming)
        {

            
            this.N = (int)Math.Sqrt(board.Length);
            this.zero_x    = zero_x;
            this.zero_y    = zero_y;
            this.last_move = "none";

            this.board = new int[N, N];
            this.parent = null;
            
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    this.board[i, j] = board[i, j];
   //                 id += String.Join(" ", board[i, j]);
                }
            

            if (hamming)
                Hamming();
            else
                Manhatten();
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

        public Node MoveUp(Node node,bool hamming)   //O(N^2)
        {
            Node child = new Node(node); //O(N^2)
            
            child.board[zero_x, zero_y] = child.board[zero_x - 1, zero_y];
            child.board[zero_x - 1, zero_y] = 0;            

            child.zero_x = zero_x - 1 ;
            child.last_move = "up";

            child.movments++;
            //child.CalculateID(child.board);

            if (hamming)
            {
                child.New_Hamming(zero_x - 1, zero_y, zero_x, zero_y, node);
                return child;
            }

            child.New_Manhatten(zero_x - 1, zero_y, zero_x, zero_y, node);
            return child;
        }
        public Node MoveDown(Node node,bool hamming)
        {
            Node child = new Node(node);

            child.board[zero_x, zero_y] = child.board[zero_x + 1, zero_y];
            child.board[zero_x + 1, zero_y] = 0;

            child.zero_x = zero_x + 1;
            child.last_move = "down";

            child.movments++;
           // child.CalculateID(child.board);

            if (hamming)
            {
                child.New_Hamming(zero_x + 1, zero_y, zero_x, zero_y, node);
                return child;
            }

            child.New_Manhatten(zero_x + 1, zero_y, zero_x, zero_y, node);
            return child;
        }
        public Node MoveLeft(Node node, bool hamming)
        {
            Node child = new Node(node);

            child.board[zero_x, zero_y] = child.board[zero_x, zero_y - 1];
            child.board[zero_x, zero_y - 1] = 0;

            
            child.zero_y = zero_y - 1;
            child.last_move = "left";

            child.movments++;
           // child.CalculateID(child.board);

            if (hamming)
            {
                child.New_Hamming(zero_x, zero_y-1, zero_x, zero_y, node);
                return child;
            }

            child.New_Manhatten(zero_x, zero_y-1, zero_x, zero_y, node);
            return child;
        }
        public Node MoveRight(Node node, bool hamming)
        {
            Node child = new Node(node);
            
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y + 1];
            child.board[zero_x, zero_y + 1] = 0;
            
            child.zero_y = zero_y + 1;
            child.last_move = "right";

            child.movments++;
        //    child.CalculateID(child.board);

            if (hamming)
            {
                child.New_Hamming(zero_x , zero_y+1, zero_x, zero_y, node);
                return child;
            }

            child.New_Manhatten(zero_x, zero_y+1, zero_x, zero_y, node);
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
        
        public bool ISolved(bool hamming)
        {
            if (hamming && this.hamming == 0)
                return true;
            
            else if (!hamming && this.manhatten == 0)
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

        private void New_Hamming(int old_pos_x, int old_pos_y,int new_pos_x, int new_pos_y,Node node) //O(1)
        {
            int number = node.board[old_pos_x, old_pos_y];
            int row_goal = (number - 1) / N;
            int col_goal = (number - 1) % N;
            int old_hamming = 0;
            int new_hamming = 0;
            if (row_goal != old_pos_x || col_goal != old_pos_y)
                old_hamming = 1;

            if (row_goal != new_pos_x || col_goal != new_pos_y)
                new_hamming = 1;

            if (old_hamming > new_hamming)
                this.hamming--;
            else if (old_hamming < new_hamming)
                this.hamming++;

            this.fn_ham = this.hamming + this.movments;
        }

        private void New_Manhatten(int old_pos_x, int old_pos_y, int new_pos_x, int new_pos_y,Node node)  //O(1)
        {
            int number = node.board[old_pos_x, old_pos_y];
            int row_goal = (number - 1) / N;
            int col_goal = (number - 1) % N;
            
            int old_manhatten_of_number = (Math.Abs(row_goal - old_pos_x) + Math.Abs(col_goal - old_pos_y));
            
            int new_manhatten_of_number = (Math.Abs(row_goal - new_pos_x) + Math.Abs(col_goal - new_pos_y));

            if (new_manhatten_of_number > old_manhatten_of_number)
                this.manhatten += Math.Abs(new_manhatten_of_number - old_manhatten_of_number);
            else if (new_manhatten_of_number < old_manhatten_of_number)
                this.manhatten -= Math.Abs(new_manhatten_of_number - old_manhatten_of_number);

            this.fn_man =this.manhatten + this.movments;
        }
   
/*        private void CalculateID(int[,] board)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    this.id += String.Join(" ", board[i, j]);
        }
*/    }

}

