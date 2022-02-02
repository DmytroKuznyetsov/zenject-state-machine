using Core;
using Services;
using States.Game.Services;
using Zenject;

namespace States.Game.Installers
{
    public class LocalGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILocalGameProgressService>().To<LocalGameProgressService>().AsSingle();
        }
    }
}