using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace SceneStateSystem
{
    public class SceneStateManager : NetworkBehaviour
    {
        private ISceneState _currentState;
        public SceneStatesNames curentStateName { get => _currentState.name; }
        protected Dictionary<string, ISceneState> _states = new();

        public delegate void SceneStateChanged(SceneStatesNames newState);
        public event SceneStateChanged OnSceneStateChanged;

        [ClientRpc]
        public virtual void SwapState(SceneStatesNames stateName)
        {
            SwapState(stateName.ToString());
        }

        [ClientRpc]
        public virtual void SwapState(string stateName)
        {
            _currentState?.StateEnd();
            if (!_states.TryGetValue(stateName, out _currentState))
            {
                Debug.LogWarning($"Can't changeState to {stateName}");
            }
            _currentState.StateBegin();

            OnSceneStateChanged?.Invoke(curentStateName);
        }
    }
}


