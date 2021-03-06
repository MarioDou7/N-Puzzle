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

        public void Enqueue(Node node, bool hamming)  //O(log(V)) V number of elements in the queue
        {
            boards.Add(node);
            if (boards.Count == 1)
                return;

            SortHeap(ref boards, hamming);


        }
        public void Clear()
        {
            boards.Clear();
        }
        public Node Dequeue(bool hamming) //O(log(V)) V number of elements in the queue
        {
            Node root = boards[0];
            boards[0] = boards[boards.Count - 1];
            boards.RemoveAt(boards.Count - 1);
            DownWordExchange(hamming, 1);
            return root;
        }
        private void SortHeap(ref List<Node> boards, bool hamming) // true hamming , false Manhatten  O(log(V)) V number of elements in the queue
        {
            int i = boards.Count;
            if (hamming)
            {

                while (i > 1)
                {
                    if (Parent(i).cost > boards[i - 1].cost)
                        Swap(ref boards, (i / 2) - 1, i - 1);
                    else if (Parent(i).cost == boards[i - 1].cost && Parent(i).hamming > boards[i - 1].hamming)
                        Swap(ref boards, (i / 2) - 1, i - 1);
                    else
                        return;

                    i /= 2;

                }
                return;
            }

            while (i > 1 )
            {
                if (Parent(i).cost > boards[i - 1].cost)
                    Swap(ref boards, (i / 2) - 1, i - 1);
                else if (Parent(i).cost == boards[i - 1].cost && Parent(i).manhatten > boards[i - 1].manhatten)
                    Swap(ref boards, (i / 2) - 1, i - 1);
                else
                    return;

                i /= 2;

            }

        }
        private void Swap(ref List<Node> boards, int pos1, int pos2)  // swap the nodes O(1)
        {
            Node temp = boards[pos1];
            boards[pos1] = boards[pos2];
            boards[pos2] = temp;
        }
        private void DownWordExchange(bool hamming, int i) // O(log(V)) V number of elements in the queue
        {
            int left = i * 2;
            int right = (i * 2) + 1;
            int minmum;

            if (hamming)
            {
                if(left <= boards.Count)
                {
                    if ((boards[left - 1].cost < boards[i - 1].cost))
                        minmum = left;
                    else if (boards[left - 1].cost == boards[i - 1].cost && boards[left - 1].hamming < boards[i - 1].hamming)
                        minmum = left;
                    else minmum = i;
                }
                else
                    minmum = i;

                if (right <= boards.Count)
                {
                    if (boards[right - 1].cost < boards[minmum - 1].cost)
                        minmum = right;
                    else if ((boards[right - 1].cost == boards[minmum - 1].cost) && (boards[right - 1].hamming < boards[minmum - 1].hamming))
                        minmum = right;
                }
                if (minmum != i)
                {
                    Swap(ref boards, minmum - 1, i - 1);
                    DownWordExchange(hamming, minmum);
                }
                return;
            }

            if (left <= boards.Count)
            {
                if ((boards[left - 1].cost < boards[i - 1].cost))
                    minmum = left;

                else if (boards[left - 1].cost == boards[i - 1].cost && boards[left - 1].manhatten < boards[i - 1].manhatten)
                    minmum = left;

                else minmum = i;
            }
            else
                minmum = i;

            if (right <= boards.Count)
            {
                if (boards[right - 1].cost < boards[minmum - 1].cost)
                    minmum = right;
                else if ((boards[right - 1].cost == boards[minmum - 1].cost) && (boards[right - 1].manhatten < boards[minmum - 1].manhatten))
                    minmum = right;
            }

            if (minmum != i)
            {
                Swap(ref boards, minmum - 1, i - 1);
                DownWordExchange(hamming, minmum);
            }
        }
        private Node Parent(int index_ofChild)  // return the parent node O(1)
        {
            return boards[(index_ofChild / 2) - 1];
        } 

        
    }

}
