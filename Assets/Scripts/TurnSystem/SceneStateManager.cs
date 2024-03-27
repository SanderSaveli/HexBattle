using UnityEngine;

namespace SceneStateSystem
{
    public class SceneStateManager
    {
        private ISceneState _currentState;
        public SceneStatesNames curentStateName { get => _currentState.name; }

        public delegate void SceneStateChanged(SceneStatesNames newState);
        public event SceneStateChanged OnSceneStateChanged;
        public SceneStateManager(ISceneState beginState)
        {
            _currentState = beginState;
            SwapState(beginState);
        }

        public void SwapState(ISceneState newState)
        {
            if (newState == null)
            {
                Debug.LogWarning($"Incorrect scene state change, curren state: {_currentState}, new state: {newState}");
                return;
            }

            _currentState.StateEnd();
            _currentState = newState;
            _currentState.StateBegin();

            OnSceneStateChanged?.Invoke(curentStateName);
        }
    }
}


