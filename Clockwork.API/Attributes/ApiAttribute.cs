
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple=true)]
    internal sealed class ApiAttribute: System.Attribute
    {
        public string Plural { get; set; }
        public string Template { get; }
        public ApiAttribute() {
            Template = "Default";
        }
    }