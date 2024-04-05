using Mirror;
using SceneStateSystem;
using UnityEngine;
using Zenject;
using EventBusSystem;
using CellField2D;
using System.Collections.Generic;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private FieldManager fieldManager;

    [Inject] private IStateManager _stateManager;

    private List<int> _playerIDs = new List<int>();
    private int nextPlayerID = 1;
    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler<AddPlayerMessage>(OnServerAddPlayer);
    }

    public void OnServerAddPlayer(NetworkConnectionToClient conn, AddPlayerMessage message)
    {
        base.OnServerAddPlayer(conn);

        GameObject player = conn.identity.gameObject;

        NetworkPlayerEntity identity = player.GetComponent<NetworkPlayerEntity>();

        identity.playerID = nextPlayerID;
        _playerIDs.Add(nextPlayerID);
        nextPlayerID++;
        _stateManager.AddPlayer(identity.playerID);
        EventBus.RaiseEvent<INewPlayerJoinHandler>(it => it.NewPlayerJoin(identity));
        if(_playerIDs.Count == maxConnections) 
        {
            fieldManager.InstantField(_playerIDs[0], _playerIDs[1]);
        }
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        GameObject player = conn.identity.gameObject;

        NetworkPlayerEntity identity = player.GetComponent<NetworkPlayerEntity>();

        _stateManager.RemovePlayer(identity.playerID);
        _playerIDs.Remove(identity.playerID);
        base.OnServerDisconnect(conn);
    }
}
