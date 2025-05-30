namespace ImageProcessingFramework.Models
{
    public class ImageData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ImageData(string id, string name, int width, int height)
        {
            Id = id;
            Name = name;
            Width = width;
            Height = height;
        }
    }
}