using Mirror;
using SceneStateSystem;
using UnityEngine;
using Zenject;

public class CustomNetworkManager : NetworkManager
{

    [Inject] private IStateManager _stateManager;
    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler<AddPlayerMessage>(OnServerAddPlayer);
    }

    public void OnServerAddPlayer(NetworkConnectionToClient conn, AddPlayerMessage message)
    {
        base.OnServerAddPlayer(conn);

        GameObject player = conn.identity.gameObject;

        PlayerObj identity = player.GetComponent<PlayerObj>();

        // Присваиваем уникальные идентификаторы игрокам
        if (numPlayers == 1)
        {
            identity.playerID = 1; // Первый игрок
        }
        else if (numPlayers == 2)
        {
            identity.playerID = 2; // Второй игрок
        }
    }
}
