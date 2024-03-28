using static SceneStateSystem.SceneStateManager;

namespace SceneStateSystem
{
    public interface IStateManager
    {
        public SceneStatesNames curentStateName { get; }
        public event SceneStateChanged OnSceneStateChanged;
        public void SwapState(SceneStatesNames stateName);

        public void SwitchTurn(int palyerID);
    }
}

