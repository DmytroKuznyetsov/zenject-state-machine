using Core;
using Services;
using States.Game.Services;
using Zenject;

namespace States.Game.Installers
{
    public class LocalGameInstaller : MonoInstaller
    {
        [Inject]
        public void Construct(DiContainer container, IInjectedPrefabsService injectedPrefabsService)
        {
            injectedPrefabsService.Set(container);
        }
        public override void InstallBindings()
        {
            Container.Bind<ILocalGameProgressService>().To<LocalGameProgressService>().AsSingle();
        }
    }
}