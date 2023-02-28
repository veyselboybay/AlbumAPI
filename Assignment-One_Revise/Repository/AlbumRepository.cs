using Assignment_One_Revise.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_One_Revise.Repository
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Album> Add(Album album)
        {
            _dbContext.Albums.Add(album);
            await _dbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Album> Delete(Album album)
        {
            var albumDelete = await _dbContext.Albums.Where(a => a.Id == album.Id).FirstOrDefaultAsync();
            if(albumDelete!= null)
            {
                _dbContext.Albums.Remove(albumDelete);
                var itemsToRemove = await _dbContext.Images.Where(i => i.AlbumId== album.Id).ToListAsync();
                if(itemsToRemove.Count() > 0)
                {
                    _dbContext.Images.RemoveRange(itemsToRemove);
                }
                await _dbContext.SaveChangesAsync();
            }
            return album;
        }

        public async Task<Album> FindById(Guid id)
        {
            return await _dbContext.Albums.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _dbContext.Albums.ToListAsync();
        }
    }
}
