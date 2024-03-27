using UnityEngine;

namespace SceneStateSystem
{
    public class SceneStateSwaper : MonoBehaviour
    {
        private SceneStateManager stateManager;

        void Start()
        {
            stateManager = new SceneStateManager(new FirstPlayerTurnState());
        }

        public void ChangeState()
        {
            if (stateManager.curentStateName == SceneStatesNames.FirstPlayerTurn)
            {
                stateManager.SwapState(new SecondPlayerTurn());
            }
            else
            {
                stateManager.SwapState(new FirstPlayerTurnState());
            }
        }

    }
}

