using System.Collections.Generic;

namespace ImageProcessingFramework.Models
{
    public class ProcessingJob
    {
        public ImageData Image { get; }
        public List<ImageEffect> Effects { get; }

        public ProcessingJob(ImageData image, List<ImageEffect> effects)
        {
            Image = image;
            Effects = effects;
        }
    }
}