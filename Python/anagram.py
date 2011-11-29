# Print all anagrams next to each other

MIN_ANAGRAM_SET  = 2 # Minimum number of anagrams in a set of anagrams
MIN_ANAGRAM_SIZE = 10 # Size of the anagrams.
#dictionary =  'resources/wordlist.txt'
dictionary =  '/usr/share/dict/words'

def print_anagrams():
    anagram_dict = {}
    with open(dictionary, 'r') as f:
        for line in f:                               # for each word,
            sorted_word =  sort_string(line)         # get the equivalient
            if sorted_word in anagram_dict :
               list_anagrams = anagram_dict[sorted_word]
               list_anagrams.append(line)
            else:
               new_list = []
               new_list.append(line)  # with sorted chars
               anagram_dict[sorted_word] = new_list
    count = 0
    for k, v in anagram_dict.iteritems():
        if len(v) >= MIN_ANAGRAM_SET and len(k) >= MIN_ANAGRAM_SIZE:                
            count = count + 1
            remove_newline = [c.rstrip('\n') for c in v]
            print ", ".join(remove_newline)
    print "Total Anagram Sets ", count 
    
def sort_string(in_str): 
    c_list = [c.lower() for c in in_str]
    c_list.sort()
    return ''.join(c_list)       

print_anagrams() 
