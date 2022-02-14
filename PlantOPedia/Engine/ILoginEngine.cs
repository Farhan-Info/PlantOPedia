using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface ILoginEngine
    {
        Models.Response.Login CheckUser(Models.Request.Login user);
    }
}
