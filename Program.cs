using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;
using ImageProcessingFramework.Services;

class Program
{
    static async Task Main(string[] args)
    {

        var registry = new PluginRegistry();
        registry.Register(new ResizePlugin());
        registry.Register(new BlurPlugin());
        registry.Register(new GrayscalePlugin());

        var processor = new ImageProcessor(registry);

        // Add test Values
        var images = CreateTestImages();

        var jobs = CreateProcessingJobs(images);


        var results = await processor.ProcessBatchAsync(jobs);
       
        ReturnResults(results);
        PrintPluginsInfo(registry);
    }

    private static ImageData[] CreateTestImages()
    {
        return new[]
        {
            new ImageData("1", "photo1.jpg", 800, 600),
            new ImageData("2", "photo2.jpg", 1920, 1080),
            new ImageData("3", "photo3.jpg", 1024, 768)
        };
    }

    private static ProcessingJob[] CreateProcessingJobs(ImageData[] images)
    {
        return new[]
        {
            new ProcessingJob(images[0], new List<ImageEffect>
            {
                new("ResizePlugin", new List<PluginParameter> { new("Width", 100) }),
                new("BlurPlugin", new List<PluginParameter> { new("Radius", 2) })
            }),

            new ProcessingJob(images[1], new List<ImageEffect>
            {
                new("ResizePlugin", new List<PluginParameter> { new("Width", 100) })
            }),

            new ProcessingJob(images[2], new List<ImageEffect>
            {
                new("ResizePlugin", new List<PluginParameter> { new("Width", 150) }),
                new("BlurPlugin", new List<PluginParameter> { new("Radius", 5) }),
                new("GrayscalePlugin", new List<PluginParameter>())
            })
        };
    }

    private static void ReturnResults(IEnumerable<ProcessingResult> results)
    {
        Console.WriteLine("Processing Results:");
        foreach (var result in results)
        {
            Console.WriteLine(result.Success
                ? $"✓ {result.ImageId}: {result.ProcessedImage.Width}x{result.ProcessedImage.Height}"
                : $"✗ {result.ImageId}: {result.ErrorMessage}");
        }
    }

    private static void PrintPluginsInfo(PluginRegistry registry)
    {
        Console.WriteLine("Available Plugins:");
        foreach (var plugin in registry.GetAll())
        {
            Console.WriteLine($"- {plugin.GetType().Name}");
        }
    }
}