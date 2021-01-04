
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple=true)]
    internal sealed class ApiAttribute: System.Attribute
    {
        public string Name { get; }
        public string Template { get; }
        public ApiAttribute() {
            Name = "Default";
            Template = "Default";
        }
        public ApiAttribute(string name, string template)
            => (Name, Template) = (name, template);
    }