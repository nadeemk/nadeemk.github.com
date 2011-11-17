# This is an implemenation of binary search which does not 
# directly return the mid value upon finding it rather it 
# continues until its high and low points are just next to 
# each other.

# The low and high value pointers are instantiated to be just
# out the lower and upper bound of the array. We calculate mid
# by selecting a point in the middle of these lower and upper 
# bounds. 

# If mid is greater than the number we are searching for
# we set the upper point to be mid. Otherwise (i.e. when the
# mid is lower or equal to the number we are looking for, 
# we set the lower bound to be mid.

# This techniques relies on the idiom that if we let binary 
# search go without stopping, are low and high pointeres will
# eventually next to each other. Following cases can occur

# Number exists once in the array - then the low pointer will 
# point to it since it has moved up to its position. 


def binary_search(arr, num):
    if not arr: return -1

    low, high = -1, len(arr)    # Point low and 

    while high - low > 1 : # Until low and high are just next to each other
        mid = high + low >> 1
        print low, high, mid
        if arr[mid] > num:
            high = mid
        else:
            low = mid
    
    if arr[low] == -1 or arr[low] != num:
        return -1

    return low

print binary_search([1,2,3,4,5,6,7], 6) == 5
print binary_search([1,2,3,4,5,6,7], 2) == 1
print binary_search([1,2,3,4,5,6,7], 4) == 3
print binary_search([1,2,3,4,5,6,7], 9) == -1

    
        

