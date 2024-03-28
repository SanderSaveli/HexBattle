using UnityEngine;
using Zenject;
using Mirror;

namespace SceneStateSystem
{
    public class TurnIndicator : MonoBehaviour
    {
        public Material first;
        public Material second;
        private MeshRenderer _meshRenderer;

        private IStateManager _stateManager;

        private void Start()
        {
            Debug.Log(_stateManager);
            _meshRenderer = GetComponent<MeshRenderer>();
            SwitchTurn(_stateManager.curentStateName);
            
            _stateManager.OnSceneStateChanged += SwitchTurn;
        }

        public void SwitchTurn(SceneStatesNames newStateNane)
        {
            if (newStateNane == SceneStatesNames.FirstPlayerTurn)
            {
                _meshRenderer.material = first;
            }
            if (newStateNane == SceneStatesNames.SecondPlayerTurn)
            {
                _meshRenderer.material = second;
            }
        }

        [Inject]
        private void Inject(IStateManager stateManager)
        {
            _stateManager = stateManager;
        }
    }
}


