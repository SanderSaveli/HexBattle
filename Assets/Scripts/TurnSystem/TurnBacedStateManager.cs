namespace SceneStateSystem
{
    public class TurnBacedStateManager : SceneStateManager, IStateManager
    {
        private enum Turn
        {
            First,
            Second
        }
        public int round { get; private set; }
        public SceneStatesNames currentTurn { get => TurnToState(_currentTurn); }

        private Turn _currentTurn;

        private int player1ID = 1;
        private int player2ID = 2;

        public void SetPlayerIDs(int p1ID, int p2ID)
        {
            player1ID = p1ID;
            player2ID = p2ID;
        }

        public bool IsPlayer1Turn()
        {
            return (player1ID == GetCurrentPlayerID());
        }

        public bool IsPlayer2Turn()
        {
            return (player2ID == GetCurrentPlayerID());
        }

        private int GetCurrentPlayerID()
        {
            return _currentTurn == Turn.First ? player1ID : player2ID;
        }

        public override void SwapState(SceneStatesNames stateName)
        {
            base.SwapState(stateName);
        }

        public void SwitchTurn(int playerId)
        {
            if (playerId != GetCurrentPlayerID())
                return;

            _currentTurn = _currentTurn == Turn.First ? Turn.Second : Turn.First;
            if (_currentTurn == Turn.First)
            {
                round++;
            }
            SwapState(TurnToState(_currentTurn));
        }

        private SceneStatesNames TurnToState(Turn turn)
        {
            return turn == Turn.First ? SceneStatesNames.FirstPlayerTurn : SceneStatesNames.SecondPlayerTurn;
        }
    }

}

