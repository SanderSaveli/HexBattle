using Mirror;
using SceneStateSystem;
using UnityEngine;
using Zenject;

public class PlayerObj : NetworkBehaviour
{
    [SyncVar]
    public int playerID;

    [Inject] private IStateManager stateManager;

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
