# Reverse pairs in a linked list


class Node:
    def __init__(self, val):
        self.item = val
    next = None

    def f(self):
        print self.item

## Core Algorithm ##

def reversePairs(t):
    if t == None or t.next == None: return t

    startOfNextPair = reversePairs(t.next.next)

    t.next.next = t
    startOfThisPair = t.next
    t.next = startOfNextPair

    return startOfThisPair 
    
####################

def createList(nums):
    count = 0;
    if not nums: return None
    
    t = Node(nums[count])
    count = count + 1 
    start = t
    while count < len(nums):
        t.next = Node(nums[count])
        count = count + 1
        t  = t.next

    t.next = None
    return start

def printList(start):
    while start != None:
        print start.item,
        start = start.next
    print


def test(l):
    m = createList(l)
    print 'Before \t',
    printList(m)
    m = reversePairs(m)
    print 'After \t',
    printList(m)

## Regular Test Case
    
## Odd numbers test case
test([1,2,3,4])
test([1,2,3,4,5])
test([1,2])
test([1])
test([])


 
    
    


