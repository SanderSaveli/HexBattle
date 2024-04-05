using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour, INewPlayerJoinHandler
{
    [SerializeField] private ColorTheme theme;
    Dictionary<int, Color> playerColors = new();

    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }
    public void NewPlayerJoin(INetworkPlayer player)
    {
        if (playerColors.Count == 0)
        {
            playerColors.Add(player.playerID, theme.firstPlayerColor);
        }
        else
        {
            playerColors.Add(player.playerID, theme.secondPlayerColor);
        }
    }

    public Color GetPlayerColor(int playerId)
    {
        if (playerColors.ContainsKey(playerId))
            return playerColors[playerId];
        else
            return Color.white;
    }
}
