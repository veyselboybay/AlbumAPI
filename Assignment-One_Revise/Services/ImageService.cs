using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Models;
using Assignment_One_Revise.Repository;

namespace Assignment_One_Revise.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageRepository _imageRepo;
        public ImageService(ImageRepository imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public Task<Image> Add(NewImageDto image)
        {
            // Create a new image instance
            Image newImage = new Image();
            newImage.Id = Guid.NewGuid();
            newImage.AlbumId = image.AlbumId;
            newImage.Caption= image.Caption;
            //TODO:Insert S3 url here
            newImage.Url = "";

            //Save image
            return _imageRepo.Add(newImage);
        }

        public Task<Image> Delete(Image image)
        {
            //TODO:Insert s3 image deleting code here
            return _imageRepo.Delete(image);
        }

        public Task<Image> FindById(Guid id)
        {
            return _imageRepo.FindById(id);
        }

        public Task<IEnumerable<Image>> GetAll()
        {
            return _imageRepo.GetAll();
        }
    }
}
