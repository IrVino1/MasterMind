Create a C# console application that is a simple version of Mastermind. 
The randomly generated answer should be four (4) digits in length, with each digit between the numbers 1 and 6. 
After the player enters a combination, a minus (-) sign should be printed for every digit that is correct but in the wrong position, 
and a plus (+) sign should be printed for every digit that is both correct and in the correct position. Print all plus signs first, all minus signs second, 
and nothing for incorrect digits.
The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.

Example:

If the secret answer were: 1234

And the user guessed: 4233

The hint should be: ++--


Assumptions:
1. In the random generated input, both 1 and 6 are valid digits (1,2,3,4,5,6 are all valid). Repeated digits are allowed.
2. If user enters wrong input: ie letters , digits out of range, length not equal 4 etc, it is still counted against maximum number of allowed attempts. 