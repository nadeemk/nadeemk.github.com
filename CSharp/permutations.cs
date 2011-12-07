// Computing the permutations of a string
/*
 The techique used here is called backtracking. In this technique
 we evaluate all possible (allowable) combinations of a solution by
 recursively going through the problem set.
 
 In the case of computing permutations, for every position of a
 character in a string, we will evaluate every other position of
 the other characters.
 
 for e.g. "abc"
 	abc,      bac,       cba
 abc, acb   bac, bca   cba, cab
*/

void Permute(char[] input, int start)
{
	if(start == input.Length)
	{
		Console.WriteLine(new String(input));
	}
	
	for(int i = start; i < input.Length; i++ )
	{
		swap(ref input, start, i);
		Permute(input, start + 1);
		swap(ref input, start, i);
	}
}

void swap(ref char[] input, int pos1, int pos2)
{
	char temp = input[pos1];
	input[pos1] = input[pos2];
	input[pos2] = temp;
}

void Main()
{
	string s = "abc";
	
	Permute(s.ToCharArray(), 0);
}
