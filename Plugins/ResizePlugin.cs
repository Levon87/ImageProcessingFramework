using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins.Interfaces;

namespace ImageProcessingFramework.Plugins
{
    public class ResizePlugin : IImagePlugin
    {
        public string Name => "Resize";
        public string Description => "Changes Image Size";
        public Dictionary<string, Type> Parameters => new Dictionary<string, Type>
        {
            {"Width", typeof(int)},
            {"Height", typeof(int)}
        };

        public async Task<ImageData> ProcessAsync(ImageData image, Dictionary<string, object> parameters)
        {
            await Task.Delay(100);

            var width = (int)parameters["Width"];
            var height = parameters.ContainsKey("Height")
                ? (int)parameters["Height"]
                : image.Height * width / image.Width;

            return new ImageData(image.Id, image.Name, width, height);
        }
    }
}