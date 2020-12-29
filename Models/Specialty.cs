using System;
using System.ComponentModel.DataAnnotations;

namespace tephraAPI.Models{
    public class Specialty {
        public int Id {get;set;}
        [MaxLength(20)]
        public string Name {get;set;}
        [MaxLength(20)]
        public string Skill {get;set;}
        [MaxLength(50)]
        public string Requirments {get;set;}
        [MaxLength(5000)]
        public string Notes {get;set;}
        public int Acc {get;set;}
        public int Stk {get;set;}
        public int Eva {get;set;}
        public int Def {get;set;}
        public int Spd {get;set;}
        public int Pri {get;set;}
        public int Aug {get;set;}
        public int DIY {get;set;}
        public int Wnd {get;set;}

    }
}