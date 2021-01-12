
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Clockwork.Models{
    [Filter]
    public class CharacterSpecialty {
        public int Id {get;set;}
        public Specialty Specialty {get;set;}
        [MaxLength(500)]
        public string Notes {get;set;}
        public short Level {get;set;}
    }
}