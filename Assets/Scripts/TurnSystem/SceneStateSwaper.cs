using UnityEngine;
using Zenject;

namespace SceneStateSystem
{
    public class SceneStateSwaper : MonoBehaviour
    {
        [Inject] private IStateManager stateManager;

        public void ChangeState()
        {
            if (stateManager.curentStateName == SceneStatesNames.FirstPlayerTurn)
            {
                stateManager.SwapState(SceneStatesNames.SecondPlayerTurn);
            }
            else
            {
                stateManager.SwapState(SceneStatesNames.FirstPlayerTurn);
            }
        }

    }
}

