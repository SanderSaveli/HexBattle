using Mirror;
using SceneStateSystem;
using UnityEngine;
using Zenject;

public class NetworkPlayerEntity : NetworkBehaviour, INetworkPlayer
{
    [SyncVar]
    public int playerID;

    [Inject] private IStateManager stateManager;

    int INetworkPlayer.playerID => playerID;

    public override void OnStartServer()
    {
        playerID = connectionToClient.connectionId;
    }

    private void Start()
    {
        stateManager = FindObjectOfType<TurnBacedStateManager>();
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;
        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerEndTurn();
        }
    }

    [Command]
    public void PlayerEndTurn()
    {
        stateManager.SwitchTurn(playerID);
    }
}
