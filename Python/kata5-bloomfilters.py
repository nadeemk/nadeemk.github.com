# Kata Five - Bloom Filters
import hashlib

def CreateBloomFilter():
    with open('resources\wordlist.txt') as f:
        for line in f:
            # Compute the hash
            m = hashlib.md5()
            m.update(line)
            print m.hexdigest()
            
            


CreateBloomFilter()
    




