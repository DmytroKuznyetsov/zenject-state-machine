using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Services
{
    public class SceneLoadService : ISceneLoadService
    {
        public async Task LoadSceneAsync(string sceneName)
        {
            var handler = Addressables.LoadSceneAsync(sceneName); 
            await handler.Task;
        }
    }
}