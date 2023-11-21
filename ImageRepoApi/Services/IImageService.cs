using ImageConverterApi.Models;

namespace ImageConverterApi.Services
{
    public interface IImageService
    {
        Task<Guid> ImportImage(ImageUploadModel model, Stream imageData, string fileName);
    }
}