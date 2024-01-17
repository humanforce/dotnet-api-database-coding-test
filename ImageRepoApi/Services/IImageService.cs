using ImageConverterApi.Models;
using ImageRepoApi.Models;
using Storage.Entities;

namespace ImageConverterApi.Services
{
    public interface IImageService
    {
        Task<Guid> ImportImage(ImageUploadModel model, Stream imageData, string fileName);
        ImageInfo GetImageInfo(Image image);

    }
}