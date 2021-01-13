# PEDA(C)

**P**rocess the Problem Understand the Problem
**E**xamples/Test Case Validate understanding of the problem
**D**ata Structure How we represent data that we will work with when converting the input to output.
**A**lgorithm Steps for converting input to output
**C**ode with Intent Code Implementation of Algorithm

## The Problem

"Find the largest number in a list." <- Understandable and Explicit.

Requirements:
The input and output only deals with Integers.
// Any inut not an integer is ignored.

Input: A list of number
Output: The largest number

## Examples

Input: <4, 8, 15, 16, 23 and 42>
Output: 42

Input: <42, 144, 256, 3>
Output: 256

## Data Structure

An array of Integers (the input), An Integer (the largest number)

## Algorithm

Brenda(tio)n; sort from largest to smallest, select the first one [0].
Kofi; order from smallest to largest, return the last one.
Joe; Pick up two, throw the smallest away, until only one left. (Really annoying).

> Make two variables, `current`, `largestSoFar`; intializing `largestSoFar` to 0  
> Go through the list,  
> ...ask if `current` is larger then `largestSoFar`  
> ......if it is, replace `largestSoFar` with the value of current.  
> ......otherwise, continue, making `current` the next item in the list.  
> return `largestSoFar`

Code:

```
int[] array = {16, 23, 8, 15, 4, 42};
int largestSoFar = 0;
for (current = 0 in array) {
  if (current > largestSoFar) {
    largestSoFar = current;
  }
}
return largestSoFar;
```

P E D A (C)!
