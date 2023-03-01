using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Models;
using Assignment_One_Revise.Repository;

namespace Assignment_One_Revise.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepo;

        public AlbumService(IAlbumRepository albumRepo)
        {
            _albumRepo = albumRepo;
        }
        public Task<Album> Add(NewAlbumDto album)
        {
            // Create a new album instance
            Album newAlbum = new Album();
            newAlbum.Id = Guid.NewGuid();
            newAlbum.Name = album.Name;

            return _albumRepo.Add(newAlbum);
        }

        public Task<Album> Delete(Album album)
        {
            return _albumRepo.Delete(album);
        }

        public Task<Album> FindById(Guid id)
        {
            return _albumRepo.FindById(id);
        }

        public Task<IEnumerable<Album>> GetAll()
        {
            return _albumRepo.GetAll();
        }
    }
}
