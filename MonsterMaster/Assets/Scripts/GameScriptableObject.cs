using Mirror;
using UnityEngine;

public class GameScriptableObject : ScriptableObject
{
    public GameObject gameObject;

    public virtual void Init(GameObject g)
    {
        gameObject = g;
        var identity = g.GetComponent<NetworkIdentity>();
        if (identity is null) return;
        if (identity.isServer) ServerInit();
        if (identity.isClient) ClientInit();
        if (identity.isLocalPlayer) LocalPlayerInit();
        if (identity.hasAuthority) AuthorityInit();
    }

    protected virtual void LocalPlayerInit() {}
    protected virtual void ServerInit() {}
    protected virtual void ClientInit() {}
    protected virtual void AuthorityInit() {}
}