namespace Algorithm.Sort.Library
{
    using System;

    public class HeapSort
    {
        /// <summary>
        /// A heap is built out of the data. The heap is often placed in an array with the layout of a complete binary tree. 
        /// The complete binary tree maps the binary tree structure into the array indices; each array index represents a node; the index of the node's parent, left child branch, or right child branch are simple expressions. 
        /// For a zero-based array, the root node is stored at index 0; if i is the index of the current node, then
        /// iParent     = floor((i-1) / 2)
        /// iLeftChild  = 2*i + 1
        /// iRightChild = 2*i + 2
        /// Parent value should be smaller/greater than left child and right child value.
        /// k(i) <= k(2i) && k(i) <= k(2i+1)
        /// k(i) >= k(2i) && k(i) >= k(2i+1)
        /// So root value of a heap is always max or min.
        /// </summary>
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            // initializing status: unordered array
            BuildHeap(array, sortType);

            for (int i = array.Length - 1; i > 0; i--)
            {
                // swap root element of heap with the last element in unordered array
                // to make root element of heap in order
                Common.Swap(ref array[0], ref array[i]);
                // re-heapify unordered array
                Heapify(array, 0, i, sortType);
            }
        }

        private static void BuildHeap<T>(T[] array, SortType sortType) where T : IComparable
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, i, array.Length, sortType);
            }
        }

        private static void Heapify<T>(T[] array, int currentIndex, int heapSize, SortType sortType) where T : IComparable
        {
            int left = 2 * currentIndex + 1; // left child
            int right = 2 * currentIndex + 2; // right child
            int parent = currentIndex; // record the max/min element among parent, left and right nodes

            if (left < heapSize && !Common.IsInOrder(array[left], array[parent], sortType)) // compare with left child
            {
                parent = left;
            }

            if (right < heapSize && !Common.IsInOrder(array[right], array[parent], sortType)) // compare with right child
            {
                parent = right;
            }

            if (parent != currentIndex)
            {
                Common.Swap(ref array[currentIndex], ref array[parent]);
                Heapify(array, parent, heapSize, sortType);
            }
        }
    }
}