# Find the longest palindrom in a string.

# Ex: input: helloabamadambye               output: "madam"
# Ex: input: Madam is in a Doom mood now.   output: " doom mood "
# Ex: input: Nothing to see here:           output: "ere"
# Ex: input: halfamoominthis                output: "moom"

def longest_palindrome(in_str):
    max_pal = mh = ml = 0
    for i in range(len(in_str)):
        max_pal, mh, ml = check_palindrome(i, i,     in_str, max_pal, mh, ml) # odd  palindromes
        max_pal, mh, ml = check_palindrome(i, i + 1, in_str, max_pal, mh, ml) # even palindromes
    return in_str[ml:mh+1]

def check_palindrome(l, h, in_str, max_pal, mh, ml):
    while l >=0 and h < len(in_str) and in_str[l] == in_str[h]:
        pal = h - l + 1
        if(pal > max_pal):                 # If we find a longer palidrome,
            max_pal, mh, ml = pal, h, l    # track its length, startindex and,
        h, l = h + 1, l - 1                # endindex for future comparisons
    return (max_pal, mh, ml)   

print longest_palindrome('helloabamadambye')
print longest_palindrome('moom')
print longest_palindrome('Madam is in a doom mood now')
print longest_palindrome('Nothing to see here')
print longest_palindrome('halfamoominthis')

