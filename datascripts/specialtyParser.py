#from bs4 import BeautifulSoup as bs
import json
import re

with open('datascripts\Raw_text.txt', encoding='utf-8') as f :
    lines = f.readlines()


testline = "      Touch of Paralysis        Accuracy +1, Strike +2, Hit Points +7"
#comment the following out to run on full text
#lines = [testline]

specialties = {}

skill = ''
attr = ''
subtype = ''

for line in lines :
    #some regex to match if line is skill, some regex to match if line is subtype
    if re.search(r'.*\(.*\)', line) :
        start = line.find("(")
        end = line.find(")")
        skill = line[0:start].strip()
        attr = line[start:end].strip("(")
        subtype = ''
    if line.find("Specialties") != -1 or line.find("Crafting") != -1 :
        subtype = line.strip()

    # 
    #skill = whatevermatch
    #attr = whatevermatch
    #subtype = ''


    out = {}
    bonus_matches = re.findall("(Accuracy|Strike|Hit Points)(\s+\+[0-9]+)", line)
    name_end = re.search("(Accuracy\s*\+|Strike\s*\+|Hit Points\s*\+)", line)
    if name_end :
        name_end = name_end.span(0)[0]
        name = line[0:name_end].strip()
        out["Name"]  = name
        out["Skill"] = skill
        out["Attr"] = attr
        out["Subtype"] = subtype
        specialties[name] = out

    for m in bonus_matches :
        out[m[0]] = int(m[1])

#print( specialties)

with open('datascripts\output.json', 'w') as f :
    f.write(json.dumps(specialties, indent=4))



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