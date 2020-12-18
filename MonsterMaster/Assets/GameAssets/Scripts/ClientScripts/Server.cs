using GameAssets.Scripts.ClientScripts.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts
{
    public class Server : NetworkBehaviour
    {
        public static GameObject LocalPlayer;

        public override void OnStartLocalPlayer() => LocalPlayer = gameObject;

        public override void OnStartClient()
        {
            if (!isServer || NetworkServer.connections.Count != 2) return;
            LocalPlayer.GetComponent<TurnController>().CmdEndTurn(); // Start Game
        }

        [Command]
        public void CmdDisconnect() => NetworkServer.Shutdown();

        [Command]
        public void CmdDestroy(GameObject g) => NetworkServer.Destroy(g);
    }
}