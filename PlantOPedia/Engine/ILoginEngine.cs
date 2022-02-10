using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface ILoginEngine
    {
        Users CheckUser(LoginCredentials user);
    }
}
