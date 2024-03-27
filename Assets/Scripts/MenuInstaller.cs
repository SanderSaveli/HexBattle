using SceneLoad;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISceneLoader>().To<SceneLoader>().FromNew().AsSingle();
    }
}
