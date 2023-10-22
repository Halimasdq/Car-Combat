import re
pattern =  r'[+/*-]'
Expression=" 2 3 5 6 7"
if re.search(pattern,Expression):
    print("the expression conhtain +,/,*,-")
else:
    print("the expression does not contain symbols")