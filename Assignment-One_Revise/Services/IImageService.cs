using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Models;

namespace Assignment_One_Revise.Services
{
    public interface IImageService
    {
        Task<Image> Add(NewImageDto image);
        Task<Image> FindById(Guid id);
        Task<Image> Delete(Image image);
        Task<IEnumerable<Image>> GetAll();
    }
}
