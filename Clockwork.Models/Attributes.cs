
namespace Clockwork.Models.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple=true)]
    public class IncludeAttribute : System.Attribute
    {}

}



[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple=true)]
internal sealed class FilterAttribute : System.Attribute {}
[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple=true)]
internal sealed class NoFilterAttribute : System.Attribute {}