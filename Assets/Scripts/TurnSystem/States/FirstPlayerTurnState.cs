using UnityEngine;

namespace SceneStateSystem
{
    public class FirstPlayerTurnState : ISceneState
    {
        public SceneStatesNames name => SceneStatesNames.FirstPlayerTurn;

        public void StateBegin()
        {
            Debug.Log("First Player Turn Begin");
        }

        public void StateEnd()
        {
            Debug.Log("First Player Turn End");
        }
    }
}

