using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    /// <summary>
    /// Called on the client when connected to a server. By default it sets client as ready and adds a player.
    /// </summary>
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        Debug.Log("I connected to the server");
    }

    /// <summary>
    /// Called on server when a client requests to add the player. Adds playerPrefab by default. 
    /// The default implementation for this function creates a new player object from the playerPrefab.
    /// </summary>
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        Debug.Log($"There are now {numPlayers} players connected to the server");
    }
}
