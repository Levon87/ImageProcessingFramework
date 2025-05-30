namespace ImageProcessingFramework.Models
{
    public class ProcessingResult
    {
        public string ImageId { get; set; }
        public ImageData ProcessedImage { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ProcessingResult(string imageId, ImageData processedImage, bool success, string errorMessage = null)
        {
            ImageId = imageId;
            ProcessedImage = processedImage;
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}