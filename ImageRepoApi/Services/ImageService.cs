using ImageConverterApi.Models;
using ImageRepoApi.Models;
using SkiaSharp;
using Storage;
using Storage.Entities;

namespace ImageConverterApi.Services
{
    public class ImageService : IImageService
    {
        private readonly DatabaseContext _dbContext;

        public ImageService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> ImportImage(ImageUploadModel model, Stream imageData, string fileName)
        {
            if (!Enum.TryParse<SKEncodedImageFormat>(model.TargetFormat, true, out var format))
                throw new ArgumentException($"Invalid image format: {model.TargetFormat}");

            using var img = SKImage.FromEncodedData(imageData);

            var (targetWidth, targetHeight) = GetTargetImageDimentions(model, img.Height, img.Width);
            var resizedImage = ResizeImage(img, format, targetWidth, targetHeight);
            var image = new Image
            {
                CreatedAt = DateTime.UtcNow,
                Data = resizedImage,
                FileName = fileName,
                Width = targetWidth,
                Height = targetHeight,
                ImageFormat = format.ToString().ToLower()
            };

            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();

            return image.ImageId;
        }

        public ImageInfo GetImageInfo(Image image)
        {
            var imageStoredSize = image.Data != null
                ? image.Data.Length
                : 0;
            return new ImageInfo
                (image.FileName ?? string.Empty, image.ImageFormat ?? string.Empty, image.CreatedAt, image.Width, image.Height, imageStoredSize);
        }

        private (int targetWidth, int targetHeight) GetTargetImageDimentions(ImageUploadModel model, int sourceImageHeight, int sourceImageWidth)
        {
            var targetWidth = model.TargetWidth;
            var targetHeight = model.TargetHeight;
            if (model.KeepAspectRatio)
            {
                //Assuming img dimentions are W:H
                targetHeight = targetWidth > 0
                    ? (targetWidth * sourceImageHeight) / sourceImageWidth
                    : targetHeight;

                targetWidth = targetWidth <= 0
                    ? (sourceImageWidth * targetHeight) / sourceImageHeight
                    : targetWidth;
            }
            return (targetWidth, targetHeight);
        }

        private byte[] ResizeImage(SKImage sourceImage, SKEncodedImageFormat newFormat, int newWidth, int newHeight)
        {
            using var resizedImg = ResizeImage(sourceImage, newWidth, newHeight);
            using var data = resizedImg.Encode(newFormat, 100);
            return data.ToArray();
        }

        private SKImage ResizeImage(SKImage sourceImage, int newWidth, int newHeight)
        {
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
