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
            
            _stateManager.OnNewPlayerTurn += SwitchTurn;
        }

        public void SwitchTurn(IPlayerTurn newStateNane)
        {
            if (newStateNane.playerID == 1)
            {
                _meshRenderer.material = first;
            }
            if (newStateNane.playerID == 2)
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


