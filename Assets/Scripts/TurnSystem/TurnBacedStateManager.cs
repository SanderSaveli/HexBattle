using System.Collections.Generic;
using UnityEngine;

namespace SceneStateSystem
{
    public class TurnBacedStateManager : SceneStateManager, IStateManager
    {
        public int round { get; private set; }

        private int _currentTurn = 0;
        private List<int> _playersID = new();
        private Dictionary<int, IPlayerTurn> _playersTurnsStates = new();

        public delegate void NewPlayerTurn(IPlayerTurn newState);
        public event NewPlayerTurn OnNewPlayerTurn;

        public bool IsPlayerTurn(int playerId)
        {
            return _playersID[_currentTurn] == playerId;
        }

        private int GetCurrentPlayerID()
        {
            return _playersID[_currentTurn];
        }

        public override void SwapState(SceneStatesNames stateName)
        {
            if(stateName == SceneStatesNames.PlayerTurn)
            {
                int currPlayerID = GetCurrentPlayerID();
                SwapState(GetStateKeyByPlayerID(currPlayerID));
                OnNewPlayerTurn?.Invoke(_playersTurnsStates[currPlayerID]);
                return;
            }
            base.SwapState(stateName);
        }

        public void SwitchTurn(int playerId)
        {
            if (!IsPlayerTurn(playerId))
            {
                Debug.Log("ThisPlayerCanMaceTurn");
                return;
            }
            NextTurn();
            SwapState(SceneStatesNames.PlayerTurn);
        }

        public void AddPlayer(int playerID)
        {
            _playersID.Add(playerID);
            string StateKey = GetStateKeyByPlayerID(playerID);

            _playersTurnsStates.Add(playerID, new PlayerTurn(playerID));
            _states.Add(StateKey, _playersTurnsStates[playerID]);
            Debug.Log("Playerr add with id" + playerID);
        }

        public void RemovePlayer(int palyerID)
        {
            if (IsPlayerTurn(palyerID))
            {
                SwitchTurn(palyerID);
            }
            _playersID.Remove(palyerID);
            _states.Remove(GetStateKeyByPlayerID(palyerID));

        }

        private void NextTurn()
        {
            _currentTurn++;
            round += _currentTurn / _playersID.Count;
            _currentTurn %= _playersID.Count;
        }

        private string GetStateKeyByPlayerID(int PlayerID) 
        { 
            return "PlayerTurn" + PlayerID;
        }
    }

}

