#from bs4 import BeautifulSoup as bs
import json
import re

with open('datascripts\Raw_text.txt', encoding='utf-8') as f :
    lines = f.readlines()


testline = "      Touch of Paralysis        Accuracy +1, Strike +2, Hit Points +7"

specialties = {}
lines = [testline]

skill = ''
subtype = ''

for line in lines :
    out = {}
    bonus_matches = re.findall("(Accuracy|Strike|Hit Points)(\s+\+[0-9]+)", line)
    name_end = re.search("(Accuracy\s*\+|Strike\s*\+|Hit Points\s*\+)", line).span(0)[0]

    name = line[0:name_end].strip()
    out["Name"]  = name

    for m in bonus_matches :
        out[m[0]] = int(m[1])
    specialties[name] = out

print( specialties)



'''
with open("datascripts\PrettyPrinted.html", 'r', encoding = 'utf-8') as f :
    soup = bs(f.read())
    prettyHTML = soup.get_text() 
with open("datascripts\Raw_Text.txt", 'w', encoding='utf-8') as wf:
    wf.write(str(prettyHTML))

soup
with open("datascripts\PrettyPrinted.html", 'r', encoding='utf-8') as wf:
    soup = bs(wf.read())

json_out = {
    "specialties" : [],
    "augments" : []
}

soup.find_all('Specialty')


with open("datascripts\output.json", 'w') as f :
    f.write(json_out)
    '''