using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace SceneStateSystem
{
    public class SceneStateManager : NetworkBehaviour
    {
        private ISceneState _currentState;
        public SceneStatesNames curentStateName { get => _currentState.name; }
        private Dictionary<SceneStatesNames, ISceneState> _states;

        public delegate void SceneStateChanged(SceneStatesNames newState);
        public event SceneStateChanged OnSceneStateChanged;
        private void OnEnable()
        {
            InitialStates();
            _states.TryGetValue(SceneStatesNames.FirstPlayerTurn, out _currentState);
            _currentState.StateBegin();

            OnSceneStateChanged?.Invoke(curentStateName);
        }

        public virtual void SwapState(SceneStatesNames stateName)
        {
            RpcSwapTurn(stateName);
        }

        [ClientRpc]
        public virtual void RpcSwapTurn(SceneStatesNames stateName)
        {
            _currentState?.StateEnd();
            if (!_states.TryGetValue(stateName, out _currentState))
            {
                Debug.LogWarning($"Can't changeState to {stateName}");
            }
            _currentState.StateBegin();

            OnSceneStateChanged?.Invoke(curentStateName);
        }

        public bool IsLocalPlayerTurn()
        {
            if (isLocalPlayer && _currentState.name == SceneStatesNames.FirstPlayerTurn)
                return true;

            if (!isLocalPlayer && !(_currentState.name == SceneStatesNames.FirstPlayerTurn))
                return true;

            return false;
        }

        protected virtual void InitialStates()
        {
            _states = new Dictionary<SceneStatesNames, ISceneState>
            {
                { SceneStatesNames.FirstPlayerTurn, new FirstPlayerTurnState() },
                { SceneStatesNames.SecondPlayerTurn, new SecondPlayerTurn() }
            };
        }
    }
}


