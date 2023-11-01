using SkiaSharp;

namespace ImageConverterApi.Services
{
    public class ImageService : IImageService
    {

        public byte[] ResizeImage(Stream sourceImage, SKEncodedImageFormat newFormat, int newWidth, int newHeight, bool keepAspectRatio)
        {
            using var img = SKImage.FromEncodedData(sourceImage);
            using var resizedImg = ResizeImage(img, newWidth, newHeight, keepAspectRatio);
            using var data = resizedImg.Encode(newFormat, 100);
            return data.ToArray();
        }


        private SKImage ResizeImage(SKImage sourceImage, int newWidth, int newHeight, bool keepAspectRatio)
        {
            // TODO: implement maintainAspectRatio paramter

            var destRect = new SKRect(0, 0, newWidth, newHeight);
            var srcRect = new SKRect(0, 0, sourceImage.Width, sourceImage.Height);

            using var result = new SKBitmap((int)destRect.Width, (int)destRect.Height);
            using var g = new SKCanvas(result);
            using var p = new SKPaint
            {
                FilterQuality = SKFilterQuality.High,
                IsAntialias = true
            };

            g.DrawImage(sourceImage, srcRect, destRect, p);

            return SKImage.FromBitmap(result);
        }
    }
}
