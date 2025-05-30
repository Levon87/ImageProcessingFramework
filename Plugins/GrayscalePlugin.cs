using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins.Interfaces;

namespace ImageProcessingFramework.Plugins
{
    public class GrayscalePlugin : IImagePlugin
    {
        public string Name => "Grayscale";
        public string Description => "Черно-белое изображение";
        public Dictionary<string, Type> Parameters => new Dictionary<string, Type>();

        public async Task<ImageData> ProcessAsync(ImageData image, Dictionary<string, object> parameters)
        {
            await Task.Delay(100);
            return new ImageData(image.Id, $"{image.Name}_grayscale", image.Width, image.Height);
        }
    }
}