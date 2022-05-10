using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class PriorityQueue
    {
        List<Node> boards;


        public PriorityQueue()
        {
            boards = new List<Node>();
        }

        public void Enqueue(Node board,bool hamming)
        {
            boards.Add(board);
            if (boards.Count == 1)
                return;

            SortHeap(ref boards, hamming);


        }

        private void SortHeap(ref List<Node> boards, bool hamming) // true hamming , false Manhatten
        {
            int i = boards.Count - 1;
            if (hamming)
            {

                while (i > 1 && (Parent(i).fn_ham > boards[i].fn_ham || Parent(i).hamming > boards[i].hamming))
                {
                    Swap(i / 2, i);
                    i /= 2;

                }
                return;
            }

            while (i > 1 && (Parent(i).fn_man> boards[i].fn_man || Parent(i).manhatten > boards[i].manhatten))
            {
                Swap(i/2, i);
                i /= 2;
            }

        }
        private void Swap(int pos1,int pos2)
        {
            Node temp = boards[pos1];
            boards[pos1] = boards[pos2];
            boards[pos2] = temp;
        }    // swap the nodes
        private Node Parent(int index_ofChild)
        {
            return boards[index_ofChild/2];
        }  // return the parent node

    
    }

}
