# CTCI 1.7 Set To Zero
## Cracking the Coding Interview, Chapter 1, Problem 1.7
### Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.

Work in 2 passes. All modifications are in-place.

Complexity: 

Algorithm runs in O(N) time. Every element is touched once to check for zero. Column-0 and Row-0 are checked twice. If zeros are found, then the elements in that column and row are set to zero.

Algorithm requires O(1) space. Memory usage remains constant regardless of input size. Edits are in-place.
