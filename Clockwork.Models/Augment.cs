using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections;


namespace Clockwork.Models{
    [Filter]
    public class Augment{
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