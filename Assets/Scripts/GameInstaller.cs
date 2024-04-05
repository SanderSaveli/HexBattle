using SceneStateSystem;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private TurnBacedStateManager stateManager;
    [SerializeField] private ThemeManager themeManager;
    public override void InstallBindings()
    {
        Container.Bind<IStateManager>().To<TurnBacedStateManager>().FromInstance(stateManager).AsSingle();
        Container.Bind<ThemeManager>().To<ThemeManager>().FromInstance(themeManager).AsSingle();
    }
}
