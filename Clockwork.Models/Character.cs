using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;
using Clockwork.Models.Annotations;
using Microsoft.EntityFrameworkCore;


namespace Clockwork.Models{
    [Filter]
    public class Character {
        [NoFilter]
        public int Id {get;set;}
        [MaxLength(100)]
        public string Name {get;set;}
        [MaxLength(10000)]
        public string Description {get;set;}

        public IEnumerable<CharacterSpecialty> Specialties {get;set;}
    }


}
