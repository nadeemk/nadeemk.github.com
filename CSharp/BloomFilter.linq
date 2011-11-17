<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

/// 
// Creating a Bloom Filter
// Bloom filters are a data structure used to test for set membership of
// and element. They can tell whether an element is a member of a set with
// a certainly probability but they can confirm that an element is not a 
// member of a set with absolute certainty.

// Bloom filters are implemented as bit arrays of size 'm'
// During load
// 	a) 'k' hashes of an element are computed' ( k < m)
//  b) k hash values can be used to set k bits in the bit array.
// During test
//  a) 'k' hash values are computed again using same technique as during load
//  b) The bits corresponding to k hash values are compared again 
//  c) If they are all set to 1, then element is present (with certain probability)
//  d) They any is set 0, then element in NOT present with probability = 1.

void Main()
{
	const string path_to_dict = @"C:\Users\nadeem\Dropbox\Public\Algorithms\resources\wordlist.txt";
	Console.WriteLine(Directory.GetCurrentDirectory());
	string[] words = File.ReadAllLines(path_to_dict);
	Console.WriteLine(words.Length);
	for(int i = 1; i < 26; i++) 
	{
		TestFilter(words, 4, words.Length * i);
	}
	
}

void TestFilter(string[] words, int k, int m) 
{
	// Create a bloom filter of a given size and # of hash values.
	BloomFilter bfilter = new BloomFilter(k, m);
	
	// Also create a HashSet for comparison
	HashSet<string> hset = new HashSet<string>();
	
	// Load the bloom filter and the hashset
	foreach(string word in words) 
	{
		bfilter.addWord(word);
		hset.Add(word);
	}
	
	// False Positive Testing
	// Test 1000 randomly generated numbers
	int count = 0;
	int falsePositives = 0, truePositives = 0, falseNegative = 0, trueNegative = 0;
	while(count < 1000) 
	{
		string word = RandomNumber.GenerateRandomString(5);
		if(bfilter.isSet(word)) 
		{
			if(hset.Contains(word)) 
			{
				Console.WriteLine("True Positive {0}", word);
				truePositives++;
			}
			else 
			{
				falsePositives++;
			}
		} 
		else 
		{
			if(hset.Contains(word)) 
			{
				falseNegative++;
			}
			else 
			{
				trueNegative++;
			}
		}
		count++;
	}
	
	Console.WriteLine("Total false positives {0}", falsePositives);
	Console.WriteLine("Total true positives {0}", truePositives);
	Console.WriteLine("Total false negatives {0}", falseNegative);
	Console.WriteLine("Total true negatives {0}", trueNegative);
	
	Console.WriteLine(" (k = {0}, m/n = {1}) False Positive Ratio {2} %", k, m/(words.Length), (falsePositives * 1.0 / (falsePositives + trueNegative)) * 100);
}

public static class RandomNumber 
{
	static Random r = new Random();
	
	public static string GenerateRandomString(int size) 
	{
			StringBuilder sb = new StringBuilder();
			int count = 0;
			while(count < size)
			{
				char c = (char)('a' + r.Next(26));
				sb.Append(c);
				count++;
			}
			//Console.WriteLine("Random string generated: {0}", sb.ToString());
			return sb.ToString();
	}
}

public class BloomFilter 
{
	private BitArray bitMap;
	private int k;
	private int m;
	
	// k is # of hashes to use and m is size of bitmap
	public BloomFilter(int k, int m) 
	{
	 	this.bitMap = new BitArray(m);
		this.k = k;
		this.m = m;
	}

	public void addWord(string word) 
	{
		uint[] intVals = ComputeHash(word, new MD5CryptoServiceProvider());
		
		for(int i = 0; i < intVals.Length; i++) 
		{
			int idx = (int)(intVals[i] % m);  //assuming m i less than max value of int.
			this.bitMap.Set(idx, true);
		}
	}
	
	public bool isSet(string word) 
	{
		uint[] intVals = ComputeHash(word, new MD5CryptoServiceProvider());
		
		for(int i = 0; i < intVals.Length; i++) 
		{
		    int idx = (int)(intVals[i] % m);
			if(!bitMap.Get(idx)) 
			{	
				//Console.WriteLine("{0} does NOT exist", word);
				return false;
			}
		}
		
		//Console.WriteLine("{0} does exist", word);
		return true;
	}
	
	private uint[] GetIntValues(Byte[] hash) 
	{
		int count = 0, index = 0;
		uint[] op = new uint[this.k];
		while( count < this.k)
		{
			op[count] = GetIntForBytes( hash, index );
			count++; 
			index+=4; // Get the next 4 bytes.
		}
		return op;
	}
	
	private uint[] ComputeHash(string input, HashAlgorithm h) 
	{
		UTF8Encoding encoding = new UTF8Encoding();
		Byte[] bytes = encoding.GetBytes(input);
		
		return GetIntValues(h.ComputeHash(bytes));
	}
	
	private uint GetIntForBytes(Byte[] bytes, int index) 
	{
		// return BitConverter.ToInt32( hash, index );
		uint val = 0;
		int lshift = 0; 
		int start = index; 
		int end = start + 4;
		
		while( start < end ) 
		{
			val |= ( (uint)0 | bytes[start] ) << lshift;
			lshift += 8;
			start++;
		}
		
		return val;
	}
}

// MD5CryptoServiceProvider, SHA256Managed, SHA1CryptoServiceProvider
// Define other methods and classes here
