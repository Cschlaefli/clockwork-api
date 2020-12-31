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
reqs = ''
resist = ''
cost = ''
stance = False
reflex = False

subtype_list = ["Essence Manipulation", "Armoring Vehicles"]

for line in lines :
    #some regex to match if line is skill, some regex to match if line is subtype
    if re.search(r'.*\(.*\)', line) :
        start = line.find("(")
        end = line.find(")")
        skill = line[0:start].strip()
        attr = line[start:end].strip("(")
        subtype = ''
    if line.find("Specialties") != -1:
        subtype = line.strip()
    if line.strip().startswith("Crafting") or line.strip() in subtype_list:
        subtype = line.strip()

    # 
    #skill = whatevermatch
    #attr = whatevermatch
    #subtype = ''


    out = {}
    bonus_matches = re.findall("(Accuracy|Evade|Strike|Defense|Priority|Speed|Augments|DIY|Wounds|Hit Points)(\s+\+[0-9]+)", line)
    name_end = re.search("(Accuracy\s*\+|Evade\s*\+|Strike\s*\+|Defense\s*\+|Priority\s*\+|Speed\s*\+|Augments\s*\+|DIY\s*\+|Wounds\s*\+|Hit Points\s*\+)", line)
    if name_end :
        name_end = name_end.span(0)[0]
        name = line[0:name_end].strip()
        out["Name"]  = name
        out["Skill"] = skill
        out["Attr"] = attr
        out["Subtype"] = subtype
        specialties[name] = out

    for m in bonus_matches :
        out[m[0].replace(" ", "")] = int(m[1])

#remove misparses
specialties.pop('Cost: Earthquaking', None)
specialties.pop('Cost: Reflexive Melee', None)
trimmed_lines = [l.strip() for l in lines if l.strip() != '']
line_numbers = []

for key in specialties.keys() :
    sp = specialties[key]
    line_number = trimmed_lines.index(key)
    #sp["line"] = line_number
    line_numbers.append(line_number)
line_numbers.sort()

line_numbers.append(line_numbers[-1] + 21)

for i in range(0,len(line_numbers)-1) :
    reqs = ''
    resist = ''
    cost = ''
    stance = False
    reflex = False

    start = line_numbers[i]
    end = line_numbers[i+1]
    sp_lines = trimmed_lines[start:end]
    #print(start,end)
    sp = specialties[sp_lines[0]]
    #sp["description"] = ''
    desc = ''
    for sp_l in sp_lines :
        line = sp_l.strip()
        req_match = re.compile("Requires:.*")
        resist_match = re.compile("Resist:.*")
        cost_match = re.compile("Cost:.*")
        reflex_match = re.compile(".*reflexively.*")
        stance_match = re.compile("Stance\s\(costs\s1\sAP\sto\senter\)")

        if line.strip() == sp["Name"] or re.match("\w+\sSpecialty.*", line.strip()):
            pass
        elif req_match.match(line) :
            sp["requirements"] = line
        elif resist_match.match(line) :
            sp["resist"] = line
        elif cost_match.match(line) :
            sp["cost"] = line
            if reflex_match.match(line) :
                sp["reflexive"] = True
        elif stance_match.match(line) :
            sp["stance"] = True
        else :
            desc += line + ' '
    sp["Description"] = desc

        

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