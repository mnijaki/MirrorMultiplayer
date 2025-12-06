using Mirror;
using TMPro;
using UnityEngine;

public class CustomNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnDisplayNameChanged))]
    [SerializeField]
    private string _displayName = "Missing Player name.";
    
    [SyncVar(hook = nameof(OnColorChanged))]
    [SerializeField]
    private Color _color = Color.white;
    
    [SerializeField]
    private TMP_Text _displayNameText;
    
    [SerializeField]
    private MeshRenderer _playerMeshRenderer;
    
    private static readonly int _baseColorID = Shader.PropertyToID("_BaseColor");

    #region Server

    [Server]
    public void SetDisplayName(string displayName)
    {
        _displayName = displayName;
    }
    
    [Command]
    public void CmdSetDisplayName(string displayName)
    {
        RpcLogNewDisplayName(displayName);
        
        SetDisplayName(displayName);
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

    #endregion

    #region Client

    [ContextMenu("Set My Name")]
    private void SetMyName()
    {
        CmdSetDisplayName("My new name");
    }

    [ClientRpc]
    public void RpcLogNewDisplayName(string displayName)
    {
        Debug.Log("Rpc SetDisplayName: " + displayName);
    }
    
    [Client]
    private void OnDisplayNameChanged(string oldDisplayName, string newDisplayName)
    {
        _displayNameText.SetText(newDisplayName);
    }
    
    [Client]
    private void OnColorChanged(Color oldColor, Color newColor)
    {
        _playerMeshRenderer.material.SetColor(_baseColorID, newColor); 
    }
    
    #endregion
}
