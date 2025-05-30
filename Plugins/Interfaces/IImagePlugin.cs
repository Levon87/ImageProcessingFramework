using System.Collections.Generic;
using System.Threading.Tasks;
using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins.Interfaces
{
    public interface IImagePlugin
    {
        string Name { get; }
        string Description { get; }
        Dictionary<string, Type> Parameters { get; }
        Task<ImageData> ProcessAsync(ImageData image, Dictionary<string, object> parameters);
    }
}