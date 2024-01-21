using TaskManager.API.Data;

namespace TaskManager.API.Repositories.Abstract
{
    public abstract class BaseRepository
    {
        protected readonly TaskManagerDataContext context;
        public BaseRepository(TaskManagerDataContext context)
        {
            this.context = context;
        }
    }
}