
import re
import operator

def get_smallest_diff(filename, regex, name_pos, first_pos, second_pos):
    minDiff = 999999;
    with open(filename, 'r') as f:
        for line in f:
            if re.match(regex, line) != None:
                team, fr, against = operator.itemgetter(name_pos, first_pos, 
                                                        second_pos)(line.split())
                diff = abs(int(re.match(r'\d+',fr).group(0)) - 
                           int(re.match(r'\d+',against).group(0)))
                if diff < minDiff:
                     minDiff = diff
                     minTeam = team
    print "Min Difference. ", minTeam, " Diff: ", minDiff

get_smallest_diff('football.dat',r"\s+\d+. \S+(\s+\d+){5}\s+-(\s+\d+){2}",1,6,8)
get_smallest_diff('weather.dat',r"(\s+\d+\*?){3}",0,1,2)
