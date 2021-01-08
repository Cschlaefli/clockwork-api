
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Clockwork.Models{
    public class FilterProperty<T> : FilterProperty{
        public FilterProperty() {}
        public FilterProperty(string n)
        {
            Name = n;
        }

        public T Value {get;set;}
        public bool HasValue() => Value != null;

    }
    public class FilterProperty{
        public string Name {get;set;}
        public FilterOperations? Filter {get;set;} = FilterOperations.Nothing;
        public string SortDir {get;set;}

    }

    public enum FilterOperations{
        [Display(Name="")]
        Nothing,
        [Display(Name="=")]
        Contains,
        [Display(Name="<=")]
        LessThan,
        [Display(Name=">=")]
        GreaterThan,
        [Display(Name="=")]
        Equals
    }
}