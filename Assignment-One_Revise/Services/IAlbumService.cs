using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Models;

namespace Assignment_One_Revise.Services
{
    public interface IAlbumService
    {
        Task<Album> Add(NewAlbumDto album);
        Task<Album> FindById(Guid id);
        Task<IEnumerable<Album>> GetAll();
        Task<Album> Delete(Album album);
    }
}
