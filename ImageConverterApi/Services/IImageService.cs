using SkiaSharp;

namespace ImageConverterApi.Services
{
    public interface IImageService
    {
        byte[] ResizeImage(Stream sourceImage, SKEncodedImageFormat newFormat, int newWidth, int newHeight, bool keepAspectRatio);
    }
}