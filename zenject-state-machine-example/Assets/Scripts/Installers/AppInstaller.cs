using Core;
using Services;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        }
    }
}