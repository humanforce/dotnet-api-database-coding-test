namespace ImageRepoApi.Models
{
    public class ImageInfo
    {
        public ImageInfo(string originalFilename, string format, DateTime createdTime, int width, int height, int storedSize)
        {
            OriginalFilename = originalFilename;
            Format = format;
            CreatedTime = createdTime;
            Width = width;
            Height = height;
            StoredSize = storedSize;
        }

        public string? OriginalFilename { get; set; }
        public string? Format { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int? StoredSize { get; set; }
    }
}
