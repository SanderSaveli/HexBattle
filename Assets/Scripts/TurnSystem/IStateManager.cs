using static SceneStateSystem.SceneStateManager;
using static SceneStateSystem.TurnBacedStateManager;

namespace SceneStateSystem
{
    public interface IStateManager
    {
        public SceneStatesNames curentStateName { get; }

        public event SceneStateChanged OnSceneStateChanged;
        public event NewPlayerTurn OnNewPlayerTurn;
        public void SwapState(SceneStatesNames stateName);

        public void SwitchTurn(int palyerID);

        public void AddPlayer(int palyerID);
        public void RemovePlayer(int palyerID);
    }
}

