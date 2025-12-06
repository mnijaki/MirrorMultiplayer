using Mirror;
using UnityEngine;

public class CustomNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string _displayName = "Missing Player name.";
    
    [SyncVar]
    [SerializeField]
    private Color _color = Color.white;

    [Server]
    public void SetDisplayName(string displayName)
    {
        _displayName = displayName;
    }
    
    [Server]
    public void SetColor(Color color)
    {
        _color = color;
    }
    
    [Server]
    public void SetRandomColor()
    {
        SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }
}
