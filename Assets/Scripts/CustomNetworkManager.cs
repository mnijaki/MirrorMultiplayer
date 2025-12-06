using Mirror;

public class CustomNetworkManager : NetworkManager
{
    /// <summary>
    /// Called on server when a client requests to add the player. Adds playerPrefab by default. 
    /// The default implementation for this function creates a new player object from the playerPrefab.
    /// </summary>
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        var customNetworkPlayer = conn.identity.GetComponent<CustomNetworkPlayer>();
        customNetworkPlayer.SetDisplayName($"Player {numPlayers}");
        customNetworkPlayer.SetRandomColor();
    }
}
