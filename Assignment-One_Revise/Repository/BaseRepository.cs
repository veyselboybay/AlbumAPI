namespace Assignment_One_Revise.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
