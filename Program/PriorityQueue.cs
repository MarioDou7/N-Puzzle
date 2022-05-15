using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class PriorityQueue
    {
        public List<Node> boards;


        public PriorityQueue()
        {
            boards = new List<Node>();
        }

        public void Enqueue(Node node,bool hamming)
        {
            boards.Add(node);
            if (boards.Count == 1)
                return;

            SortHeap(ref boards, hamming);


        }

        private void SortHeap(ref List<Node> boards, bool hamming) // true hamming , false Manhatten
        {
            int i = boards.Count;
            if (hamming)
            {

                while (i > 1 && (Parent(i).fn_ham > boards[i-1].fn_ham || Parent(i).hamming > boards[i-1].hamming))
                {
                    Swap(ref boards ,(i/ 2)-1, i-1);
                    i /= 2;

                }
                return;
            }

            while (i > 1 && (Parent(i).fn_man> boards[i-1].fn_man || Parent(i).manhatten > boards[i-1].manhatten))
            {
                Swap(ref boards, (i /2)-1, i-1);
                i /= 2;
            }

        }
        private void Swap(ref List<Node>boards ,int pos1,int pos2)  // swap the nodes
        {
            Node temp = boards[pos1];
            boards[pos1] = boards[pos2];
            boards[pos2] = temp;
        }    
        private Node Parent(int index_ofChild)  // return the parent node
        {
            return boards[(index_ofChild/2)-1];
        }  

    
    }

}
