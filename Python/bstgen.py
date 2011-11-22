# Generate a binary search tree from its pre order and in order traversal

# Original tree looks like:
#       10
#    7       15
#  5   8  12    17

# Pre-order looks like 10, 7, 5, 8, 15, 12, 17
# In-order looks like  5, 7, 8, 10, 12, 15, 17

# step 1:  root: 10
#   Preorder splits  into: (7, 5, 8) (15, 12, 17)
#   Inorder  splits  into: (5, 7, 8) (12, 15, 17)
#
# step 2a) root: 7 (determine left node of root from step 1)
#   Inorder  splits  into: (5)  (8) 
#   Preorder splits  into: (5)  (8) 
#
# step 2b) root: 15 (determine right node of root from step 1)
#   Inorder  splits  into: (12)  (17) 
#   Preorder splits  into: (12)  (17) 
#
class Node:
    def __init__(self, val):
        self.data  = val
        self.left  = None
        self.right = None

def generate_bst(inorder, preorder):
    root_node = bst(inorder, preorder, 0, len(inorder) - 1, 0, len(preorder) - 1)
    return root_node

def bst(inorder, preorder, in_start, in_end, pre_start, pre_end):
    root, pos = Node(preorder[pre_start]), inorder.index(preorder[pre_start]) - in_start
    
    if pre_start == pre_end:
        return root        

    root.left  = bst(inorder, preorder, in_start, pos - 1, pre_start + 1      , pre_start + pos)
    root.right = bst(inorder, preorder, pos + 1 , in_end , pre_start + pos + 1, pre_end)

    print "Root: ", root.data, " Left: ", root.left.data, " Right: ", root.right.data  
    
    return root 



generate_bst([5, 7, 8, 10, 12, 15, 17], [10, 7, 5, 8, 15, 12, 17])

