using SceneStateSystem;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private TurnBacedStateManager stateManager;
    public override void InstallBindings()
    {
        Container.Bind<IStateManager>().To<TurnBacedStateManager>().FromInstance(stateManager).AsSingle();
    }
}
