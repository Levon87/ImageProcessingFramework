namespace ImageProcessingFramework.Models
{
    public class PluginParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public PluginParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}