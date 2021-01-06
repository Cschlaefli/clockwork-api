using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;


namespace Clockwork.Models{
    public class FilterProperty<T>{
        public T Value {get;set;}
        public FilterOperations? Filter {get;set;} = FilterOperations.Nothing;
        public string Sort {get;set;}
        public bool HasValue() => Value != null;

    }

    public enum FilterOperations{
        Nothing,
        Contains,
        LessThan,
        GreaterThan,
        Equals
    }

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