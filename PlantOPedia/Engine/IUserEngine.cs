using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IUserEngine
    {
        public Models.Response.User Get(Guid id);
        public SuccessResponse Post(Models.Request.User user);
        public SuccessResponse Put(Guid id, Models.Request.User user);
    }
}
