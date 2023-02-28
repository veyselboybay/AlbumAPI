using Assignment_One_Revise.Models;

namespace Assignment_One_Revise.Repository
{
    public interface IAlbumRepository
    {
        Task<Album> Add(Album album);
        Task<Album> FindById(Guid id);
        Task<IEnumerable<Album>> GetAll();
        Task<Album> Delete(Album album);
    }
}
