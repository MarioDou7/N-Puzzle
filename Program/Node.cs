﻿using System;
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
        private void Manhatten() // The sum of the distances (sum of the vertical and horizontal distance) from the blocks to their goal position + number of moves made so far to get to the state.
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
        private void Hamming() // The number of blocks in the wrong position + the number of moves made so far to get to the state. 
        {            
            int len = board.Length;
            int N = (int)Math.Sqrt(len);
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
        }
        public Node MoveUp(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x - 1, zero_y];
            child.board[zero_x - 1, zero_y] = 0;

            child.Manhatten();
            child.Hamming();
            child.movments++;
            child.fn_ham = child.hamming  + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        public Node MoveDown(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x + 1, zero_y];
            child.board[zero_x + 1, zero_y] = 0;

            child.Manhatten();
            child.Hamming();
            child.movments++;
            child.fn_ham = child.hamming  + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        public Node MoveLeft(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y - 1];
            child.board[zero_x, zero_y - 1] = 0;

            child.Manhatten();
            child.Hamming();
            child.movments++;
            child.fn_ham = child.hamming  + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        public Node MoveRight(Node node)
        {
            Node child = new Node(node);
            child.board[zero_x, zero_y] = child.board[zero_x, zero_y + 1];
            child.board[zero_x, zero_y + 1] = 0;

            child.Manhatten();
            child.Hamming();
            child.movments++;
            child.fn_ham = child.hamming  + child.movments;
            child.fn_man = child.manhatten + child.movments;

            return child;
        }
        
    }

}
