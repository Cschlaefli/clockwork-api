using System;
using System.ComponentModel.DataAnnotations;

namespace tephraAPI.Models{
    public class Specialty {
        public int Id {get;set;}
        [MaxLength(35)]
        public string Name {get;set;}
        [MaxLength(20)]
        public string Skill {get;set;}
        [MaxLength(20)]
        public string Attr {get;set;}
        [MaxLength(50)]
        public string Subtype {get;set;}
        [MaxLength(200)]
        public string Requirments {get;set;}
        [MaxLength(200)]
        public string Resist {get;set;}
        [MaxLength(200)]
        public string Cost {get;set;}
        [MaxLength(10000)]
        public string Description {get;set;}
        public bool Stance {get;set;}
        public bool Reflexive {get;set;}
        [MaxLength(10000)]
        public string Notes {get;set;}
        public int Accuracy {get;set;}
        public int Strike {get;set;}
        public int Evade {get;set;}
        public int Defense {get;set;}
        public int Speed {get;set;}
        public int Priority {get;set;}
        public int Augments {get;set;}
        public int DIY {get;set;}
        public int Wounds {get;set;}
        public int HitPoints {get;set;}

    }
}