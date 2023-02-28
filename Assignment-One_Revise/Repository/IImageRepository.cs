using Assignment_One_Revise.Models;

namespace Assignment_One_Revise.Repository
{
    public interface IImageRepository
    {
        Task<Image> Add(Image image);
        Task<Image> FindById(Guid id);
        Task<Image> Delete(Image image);
        Task<IEnumerable<Image>> GetAll();
    }
}
