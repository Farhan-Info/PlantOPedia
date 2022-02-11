using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IUserEngine
    {
        public Users Get(Guid id);
        public SuccessResponse Post(Users user);
        public SuccessResponse Put(Guid id, Users user);
    }
}
