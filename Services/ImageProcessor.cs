using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Services
{
    public class ImageProcessor
    {
        private readonly PluginRegistry _registry;

        public ImageProcessor(PluginRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public async Task<ProcessingResult> ProcessAsync(ProcessingJob job)
        {
            try
            {
                var currentImage = job.Image;

                foreach (var effect in job.Effects)
                {
                    var plugin = _registry.Get(effect.PluginName);
                    var parameters = effect.Parameters.ToDictionary(p => p.Name, p => p.Value);
                    currentImage = await plugin.ProcessAsync(currentImage, parameters);
                }

                return new ProcessingResult(job.Image.Id, currentImage, true);
            }
            catch (Exception ex)
            {
                return new ProcessingResult(job.Image.Id, null, false, ex.Message);
            }
        }

        public async Task<IEnumerable<ProcessingResult>> ProcessBatchAsync(IEnumerable<ProcessingJob> jobs)
        {
            var tasks = jobs.Select(ProcessAsync);
            return await Task.WhenAll(tasks);
        }
    }
}