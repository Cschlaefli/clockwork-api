from urllib import request, parse
import json

with open("datascripts/output.json", 'r') as f :
    tmp = json.load(f)
    data = []
    for sp in tmp.values() :
        data.append(sp)

    url = "http://localhost:5000/api/Specialty/"

    for e in data :
        j_e = json.dumps(e).encode('utf-8')
        #e_data = parse.urlencode().encode()
        req = request.Request(url, data=j_e)
        req.add_header('Content-Type', 'application/json; charset=utf-8')
        #req.add_header('Content-Type','application/json; charset=utf-8')
        response = request.urlopen(req)

        print(response.read())