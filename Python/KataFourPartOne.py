# Data Munging 
# Given a weather data for a month, find the day with smallest temprature spread.


# 1) Open file
#       a) Read each line
#       b) Go to line starts with 'Dy'
#       c) Skip to two lines after
#       d) Read until 'Dy' value is 'mo'
# 2) Keep a min value. Initialize to Int.MaxValue.
# 3) Extract min value for a day. compare with the existing min value
# 4) Update day and value.
import re
import operator

def getTempSpread(filename):
    minDiff = 999999;
    with open(filename, 'r') as f:
        for line in f:
            if re.match(r"(\s+\d+\*?){3}",line):
                day, minT, maxT = operator.itemgetter(0,1,2)(line.split())
                minT, maxT = int(minT.rstrip("*")),int(maxT.rstrip("*"))
                diff = abs(minT - maxT)
                if diff < minDiff: 
                    minDiff = diff
                    minDay = day
            
    print "Minimum Spread. Day: ", minDay, " Spread: ", minDiff

getTempSpread('weather.dat')
