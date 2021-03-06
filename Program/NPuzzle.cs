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

        public static Node Solve(int[,]board,int zero_x,int zero_y,bool hamming) // bounded by O(E log(V)), E is the total number of moves and V is the number of states till reaching to the solution 
        {
            //3.	IF SOLVABLE, apply A* search algorithm 
            PriorityQueue queue = new PriorityQueue();
            Node node = new Node(board, zero_x, zero_y,hamming);
            List<string> direction = new List<string>();
            HashSet<string> closedlist = new HashSet<string>();

            Node new_node = null;
            queue.Enqueue(node,hamming);
            do
            {
                direction.Clear();
                direction = node.getDirections(); //O(1)

                if (direction.Contains("up") && node.last_move != "down")
                {
                    new_node = node.MoveUp(node,hamming);
                    if (!closedlist.Contains(new_node.id))
                        queue.Enqueue(new_node, hamming);

                }
                if (direction.Contains("down") && node.last_move != "up")
                {
                    new_node = node.MoveDown(node,hamming);
                    if (!closedlist.Contains(new_node.id))
                        queue.Enqueue(new_node, hamming);

                }
                if (direction.Contains("left") && node.last_move != "right")
                {
                    new_node = node.MoveLeft(node,hamming);
                    if (!closedlist.Contains(new_node.id))
                        queue.Enqueue(new_node, hamming);

                }
                if (direction.Contains("right") && node.last_move != "left")
                {
                    new_node = node.MoveRight(node,hamming);
                    if (!closedlist.Contains(new_node.id))
                        queue.Enqueue(new_node, hamming);
                }
                
                node = queue.Dequeue(hamming);
                closedlist.Add(node.id);

                //node.Display(node);
/*                Console.WriteLine(node.last_move);
                Console.WriteLine("Hamming = {0} , Manhatten = {1}, Movment= {2}", node.hamming, node.manhatten, node.movments);*/

            } while (!node.ISolved(hamming));



            //4.	Print a STEP by STEP movements occur in the A* algorithms till you reach the final solvable board.
            
    
            return node;            
        }
    }
}
