using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins.Interfaces;

namespace ImageProcessingFramework.Plugins
{
    public class BlurPlugin : IImagePlugin
    {
        public string Name => "Blur";
        public string Description => "Image Blur";
        public Dictionary<string, Type> Parameters => new Dictionary<string, Type>
        {
            {"Radius", typeof(int)}
        };

        public async Task<ImageData> ProcessAsync(ImageData image, Dictionary<string, object> parameters)
        {
            await Task.Delay(100);
            return new ImageData(image.Id, $"{image.Name}_blurred", image.Width, image.Height);
        }
    }
}