<Query Kind="Program" />

class Node 
{
	public Node(int val) 
	{
		value = val;
	}
	
	public int value {get; set;}
	public Node next { get; set;}
}

void Main()
{
	Node t = CreateNode(new int[] {1, 2, 3, 4});
	PrintNodes(t);
	Node start = Pairs(t);
	PrintNodes(start);
	
	t = CreateNode(new int[] {1, 2, 3});
	PrintNodes(t);
	start = Pairs(t);
	PrintNodes(start);
}

Node Pairs(Node t) 
{
	if(t == null) return t;
	if(t.next == null) return t;
	
	Node temp = Pairs(t.next.next);
	
	t.next.next = t;
	Node ret = t.next;
	t.next = temp;
	
	return ret;
}

void PrintNodes(Node t) 
{
	Console.WriteLine();
	while(t != null) 
	{
		Console.Write(t.value + "->");
		t = t.next;
	}
	
	Console.Write("NULL");
}

Node CreateNode(int[] list) 
{
	Node start;
	int count = 0;
	
	Node t = new Node(list[count++]);
	start = t;
	
	while(count < list.Length) 
	{
		t.next = new Node(list[count++]);
		t = t.next;
	}
	
	t.next = null;
	
	return start;
}


