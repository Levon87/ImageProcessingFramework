namespace ImageProcessingFramework.Models
{
    public class ImageEffect
    {
        public string PluginName { get; set; }
        public List<PluginParameter> Parameters { get; set; }

        public ImageEffect(string pluginName, List<PluginParameter> parameters)
        {
            PluginName = pluginName;
            Parameters = parameters;
        }
    }
}