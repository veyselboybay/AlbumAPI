using Assignment_One_Revise.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_One_Revise.Repository
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Image> Add(Image image)
        {
            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }

        public async Task<Image> Delete(Image image)
        {
            var imageForDelete = await _dbContext.Images.Where(i => i.Id== image.Id).FirstOrDefaultAsync();
            if (imageForDelete != null)
            {
                _dbContext.Images.Remove(image);
                await _dbContext.SaveChangesAsync();
                return image;
            }
            return imageForDelete;
        }

        public async Task<Image> FindById(Guid id)
        {
            return await _dbContext.Images.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _dbContext.Images.ToListAsync();
        }
    }
}
