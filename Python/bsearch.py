

def binary_search(arr, num):
    if not arr: return -1
    
    while arr:
        print arr
        lo, hi = 0, len(arr) - 1
        mid = lo + (hi - lo) / 2
        print mid
        if arr[mid] == num :  return mid

        if arr[mid] < num :
            arr = arr[mid+1:]
        else:
            arr = arr[:mid]

    return -1


print binary_search([1,2,3,4,5,6,7], 6) == 5
print binary_search([1,2,3,4,5,6,7], 2) == 1
print binary_search([1,2,3,4,5,6,7], 4) == 3
print binary_search([1,2,3,4,5,6,7], 9) == -1
