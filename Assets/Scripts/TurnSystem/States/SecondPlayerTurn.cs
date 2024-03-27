using UnityEngine;

namespace SceneStateSystem
{
    public class SecondPlayerTurn : ISceneState
    {
        public SceneStatesNames name => SceneStatesNames.SecondPlayerTurn;

        public void StateBegin()
        {
            Debug.Log("Second Player Turn Begin");
        }

        public void StateEnd()
        {
            Debug.Log("Second Player Turn End");
        }
    }
}


