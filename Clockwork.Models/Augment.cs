using System;
using System.ComponentModel.DataAnnotations;

namespace Clockwork.Models{
    public class Augment {
        public int Id {get;set;}
        [MaxLength(20)]
        public string Type {get;set;}

        [MaxLength(100)]
        public string Effects {get;set;}
        [MaxLength(500)]
        public string Description {get;set;}
        public int BasePrice {get;set;}
        public int PriceMultiplier {get;set;}

    }
}