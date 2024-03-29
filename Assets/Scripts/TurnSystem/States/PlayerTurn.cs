using UnityEngine;

namespace SceneStateSystem
{
    public class PlayerTurn : IPlayerTurn
    {
        public int playerID { get; private set; }
        public PlayerTurn(int playerID)
        {
            this.playerID = playerID;
        }
        public SceneStatesNames name => SceneStatesNames.PlayerTurn;

        public void StateBegin()
        {
            Debug.Log($"{playerID} Player Turn Begin");
        }

        public void StateEnd()
        {
            Debug.Log($"{playerID} Player Turn End");
        }
    }

}

