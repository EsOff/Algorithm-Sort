# Algorithm-Sort

## Intents to create this repository:
1. Learn how to use Git and GitHub.
2. Manage personal study code in cloud.
3. Learn and share with each other.

## Problem sorting solutions

Definition In-Place: Sorting algorithm do not require any extra space is a in-place algorithm, otherwise, it's not a in-place algorithm.

Definition Stability: A sort is stable if elements with the same key retain their original order after sorting. Any sorting algorithm can be made stable by the addition of extra data containing the original order of the data. This would stop the sort from being in-place. 

### Basic algorithms

1. Bubble Sort: stable and in-place. It's only practical if the input is ususally in sort order but may occasionally have some out-of-order elements nearly in position.
<br/> 1) Average case - O(n2)

2. Insertion Sort: stable and in-place. It's efficient for small data sets.
<br/> 1) Average case - O(n2)

3. Binary Insertion Sort: an insertion sort variant.
<br/> 1) Average case - O(n2)

4. Selection Sort: not stable but in-place.
<br/> 1) Average case - O(n2)

5. Heap Sort: not stable but in-place, an improved selection sort.
<br/> 1) Average case - O(n log n)

6. Merge Sort: stable but not in-place.
<br/> 1) Average case - O(n log n)

7. Quick Sort: not stable but in-place. Random selecting pivot can make sure we always have lucky cases: (1) running time is independent of input ordering (2) no assumptions about the input distribution.
<br/> 1) Average case - O(n log n)

8. Shell Sort: stable and in-place.
<br/> 1) Average case - depends on steps, for 2^k -1, O(N^{3/2})

### Advanced algorithms

1. In-Place Stable Merge Sort: merge sort with a smart in place merge that 'rotates' the sub arrays.
<br/> 1) Average case - O(n log n)

2. In-Place Stable Quick Sort: it differs from traditional quicksort in that instead of swapping elements that need to be pivotted, runs of elements are rotated around to maintain stability.
<br/> 1) Average case - O(n log n log n)

### Summary

1. Blocks smaller than 16 are sorted using binary insertion sort. This usually speeds up sorting.
