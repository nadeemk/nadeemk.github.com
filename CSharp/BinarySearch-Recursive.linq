<Query Kind="Program" />

void Main()
{
	Console.WriteLine(assert_equal(-1, binary_search(3, new int[]{})));
	Console.WriteLine(assert_equal(-1, binary_search(3, new int[]{1})));
	Console.WriteLine(assert_equal(0,  binary_search(1, new int[]{1})));
	Console.WriteLine(assert_equal(-1, binary_search(-6, new int[]{})));
	Console.WriteLine(assert_equal(0,  binary_search(1, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(1,  binary_search(3, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(2,  binary_search(5, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(-1, binary_search(0, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(-1, binary_search(2, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(-1, binary_search(4, new int[]{1, 3, 5})));
	Console.WriteLine(assert_equal(-1, binary_search(6, new int[]{1, 3, 5})));
	
	Console.WriteLine(assert_equal(0,  binary_search(1, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(1,  binary_search(3, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(2,  binary_search(5, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(3,  binary_search(7, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(-1, binary_search(0, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(-1, binary_search(2, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(-1, binary_search(4, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(-1, binary_search(6, new int[]{1, 3, 5, 7})));
	Console.WriteLine(assert_equal(-1, binary_search(8, new int[]{1, 3, 5, 7})));
}

bool assert_equal( int a, int b) 
{
	return a == b;
}

int binary_search(int x, int[] a) 
{
	if(a == null || a.Length == 0) return -1;
	
	return doSearch(x, a, 0, a.Length-1);	
}


int doSearch(int x, int[] a, int l, int u) 
{
	if( l > u ) return -1;
	
	int mid = l + ( u - l ) / 2;
	
	if( a[mid] == x ) 
	{
		return mid;
	}
	if( a[mid] > x ) 
	{
		return doSearch(x, a, l, mid - 1);
	}
	else 
	{
		return doSearch(x, a, mid + 1, u);
	}
}

