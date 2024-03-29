using Mirror;
using SceneStateSystem;
using UnityEngine;
using Zenject;

public class CustomNetworkManager : NetworkManager
{

    [Inject] private IStateManager _stateManager;
    private int nextPlayerID = 1;
    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler<AddPlayerMessage>(OnServerAddPlayer);
    }

    public void OnServerAddPlayer(NetworkConnectionToClient conn, AddPlayerMessage message)
    {
        base.OnServerAddPlayer(conn);

        GameObject player = conn.identity.gameObject;

        PlayerObj identity = player.GetComponent<PlayerObj>();

        identity.playerID = nextPlayerID;
        nextPlayerID++;
        _stateManager.AddPlayer(identity.playerID);
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        GameObject player = conn.identity.gameObject;

        PlayerObj identity = player.GetComponent<PlayerObj>();

        _stateManager.RemovePlayer(identity.playerID);
        base.OnServerDisconnect(conn);
    }
}
