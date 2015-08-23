namespace Algorithm.Sort.Library
{
    using System;

    public class MergeSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable, new()
        {
            SortIteration(array, array.Length, sortType);
        }

        private static T[] SortIteration<T>(T[] X, int n, SortType sortType) where T : IComparable, new()
        {
            // Recursive Stop-Condition, Sorting a Basic Array (Size 2)
            if (n == 2)
            {
                if (!Common.IsInOrder(X[0], X[1], sortType))
                {
                    Common.Swap(ref X[0], ref X[1]);
                }
            }
            // The Sub-Arrays size is large than 2
            else if (n > 2)
            {
                int m = n / 2;

                // Define 2 aid Sub-Arrays
                T[] A = new T[m];
                T[] B = new T[n - m];

                // Initialize the 2 Sub-Arrays
                for (int i = 0; i < m; i++)
                {
                    A[i] = new T();
                    A[i] = X[i];
                }
                for (int i = m; i < n; i++)
                {
                    B[i - m] = new T();
                    B[i - m] = X[i];
                }

                // 2 Recursive Calling, Sorting Sub-Arrays
                A = SortIteration(A, m, sortType);
                B = SortIteration(B, n - m, sortType);

                // Merging the Sorted Sub-Arrays into the Main Array
                MergeSortedArray(X, A, B, sortType);
            }

            return X;
        }

        /// <summary>
        /// Merge 2 sorted array.
        /// </summary>
        private static void MergeSortedArray<T>(T[] X, T[] A, T[] B, SortType sortType) where T : IComparable
        {
            if (X.Length == A.Length + B.Length)
            {
                int i = 0, j = 0, k = 0;

                while (i < A.Length && j < B.Length)
                {
                    if (Common.IsInOrder(A[i], B[j], sortType))
                    {
                        X[k++] = A[i++];
                    }
                    else
                    {
                        X[k++] = B[j++];
                    }
                }

                while (i < A.Length)
                {
                    X[k++] = A[i++];
                }

                while (j < B.Length)
                {
                    X[k++] = B[j++];
                }
            }
        }
    }
}
