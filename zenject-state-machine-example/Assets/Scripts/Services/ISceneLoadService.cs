using System.Threading.Tasks;

namespace Services
{
    public interface ISceneLoadService
    {
        Task LoadSceneAsync(string sceneName);
    }
}